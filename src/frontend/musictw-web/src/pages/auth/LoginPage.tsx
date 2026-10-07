import { useState } from 'react'
import { Link, Navigate, useNavigate } from 'react-router-dom'
import { AuthCard } from '../../components/auth/AuthCard'
import { useAuth } from '../../hooks/useAuth'

export function LoginPage() {
  const navigate = useNavigate()
  const { login, isAuthenticated, isLoading } = useAuth()
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const [error, setError] = useState<string | null>(null)
  const [submitting, setSubmitting] = useState(false)

  if (!isLoading && isAuthenticated) {
    return <Navigate to="/feed" replace />
  }

  async function handleSubmit(event: React.FormEvent<HTMLFormElement>) {
    event.preventDefault()

    try {
      setSubmitting(true)
      setError(null)
      await login({ email, password })
      navigate('/feed')
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Giriş yapılamadı.')
    } finally {
      setSubmitting(false)
    }
  }

  return (
    <div className="auth-screen">
      <AuthCard
        eyebrow="MusicTw"
        title="Müzik akışına geri dön."
        subtitle="Dinlediğini paylaş, yeni sesler keşfet ve akışın ritmini yeniden yakala."
        footer={
          <>
            Hesabın yok mu? <Link to="/register">Üye ol</Link>
          </>
        }
      >
        <form className="auth-form" onSubmit={handleSubmit}>
          {error ? <div className="status-banner">{error}</div> : null}
          <div className="field-group">
            <label className="field-label" htmlFor="login-email">
              E-posta
            </label>
            <input
              id="login-email"
              className="field-input"
              type="email"
              placeholder="you@example.com"
              value={email}
              onChange={(event) => setEmail(event.target.value)}
              required
            />
          </div>
          <div className="field-group">
            <label className="field-label" htmlFor="login-password">
              Şifre
            </label>
            <input
              id="login-password"
              className="field-input"
              type="password"
              placeholder="Şifreni gir"
              value={password}
              onChange={(event) => setPassword(event.target.value)}
              required
            />
          </div>
          <button className="primary-button" type="submit" disabled={submitting}>
            {submitting ? 'Giriş yapılıyor...' : 'Giriş Yap'}
          </button>
        </form>
      </AuthCard>
    </div>
  )
}
