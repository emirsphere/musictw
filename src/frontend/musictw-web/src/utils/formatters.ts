export function formatRelativeTime(value: string) {
  const target = new Date(value)

  if (Number.isNaN(target.getTime())) {
    return ''
  }

  const diffInSeconds = Math.max(0, Math.round((Date.now() - target.getTime()) / 1000))

  if (diffInSeconds < 45) {
    return 'Az önce'
  }

  if (diffInSeconds < 3600) {
    return `${Math.max(1, Math.floor(diffInSeconds / 60))} dk`
  }

  if (diffInSeconds < 86400) {
    return `${Math.floor(diffInSeconds / 3600)} sa`
  }

  if (diffInSeconds < 604800) {
    return `${Math.floor(diffInSeconds / 86400)} g`
  }

  return new Intl.DateTimeFormat('tr-TR', {
    day: 'numeric',
    month: 'short',
  }).format(target)
}

export function formatDuration(duration: string) {
  const parts = duration.split(':')
  if (parts.length < 3) {
    return duration
  }

  const hours = Number(parts[0])
  const minutes = Number(parts[1])
  const seconds = Math.floor(Number(parts[2]))

  if (Number.isNaN(hours) || Number.isNaN(minutes) || Number.isNaN(seconds)) {
    return duration
  }

  const totalMinutes = hours * 60 + minutes
  return `${totalMinutes}:${seconds.toString().padStart(2, '0')}`
}

export function getInitials(value: string) {
  return value
    .split(' ')
    .filter(Boolean)
    .slice(0, 2)
    .map((part) => part[0]?.toUpperCase() ?? '')
    .join('')
}
