import type { FeedItem, FollowToggleResponse, Profile } from '../../types/api'
import { apiFetch } from './client'

export const profilesApi = {
  getMe: (token: string) =>
    apiFetch<Profile>('/api/profiles/me', {
      method: 'GET',
      token,
    }),
  getById: (userId: string, token: string) =>
    apiFetch<Profile>(`/api/profiles/${userId}`, {
      method: 'GET',
      token,
    }),
  getPostsByUserId: (userId: string, token: string) =>
    apiFetch<FeedItem[]>(`/api/profiles/${userId}/posts`, {
      method: 'GET',
      token,
    }),
  toggleFollow: (userId: string, token: string) =>
    apiFetch<FollowToggleResponse>(`/api/profiles/${userId}/follow`, {
      method: 'POST',
      token,
    }),
}
