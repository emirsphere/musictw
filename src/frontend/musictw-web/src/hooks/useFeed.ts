import { useEffect, useState } from 'react'
import { useAuth } from './useAuth'
import { feedApi } from '../services/api/feed-api'
import type { FeedItem } from '../types/api'

export function useFeed() {
  const { token } = useAuth()
  const [items, setItems] = useState<FeedItem[]>([])
  const [isLoading, setIsLoading] = useState(true)
  const [error, setError] = useState<string | null>(null)

  useEffect(() => {
    let active = true

    async function loadFeed() {
      try {
        setIsLoading(true)
        const data = await feedApi.getAll(token)
        if (active) {
          setItems(data)
          setError(null)
        }
      } catch (err) {
        if (active) {
          setError(err instanceof Error ? err.message : 'Akış yüklenemedi.')
        }
      } finally {
        if (active) {
          setIsLoading(false)
        }
      }
    }

    void loadFeed()

    return () => {
      active = false
    }
  }, [token])

  return { items, isLoading, error }
}
