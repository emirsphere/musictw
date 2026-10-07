import { Music4 } from 'lucide-react'
import { useState } from 'react'
import type { SongListItem } from '../../types/api'
import { formatDuration } from '../../utils/formatters'

type MusicCardProps = {
  song: SongListItem
  interactive?: boolean
  selected?: boolean
  onClick?: () => void
  compact?: boolean
}

export function MusicCard({
  song,
  interactive = false,
  selected = false,
  onClick,
  compact = false,
}: MusicCardProps) {
  const [hasImageError, setHasImageError] = useState(false)

  return (
    <div
      className={[
        'music-card',
        interactive ? 'music-card--interactive' : '',
        selected ? 'music-card--selected' : '',
        compact ? 'music-card--compact' : '',
      ]
        .filter(Boolean)
        .join(' ')}
      onClick={onClick}
      role={interactive ? 'button' : undefined}
      tabIndex={interactive ? 0 : undefined}
      aria-label={interactive ? `${song.title} şarkısını seç` : undefined}
      onKeyDown={(event) => {
        if (interactive && (event.key === 'Enter' || event.key === ' ')) {
          event.preventDefault()
          onClick?.()
        }
      }}
    >
      <div className="music-card__cover">
        {!song.coverImageUrl || hasImageError ? (
          <div className="music-card__cover-fallback">
            <Music4 size={compact ? 22 : 26} />
          </div>
        ) : (
          <img
            src={song.coverImageUrl}
            alt={`${song.title} cover`}
            onError={() => setHasImageError(true)}
          />
        )}
      </div>
      <div className="music-card__body">
        <h3 className="music-card__title">{song.title}</h3>
        <p className="music-card__artist">{song.artist}</p>
        {song.album ? <p className="music-card__album">{song.album}</p> : null}
        <div className="music-card__meta">
          <span className="pill">{formatDuration(song.duration)}</span>
        </div>
      </div>
    </div>
  )
}
