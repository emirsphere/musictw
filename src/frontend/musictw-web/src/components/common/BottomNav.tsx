import { House, SquarePen, UserRound } from 'lucide-react'
import { NavLink } from 'react-router-dom'
import { useAuth } from '../../hooks/useAuth'

export function BottomNav() {
  const { user } = useAuth()
  const items = [
    { to: '/feed', label: 'Akış', icon: House },
    { to: '/create-post', label: 'Paylaş', icon: SquarePen },
    { to: user ? `/profiles/${user.userId}` : '/profile', label: 'Profil', icon: UserRound },
  ]

  return (
    <nav className="bottom-nav" aria-label="Primary navigation">
      {items.map(({ to, label, icon: Icon }) => (
        <NavLink
          key={to}
          to={to}
          className={({ isActive }) =>
            `bottom-nav__link${isActive ? ' bottom-nav__link--active' : ''}`
          }
        >
          <div className="bottom-nav__link-inner">
            <Icon size={20} />
            <span>{label}</span>
          </div>
        </NavLink>
      ))}
    </nav>
  )
}
