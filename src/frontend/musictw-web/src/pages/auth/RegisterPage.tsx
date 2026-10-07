import { useState } from 'react'
import { Link, Navigate, useNavigate } from 'react-router-dom'
import { AuthCard } from '../../components/auth/AuthCard'
import { useAuth } from '../../hooks/useAuth'

export function RegisterPage() {
  const navigate = useNavigate()
  const { register, isAuthenticated, isLoading } = useAuth()
  const [form, setForm] = useState({
    userName: '',
    email: '',
    password: '',
  })
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
      await register(form)
      navigate('/feed')
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Kayıt oluşturulamadı.')
    } finally {
      setSubmitting(false)
    }
  }

  return (
    <div className="auth-screen">
      <AuthCard
        eyebrow="Katıl"
        title="Yeni bir müzik sahnesi aç."
        subtitle="Profilini oluştur ve sevdiğin şarkılarla kendi akışını başlat."
        footer={
          <>
            Zaten hesabın var mı? <Link to="/login">Giriş yap</Link>
          </>
        }
      >
        <form className="auth-form" onSubmit={handleSubmit}>
          {error ? <div className="status-banner">{error}</div> : null}
          <div className="field-group">
            <label className="field-label" htmlFor="register-username">
              Kullanıcı adı
            </label>
            <input
              id="register-username"
              className="field-input"
              type="text"
              placeholder="mertcan"
              value={form.userName}
              onChange={(event) =>
                setForm((current) => ({ ...current, userName: event.target.value }))
              }
              required
            />
          </div>
          <div className="field-group">
            <label className="field-label" htmlFor="register-email">
              E-posta
            </label>
            <input
              id="register-email"
              className="field-input"
              type="email"
              placeholder="you@example.com"
              value={form.email}
              onChange={(event) =>
                setForm((current) => ({ ...current, email: event.target.value }))
              }
              required
            />
          </div>
          <div className="field-group">
            <label className="field-label" htmlFor="register-password">
              Şifre
            </label>
            <input
              id="register-password"
              className="field-input"
              type="password"
              placeholder="En az 6 karakter"
              value={form.password}
              onChange={(event) =>
                setForm((current) => ({ ...current, password: event.target.value }))
              }
              required
            />
          </div>
          <button className="primary-button" type="submit" disabled={submitting}>
            {submitting ? 'Hesap oluşturuluyor...' : 'Üye Ol'}
          </button>
        </form>
      </AuthCard>
    </div>
  )
}
