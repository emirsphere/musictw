type EmptyStateProps = {
  title: string
  description: string
  eyebrow?: string
}

export function EmptyState({
  title,
  description,
  eyebrow = 'Henüz burada bir şey yok',
}: EmptyStateProps) {
  return (
    <div className="state-card empty-state">
      <p className="eyebrow">{eyebrow}</p>
      <h3 className="top-bar__title">{title}</h3>
      <p className="subtle">{description}</p>
    </div>
  )
}
