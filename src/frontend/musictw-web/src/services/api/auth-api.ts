import type {
  AuthResponse,
  CurrentUser,
  LoginRequest,
  RegisterRequest,
} from '../../types/api'
import { apiFetch } from './client'

export const authApi = {
  login: (payload: LoginRequest) =>
    apiFetch<AuthResponse>('/api/auth/login', {
      method: 'POST',
      body: JSON.stringify(payload),
    }),
  register: (payload: RegisterRequest) =>
    apiFetch<AuthResponse>('/api/auth/register', {
      method: 'POST',
      body: JSON.stringify(payload),
    }),
  me: (token: string) =>
    apiFetch<CurrentUser>('/api/auth/me', {
      method: 'GET',
      token,
    }),
}
