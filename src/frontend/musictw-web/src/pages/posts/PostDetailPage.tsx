import { ArrowLeft, Heart, MessageCircleMore, Share2 } from 'lucide-react'
import { useEffect, useState } from 'react'
import { Link, useNavigate, useParams } from 'react-router-dom'
import { AppLayout } from '../../components/common/AppLayout'
import { EmptyState } from '../../components/common/EmptyState'
import { LoadingState } from '../../components/common/LoadingState'
import { MusicCard } from '../../components/songs/MusicCard'
import { useAuth } from '../../hooks/useAuth'
import { commentsApi } from '../../services/api/comments-api'
import { likesApi } from '../../services/api/likes-api'
import { postsApi } from '../../services/api/posts-api'
import type { Comment, PostDto, SongListItem } from '../../types/api'
import { formatRelativeTime, getInitials } from '../../utils/formatters'

export function PostDetailPage() {
  const navigate = useNavigate()
  const { postId } = useParams()
  const { token } = useAuth()
  const [post, setPost] = useState<PostDto | null>(null)
  const [comments, setComments] = useState<Comment[]>([])
  const [commentValue, setCommentValue] = useState('')
  const [isLoading, setIsLoading] = useState(true)
  const [isCommentSubmitting, setIsCommentSubmitting] = useState(false)
  const [isLikeSubmitting, setIsLikeSubmitting] = useState(false)
  const [error, setError] = useState<string | null>(null)

  useEffect(() => {
    let active = true

    async function loadDetail() {
      if (!postId) {
        return
      }

      try {
        setIsLoading(true)
        setError(null)
        const [postResponse, commentsResponse] = await Promise.all([
          postsApi.getById(postId, token),
          commentsApi.getByPostId(postId),
        ])

        if (active) {
          setPost(postResponse)
          setComments(commentsResponse)
        }
      } catch (err) {
        if (active) {
          setError(err instanceof Error ? err.message : 'Post detayları yüklenemedi.')
        }
      } finally {
        if (active) {
          setIsLoading(false)
        }
      }
    }

    void loadDetail()

    return () => {
      active = false
    }
  }, [postId, token])

  async function handleCreateComment(event: React.FormEvent<HTMLFormElement>) {
    event.preventDefault()

    if (!token || !postId || !commentValue.trim()) {
      return
    }

    try {
      setError(null)
      setIsCommentSubmitting(true)
      const response = await commentsApi.create(
        postId,
        { content: commentValue.trim() },
        token,
      )
      setComments((current) => [...current, response])
      setPost((current) =>
        current
          ? {
              ...current,
              commentCount: current.commentCount + 1,
            }
          : current,
      )
      setCommentValue('')
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Yorum gönderilemedi.')
    } finally {
      setIsCommentSubmitting(false)
    }
  }

  async function handleToggleLike() {
    if (!token || !post || isLikeSubmitting) {
      return
    }

    try {
      setIsLikeSubmitting(true)
      const response = await likesApi.toggle(post.postId, token)
      setPost((current) =>
        current
          ? {
              ...current,
              likeCount: response.likeCount,
              isLikedByCurrentUser: response.isLikedByCurrentUser,
            }
          : current,
      )
    } finally {
      setIsLikeSubmitting(false)
    }
  }

  return (
    <AppLayout
      title="Post Detayı"
      subtitle="Yorumlar ve etkileşimler"
      trailing={
        <button
          className="top-bar__icon-button"
          type="button"
          aria-label="Geri dön"
          onClick={() => navigate(-1)}
        >
          <ArrowLeft size={18} />
        </button>
      }
      contentClassName="screen-content--detail"
    >
      {error ? <div className="status-banner">{error}</div> : null}
      {isLoading ? (
        <LoadingState label="Post detayları yükleniyor..." />
      ) : !post ? (
        <EmptyState
          eyebrow="Detay bulunamadı"
          title="Post bulunamadı"
          description="İstenen post detayına şu anda ulaşılamadı."
        />
      ) : (
        <div className="detail-screen">
          <div className="detail-scroll">
            <article className="detail-post">
              <div className="detail-post__header">
                <div className="avatar avatar--detail">
                  {post.avatarUrl ? (
                    <img src={post.avatarUrl} alt={post.userName} />
                  ) : (
                    <span>{getInitials(post.userName)}</span>
                  )}
                </div>
                <div className="detail-post__meta">
                  <div className="detail-post__meta-line">
                    <Link className="post-card__user-link" to={`/profiles/${post.userId}`}>
                      <span className="post-card__user">{post.userName}</span>
                    </Link>
                    <span className="detail-post__time">{formatRelativeTime(post.createdAt)}</span>
                  </div>
                  <p className="detail-post__content">{post.content}</p>
                </div>
              </div>

              <MusicCard
                compact
                song={
                  {
                    id: post.songId,
                    title: post.songTitle,
                    artist: post.songArtist,
                    album: null,
                    coverImageUrl: post.songCoverImageUrl,
                    duration: post.songDuration,
                  } satisfies SongListItem
                }
              />

              <div className="detail-post__footer">
                <div className="detail-post__counts">
                  <span>{post.likeCount} beğeni</span>
                  <span>{comments.length} yorum</span>
                </div>
                <div className="detail-post__actions">
                  <button
                    className={`icon-button icon-button--small${
                      post.isLikedByCurrentUser ? ' icon-button--active icon-button--liked' : ''
                    }`}
                    type="button"
                    aria-label="Beğen"
                    onClick={handleToggleLike}
                    disabled={isLikeSubmitting}
                  >
                    <Heart size={16} />
                  </button>
                  <button
                    className="icon-button icon-button--small icon-button--static"
                    type="button"
                    aria-label="Yorum sayısı"
                  >
                    <MessageCircleMore size={16} />
                  </button>
                  <button
                    className="icon-button icon-button--small icon-button--static"
                    type="button"
                    aria-label="Paylaş"
                  >
                    <Share2 size={16} />
                  </button>
                </div>
              </div>
            </article>

            <section className="detail-comments">
              <div className="detail-comments__header">
                <div className="detail-comments__title-wrap">
                  <p className="eyebrow">Yorumlar</p>
                  <h3 className="detail-comments__title">Yorumlar</h3>
                </div>
                <span className="detail-comments__count">{comments.length}</span>
              </div>

              {comments.length === 0 ? (
                <div className="comments-empty">Henüz yorum yok. İlk yorumu sen bırak.</div>
              ) : (
                <div className="comments-list">
                  {comments.map((comment) => (
                    <article key={comment.commentId} className="comment-item">
                      <div className="avatar avatar--small">
                        {comment.avatarUrl ? (
                          <img src={comment.avatarUrl} alt={comment.userName} />
                        ) : (
                          <span>{getInitials(comment.userName)}</span>
                        )}
                      </div>
                      <div className="comment-item__body">
                        <div className="comment-item__meta">
                          <span className="comment-item__user">{comment.userName}</span>
                          <span className="comment-item__time">
                            {formatRelativeTime(comment.createdAt)}
                          </span>
                        </div>
                        <p className="comment-item__content">{comment.content}</p>
                      </div>
                    </article>
                  ))}
                </div>
              )}
            </section>
          </div>

          <form className="detail-comment-bar" onSubmit={handleCreateComment}>
            <input
              className="comment-input"
              type="text"
              placeholder="Yorumunu yaz..."
              value={commentValue}
              onChange={(event) => setCommentValue(event.target.value)}
            />
            <button
              className="comment-submit"
              type="submit"
              disabled={!commentValue.trim() || isCommentSubmitting}
            >
              {isCommentSubmitting ? '...' : 'Gönder'}
            </button>
          </form>
        </div>
      )}
    </AppLayout>
  )
}
