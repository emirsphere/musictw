import type { PropsWithChildren, ReactNode } from 'react'
import { BottomNav } from './BottomNav'
import { TopBar } from './TopBar'

type AppLayoutProps = PropsWithChildren<{
  title: string
  subtitle?: string
  trailing?: ReactNode
  contentClassName?: string
}>

export function AppLayout({
  title,
  subtitle,
  trailing,
  contentClassName,
  children,
}: AppLayoutProps) {
  return (
    <div className="page-shell">
      <div className="phone-frame">
        <div className="layout">
          <TopBar title={title} subtitle={subtitle} trailing={trailing} />
          <main className={['screen-content', contentClassName].filter(Boolean).join(' ')}>
            {children}
          </main>
        </div>
        <BottomNav />
      </div>
    </div>
  )
}
