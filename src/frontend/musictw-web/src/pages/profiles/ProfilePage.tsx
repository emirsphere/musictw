import { UserRound } from 'lucide-react'
import { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import { AppLayout } from '../../components/common/AppLayout'
import { EmptyState } from '../../components/common/EmptyState'
import { LoadingState } from '../../components/common/LoadingState'
import { PostCard } from '../../components/feed/PostCard'
import { useAuth } from '../../hooks/useAuth'
import { profilesApi } from '../../services/api/profiles-api'
import type { FeedItem, Profile } from '../../types/api'
import { getInitials } from '../../utils/formatters'

export function ProfilePage() {
  const navigate = useNavigate()
  const { userId } = useParams()
  const { token, user } = useAuth()
  const [profile, setProfile] = useState<Profile | null>(null)
  const [posts, setPosts] = useState<FeedItem[]>([])
  const [isLoading, setIsLoading] = useState(true)
  const [error, setError] = useState<string | null>(null)
  const [isFollowSubmitting, setIsFollowSubmitting] = useState(false)

  useEffect(() => {
    let active = true

    async function loadProfile() {
      if (!token) {
        return
      }

      try {
        setIsLoading(true)
        setError(null)

        const targetUserId = userId ?? user?.userId

        if (!targetUserId) {
          navigate('/feed', { replace: true })
          return
        }

        const [profileResponse, postsResponse] = await Promise.all([
          targetUserId === user?.userId
            ? profilesApi.getMe(token)
            : profilesApi.getById(targetUserId, token),
          profilesApi.getPostsByUserId(targetUserId, token),
        ])

        if (active) {
          setProfile(profileResponse)
          setPosts(postsResponse)
        }
      } catch (err) {
        if (active) {
          setError(err instanceof Error ? err.message : 'Profil yüklenemedi.')
        }
      } finally {
        if (active) {
          setIsLoading(false)
        }
      }
    }

    void loadProfile()

    return () => {
      active = false
    }
  }, [navigate, token, user?.userId, userId])

  async function handleToggleFollow() {
    if (!token || !profile || profile.isCurrentUser || isFollowSubmitting) {
      return
    }

    try {
      setIsFollowSubmitting(true)
      const response = await profilesApi.toggleFollow(profile.userId, token)
      setProfile((current) =>
        current
          ? {
              ...current,
              followerCount: response.followerCount,
              followingCount: response.followingCount,
              isFollowedByCurrentUser: response.isFollowedByCurrentUser,
            }
          : current,
      )
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Takip durumu güncellenemedi.')
    } finally {
      setIsFollowSubmitting(false)
    }
  }

  return (
    <AppLayout
      title="Profil"
      subtitle={profile ? `@${profile.userName}` : 'Kullanıcı profili'}
      trailing={<UserRound size={18} />}
      contentClassName="screen-content--profile"
    >
      <div className="profile-screen">
        {error ? <div className="status-banner">{error}</div> : null}

        <div className="profile-scroll">
          {isLoading ? (
            <LoadingState label="Profil yükleniyor..." />
          ) : !profile ? (
            <EmptyState
              eyebrow="Profil görünmüyor"
              title="Profil bulunamadı"
              description="İstenen kullanıcıya şu anda ulaşılamadı."
            />
          ) : (
            <>
              <section className="profile-card">
                <div className="profile-card__header">
                  <div className="avatar profile-avatar">
                    {profile.avatarUrl ? (
                      <img src={profile.avatarUrl} alt={profile.userName} />
                    ) : (
                      <span>{getInitials(profile.userName)}</span>
                    )}
                  </div>
                  <div className="profile-card__identity">
                    <h3 className="profile-card__name">{profile.userName}</h3>
                    {profile.email ? <p className="profile-card__secondary">{profile.email}</p> : null}
                    <p className="profile-card__bio">
                      {profile.bio?.trim() || 'Henüz biyografi eklenmedi.'}
                    </p>
                  </div>
                </div>

                <div className="profile-stats">
                  <div className="profile-stat">
                    <strong>{profile.postCount}</strong>
                    <span>Post</span>
                  </div>
                  <div className="profile-stat">
                    <strong>{profile.followerCount}</strong>
                    <span>Takipçi</span>
                  </div>
                  <div className="profile-stat">
                    <strong>{profile.followingCount}</strong>
                    <span>Takip</span>
                  </div>
                </div>

                {profile.isCurrentUser ? (
                  <div className="profile-note">Kendi profilini görüntülüyorsun.</div>
                ) : (
                  <button
                    className={
                      profile.isFollowedByCurrentUser
                        ? 'secondary-button profile-action'
                        : 'primary-button profile-action'
                    }
                    type="button"
                    onClick={handleToggleFollow}
                    disabled={isFollowSubmitting}
                  >
                    {profile.isFollowedByCurrentUser ? 'Takibi Bırak' : 'Takip Et'}
                  </button>
                )}
              </section>

              {posts.length === 0 ? (
                <EmptyState
                  eyebrow="Profil sakin"
                  title="Henüz post yok"
                  description="Bu profilin müzik paylaşımları burada görünecek."
                />
              ) : (
                <div className="post-list">
                  {posts.map((post) => (
                    <PostCard key={post.postId} item={post} />
                  ))}
                </div>
              )}
            </>
          )}
        </div>
      </div>
    </AppLayout>
  )
}
