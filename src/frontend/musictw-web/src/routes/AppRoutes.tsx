import type { ReactNode } from 'react'
import { Navigate, Route, Routes } from 'react-router-dom'
import { LoadingState } from '../components/common/LoadingState'
import { useAuth } from '../hooks/useAuth'
import { LoginPage } from '../pages/auth/LoginPage'
import { RegisterPage } from '../pages/auth/RegisterPage'
import { FeedPage } from '../pages/feed/FeedPage'
import { CreatePostPage } from '../pages/posts/CreatePostPage'
import { PostDetailPage } from '../pages/posts/PostDetailPage'
import { ProfilePage } from '../pages/profiles/ProfilePage'

function ProtectedRoute({ children }: { children: ReactNode }) {
  const { isAuthenticated, isLoading } = useAuth()

  if (isLoading) {
    return (
      <div className="auth-screen">
        <div style={{ width: 'min(100%, 420px)' }}>
          <LoadingState label="Oturum hazırlanıyor..." />
        </div>
      </div>
    )
  }

  if (!isAuthenticated) {
    return <Navigate to="/login" replace />
  }

  return <>{children}</>
}

function PublicOnlyRoute({ children }: { children: ReactNode }) {
  const { isAuthenticated, isLoading } = useAuth()

  if (isLoading) {
    return (
      <div className="auth-screen">
        <div style={{ width: 'min(100%, 420px)' }}>
          <LoadingState label="Yükleniyor..." />
        </div>
      </div>
    )
  }

  if (isAuthenticated) {
    return <Navigate to="/feed" replace />
  }

  return <>{children}</>
}

export function AppRoutes() {
  const { isAuthenticated } = useAuth()

  return (
    <Routes>
      <Route
        path="/"
        element={<Navigate to={isAuthenticated ? '/feed' : '/login'} replace />}
      />
      <Route
        path="/login"
        element={
          <PublicOnlyRoute>
            <LoginPage />
          </PublicOnlyRoute>
        }
      />
      <Route
        path="/register"
        element={
          <PublicOnlyRoute>
            <RegisterPage />
          </PublicOnlyRoute>
        }
      />
      <Route
        path="/feed"
        element={
          <ProtectedRoute>
            <FeedPage />
          </ProtectedRoute>
        }
      />
      <Route
        path="/create-post"
        element={
          <ProtectedRoute>
            <CreatePostPage />
          </ProtectedRoute>
        }
      />
      <Route
        path="/posts/:postId"
        element={
          <ProtectedRoute>
            <PostDetailPage />
          </ProtectedRoute>
        }
      />
      <Route
        path="/profile"
        element={
          <ProtectedRoute>
            <ProfilePage />
          </ProtectedRoute>
        }
      />
      <Route
        path="/profiles/:userId"
        element={
          <ProtectedRoute>
            <ProfilePage />
          </ProtectedRoute>
        }
      />
      <Route path="*" element={<Navigate to="/" replace />} />
    </Routes>
  )
}
