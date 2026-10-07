import { Headphones } from 'lucide-react'
import type { PropsWithChildren, ReactNode } from 'react'

type AuthCardProps = PropsWithChildren<{
  eyebrow: string
  title: string
  subtitle: string
  footer?: ReactNode
}>

export function AuthCard({
  eyebrow,
  title,
  subtitle,
  footer,
  children,
}: AuthCardProps) {
  return (
    <div className="auth-card">
      <div className="auth-card__logo">
        <Headphones size={28} />
      </div>
      <div className="auth-card__header" style={{ marginTop: 18 }}>
        <p className="eyebrow">{eyebrow}</p>
        <h1 className="heading">{title}</h1>
        <p className="subtle">{subtitle}</p>
      </div>
      {children}
      {footer ? <div className="auth-switch">{footer}</div> : null}
    </div>
  )
}
