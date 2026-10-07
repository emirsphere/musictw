import type { FeedItem } from '../../types/api'
import { apiFetch } from './client'

export const feedApi = {
  getAll: (token?: string | null) =>
    apiFetch<FeedItem[]>('/api/feed', {
      method: 'GET',
      token: token ?? undefined,
    }),
}
