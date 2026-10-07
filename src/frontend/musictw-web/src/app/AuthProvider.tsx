import {
  createContext,
  useEffect,
  useMemo,
  useState,
  type PropsWithChildren,
} from 'react'
import { authApi } from '../services/api/auth-api'
import { clearStoredToken, getStoredToken, setStoredToken } from '../store/auth-store'
import type {
  AuthResponse,
  CurrentUser,
  LoginRequest,
  RegisterRequest,
} from '../types/api'

type AuthContextValue = {
  user: CurrentUser | null
  token: string | null
  isLoading: boolean
  isAuthenticated: boolean
  login: (payload: LoginRequest) => Promise<AuthResponse>
  register: (payload: RegisterRequest) => Promise<AuthResponse>
  logout: () => void
  refreshCurrentUser: () => Promise<void>
}

export const AuthContext = createContext<AuthContextValue | null>(null)

function mapAuthResponseToUser(response: AuthResponse): CurrentUser {
  return {
    userId: response.userId,
    userName: response.userName,
    email: response.email,
    isAuthenticated: true,
  }
}

export function AuthProvider({ children }: PropsWithChildren) {
  const [token, setToken] = useState<string | null>(() => getStoredToken())
  const [user, setUser] = useState<CurrentUser | null>(null)
  const [isLoading, setIsLoading] = useState(true)

  useEffect(() => {
    let isMounted = true

    async function bootstrap() {
      if (!token) {
        if (isMounted) {
          setIsLoading(false)
        }
        return
      }

      try {
        const currentUser = await authApi.me(token)
        if (isMounted) {
          setUser(currentUser)
        }
      } catch {
        clearStoredToken()
        if (isMounted) {
          setToken(null)
          setUser(null)
        }
      } finally {
        if (isMounted) {
          setIsLoading(false)
        }
      }
    }

    void bootstrap()

    return () => {
      isMounted = false
    }
  }, [token])

  async function login(payload: LoginRequest) {
    const response = await authApi.login(payload)
    setStoredToken(response.token)
    setToken(response.token)
    setUser(mapAuthResponseToUser(response))
    return response
  }

  async function register(payload: RegisterRequest) {
    const response = await authApi.register(payload)
    setStoredToken(response.token)
    setToken(response.token)
    setUser(mapAuthResponseToUser(response))
    return response
  }

  function logout() {
    clearStoredToken()
    setToken(null)
    setUser(null)
  }

  async function refreshCurrentUser() {
    if (!token) {
      setUser(null)
      return
    }

    const currentUser = await authApi.me(token)
    setUser(currentUser)
  }

  const value = useMemo<AuthContextValue>(
    () => ({
      user,
      token,
      isLoading,
      isAuthenticated: Boolean(token && user?.isAuthenticated),
      login,
      register,
      logout,
      refreshCurrentUser,
    }),
    [isLoading, token, user],
  )

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>
}
