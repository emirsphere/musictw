import type { CreatePostRequest, PostDto } from '../../types/api'
import { apiFetch } from './client'

export const postsApi = {
  getById: (postId: string, token?: string | null) =>
    apiFetch<PostDto>(`/api/posts/${postId}`, {
      method: 'GET',
      token: token ?? undefined,
    }),
  create: (payload: CreatePostRequest, token: string) =>
    apiFetch<PostDto>('/api/posts', {
      method: 'POST',
      body: JSON.stringify(payload),
      token,
    }),
}
