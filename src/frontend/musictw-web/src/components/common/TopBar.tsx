import type { ReactNode } from 'react'

type TopBarProps = {
  title: string
  subtitle?: string
  trailing?: ReactNode
}

export function TopBar({ title, subtitle, trailing }: TopBarProps) {
  return (
    <header className="top-bar">
      <div>
        <h2 className="top-bar__title">{title}</h2>
        {subtitle ? <p className="top-bar__subtitle">{subtitle}</p> : null}
      </div>
      {trailing ? <div className="top-bar__badge">{trailing}</div> : null}
    </header>
  )
}
