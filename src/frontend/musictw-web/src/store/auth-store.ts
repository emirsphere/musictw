const AUTH_TOKEN_KEY = 'musictw.auth.token'

export function getStoredToken() {
  return localStorage.getItem(AUTH_TOKEN_KEY)
}

export function setStoredToken(token: string) {
  localStorage.setItem(AUTH_TOKEN_KEY, token)
}

export function clearStoredToken() {
  localStorage.removeItem(AUTH_TOKEN_KEY)
}
