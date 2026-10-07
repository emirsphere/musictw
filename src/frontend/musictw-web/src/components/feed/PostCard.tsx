import {
  EllipsisVertical,
  Heart,
  MessageCircle,
  Send,
  Share2,
} from 'lucide-react'
import { useEffect, useState } from 'react'
import { Link, useNavigate } from 'react-router-dom'
import { useAuth } from '../../hooks/useAuth'
import { likesApi } from '../../services/api/likes-api'
import type { FeedItem, SongListItem } from '../../types/api'
import { formatRelativeTime, getInitials } from '../../utils/formatters'
import { MusicCard } from '../songs/MusicCard'

type PostCardProps = {
  item: FeedItem
  commentCountOverride?: number
  compact?: boolean
}

export function PostCard({ item, commentCountOverride, compact = false }: PostCardProps) {
  const navigate = useNavigate()
  const { token } = useAuth()
  const [isLiked, setIsLiked] = useState(item.isLikedByCurrentUser)
  const [likeCount, setLikeCount] = useState(item.likeCount)
  const [isLikeSubmitting, setIsLikeSubmitting] = useState(false)

  useEffect(() => {
    setIsLiked(item.isLikedByCurrentUser)
    setLikeCount(item.likeCount)
  }, [item.isLikedByCurrentUser, item.likeCount, item.postId])

  const effectiveCommentCount = commentCountOverride ?? item.commentCount
  const song: SongListItem = {
    id: item.songId,
    title: item.songTitle,
    artist: item.songArtist,
    album: null,
    coverImageUrl: item.songCoverImageUrl,
    duration: item.songDuration,
  }

  async function handleToggleLike() {
    if (!token || isLikeSubmitting) {
      return
    }

    try {
      setIsLikeSubmitting(true)
      const response = await likesApi.toggle(item.postId, token)
      setLikeCount(response.likeCount)
      setIsLiked(response.isLikedByCurrentUser)
    } catch {
      // MVP akışını sakin tut; hata yüzeyi sonra genişletilebilir.
    } finally {
      setIsLikeSubmitting(false)
    }
  }

  return (
    <article className={`post-card${compact ? ' post-card--compact' : ''}`}>
      <div className="post-card__header">
        <div className={`avatar${compact ? ' avatar--compact' : ''}`}>
          {item.avatarUrl ? (
            <img src={item.avatarUrl} alt={item.userName} />
          ) : (
            <span>{getInitials(item.userName)}</span>
          )}
        </div>
        <div className="post-card__meta">
          <Link className="post-card__user-link" to={`/profiles/${item.userId}`}>
            <span className="post-card__user">{item.userName}</span>
          </Link>
          <span className="post-card__time">{formatRelativeTime(item.createdAt)}</span>
        </div>
        <button className="icon-button" type="button" aria-label="Post seçenekleri">
          <EllipsisVertical size={18} />
        </button>
      </div>

      <p className="post-card__content">{item.content}</p>

      <MusicCard song={song} compact={compact} />

      <div className="post-card__stats">
        <span>{likeCount} beğeni</span>
        <span>{effectiveCommentCount} yorum</span>
      </div>

      <div className="post-card__actions">
        <div className="action-row">
          <button
            className={`icon-button${isLiked ? ' icon-button--active icon-button--liked' : ''}`}
            type="button"
            aria-label="Beğen"
            onClick={handleToggleLike}
            disabled={isLikeSubmitting}
          >
            <Heart size={18} />
          </button>
          <button
            className="icon-button"
            type="button"
            aria-label="Yorumlar"
            onClick={() => navigate(`/posts/${item.postId}`)}
          >
            <MessageCircle size={18} />
          </button>
          <button className="icon-button" type="button" aria-label="Paylaş">
            <Share2 size={18} />
          </button>
        </div>
        <button className="icon-button" type="button" aria-label="Gönder">
          <Send size={18} />
        </button>
      </div>
    </article>
  )
}
