import { useEffect, useState } from 'react'
import { songsApi } from '../services/api/songs-api'
import type { SongListItem } from '../types/api'

export function useSongs() {
  const [songs, setSongs] = useState<SongListItem[]>([])
  const [isLoading, setIsLoading] = useState(true)
  const [error, setError] = useState<string | null>(null)

  useEffect(() => {
    let active = true

    async function loadSongs() {
      try {
        setIsLoading(true)
        const data = await songsApi.getCatalog()
        if (active) {
          setSongs(data)
          setError(null)
        }
      } catch (err) {
        if (active) {
          setError(err instanceof Error ? err.message : 'Şarkılar yüklenemedi.')
        }
      } finally {
        if (active) {
          setIsLoading(false)
        }
      }
    }

    void loadSongs()

    return () => {
      active = false
    }
  }, [])

  return { songs, isLoading, error }
}
