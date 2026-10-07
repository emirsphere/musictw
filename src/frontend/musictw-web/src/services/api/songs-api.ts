import type { SongListItem } from '../../types/api'
import { apiFetch } from './client'

export const songsApi = {
  getCatalog: () => apiFetch<SongListItem[]>('/api/songs'),
}
