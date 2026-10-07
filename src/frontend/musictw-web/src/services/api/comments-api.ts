import type { Comment, CreateCommentRequest } from '../../types/api'
import { apiFetch } from './client'

export const commentsApi = {
  getByPostId: (postId: string) =>
    apiFetch<Comment[]>(`/api/posts/${postId}/comments`, {
      method: 'GET',
    }),
  create: (postId: string, payload: CreateCommentRequest, token: string) =>
    apiFetch<Comment>(`/api/posts/${postId}/comments`, {
      method: 'POST',
      body: JSON.stringify(payload),
      token,
    }),
}
