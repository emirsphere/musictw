import type { LikeToggleResponse } from '../../types/api'
import { apiFetch } from './client'

export const likesApi = {
  toggle: (postId: string, token: string) =>
    apiFetch<LikeToggleResponse>(`/api/posts/${postId}/like`, {
      method: 'POST',
      token,
    }),
}
