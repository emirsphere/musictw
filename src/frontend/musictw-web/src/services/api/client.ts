type FetchOptions = RequestInit & {
  token?: string | null
}

export class ApiError extends Error {
  status: number

  constructor(message: string, status: number) {
    super(message)
    this.name = 'ApiError'
    this.status = status
  }
}

const API_BASE_URL = import.meta.env.VITE_API_BASE_URL?.replace(/\/$/, '') ?? ''

export async function apiFetch<T>(path: string, options: FetchOptions = {}) {
  const { token, headers, ...rest } = options

  const response = await fetch(`${API_BASE_URL}${path}`, {
    ...rest,
    headers: {
      'Content-Type': 'application/json',
      ...(token ? { Authorization: `Bearer ${token}` } : {}),
      ...headers,
    },
  })

  if (!response.ok) {
    let message = 'Bir şeyler ters gitti.'

    try {
      const data = (await response.json()) as { message?: string }
      if (data.message) {
        message = data.message
      }
    } catch {
      // ignore
    }

    throw new ApiError(message, response.status)
  }

  if (response.status === 204) {
    return null as T
  }

  return (await response.json()) as T
}
