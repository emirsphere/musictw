import { Sparkles } from 'lucide-react'
import { useMemo, useState } from 'react'
import { useNavigate } from 'react-router-dom'
import { AppLayout } from '../../components/common/AppLayout'
import { EmptyState } from '../../components/common/EmptyState'
import { LoadingState } from '../../components/common/LoadingState'
import { MusicCard } from '../../components/songs/MusicCard'
import { useAuth } from '../../hooks/useAuth'
import { useSongs } from '../../hooks/useSongs'
import { postsApi } from '../../services/api/posts-api'

export function CreatePostPage() {
  const navigate = useNavigate()
  const { token } = useAuth()
  const { songs, isLoading, error } = useSongs()
  const [content, setContent] = useState('')
  const [songId, setSongId] = useState('')
  const [submitting, setSubmitting] = useState(false)
  const [status, setStatus] = useState<string | null>(null)

  const selectedSong = useMemo(
    () => songs.find((song) => song.id === songId) ?? null,
    [songId, songs],
  )

  async function handleSubmit(event: React.FormEvent<HTMLFormElement>) {
    event.preventDefault()

    if (!token) {
      setStatus('Post oluşturmak için önce giriş yapman gerekiyor.')
      return
    }

    try {
      setSubmitting(true)
      setStatus(null)
      await postsApi.create(
        {
          content,
          songId,
        },
        token,
      )
      navigate('/feed')
    } catch (err) {
      setStatus(err instanceof Error ? err.message : 'Post oluşturulamadı.')
    } finally {
      setSubmitting(false)
    }
  }

  return (
    <AppLayout
      title="Yeni Post"
      subtitle="Düşünceni seçili şarkıyla birlikte paylaş"
      trailing={<Sparkles size={18} />}
      contentClassName="screen-content--composer"
    >
      <div className="composer-screen">
        <div className="composer-scroll">
          {error ? <div className="status-banner">{error}</div> : null}
          {status ? <div className="status-banner">{status}</div> : null}

          <div className="composer-card">
            <div className="page-section-header composer-card__header">
              <p className="eyebrow">Oluştur</p>
              <h3 className="top-bar__title composer-card__title">Müzikli bir post hazırla</h3>
              <p className="subtle">Önce hissini yaz, sonra ritmini belirle ve akışa bırak.</p>
            </div>

            <form className="composer-form" onSubmit={handleSubmit}>
              <div className="field-group">
                <label className="field-label" htmlFor="post-content">
                  İçerik
                </label>
                <textarea
                  id="post-content"
                  className="field-textarea"
                  placeholder="Bu şarkı bugün sana nasıl hissettirdi?"
                  value={content}
                  onChange={(event) => setContent(event.target.value)}
                  required
                />
              </div>

              <div className="field-group">
                <label className="field-label" htmlFor="song-select">
                  Şarkı seç
                </label>
                <select
                  id="song-select"
                  className="field-select"
                  value={songId}
                  onChange={(event) => setSongId(event.target.value)}
                  required
                >
                  <option value="">Katalogdan bir şarkı seç</option>
                  {songs.map((song) => (
                    <option key={song.id} value={song.id}>
                      {song.artist} - {song.title}
                    </option>
                  ))}
                </select>
                <p className="song-picker__hint">Hazır katalogdan bir şarkı seçiyorsun.</p>
              </div>

              {isLoading ? (
                <LoadingState label="Şarkılar getiriliyor..." />
              ) : selectedSong ? (
                <div className="stack composer-preview">
                  <p className="field-label" style={{ margin: 0 }}>
                    Seçilen parça
                  </p>
                  <MusicCard song={selectedSong} selected />
                </div>
              ) : songs.length === 0 ? (
                <EmptyState
                  eyebrow="Katalog boş görünüyor"
                  title="Şarkı listesi bulunamadı"
                  description="Şarkılar gelmediği için şu anda post hazırlanamadı."
                />
              ) : null}

              <button
                className="primary-button composer-submit"
                type="submit"
                disabled={submitting || !songId || !content.trim()}
              >
                {submitting ? 'Paylaşılıyor...' : 'Postu Paylaş'}
              </button>
            </form>
          </div>
        </div>
      </div>
    </AppLayout>
  )
}
