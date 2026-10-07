type LoadingStateProps = {
  label?: string
  description?: string
}

export function LoadingState({
  label = 'Yükleniyor...',
  description = 'Son içerikler hazırlanırken lütfen kısa bir an bekle.',
}: LoadingStateProps) {
  return (
    <div className="state-card loading-state">
      <div className="loading-spinner" />
      <p className="top-bar__title" style={{ margin: 0 }}>
        {label}
      </p>
      <p className="subtle">{description}</p>
    </div>
  )
}
