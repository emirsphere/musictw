import { AudioLines } from 'lucide-react'
import { AppLayout } from '../../components/common/AppLayout'
import { EmptyState } from '../../components/common/EmptyState'
import { LoadingState } from '../../components/common/LoadingState'
import { PostCard } from '../../components/feed/PostCard'
import { useFeed } from '../../hooks/useFeed'

export function FeedPage() {
  const { items, isLoading, error } = useFeed()

  return (
    <AppLayout
      title="Akış"
      subtitle="Müzik odaklı sosyal akış"
      trailing={<AudioLines size={18} />}
      contentClassName="screen-content--feed"
    >
      <div className="feed-screen">
        {error ? <div className="status-banner">{error}</div> : null}
        <div className="feed-scroll">
          {isLoading ? (
            <LoadingState label="Akış yükleniyor..." />
          ) : items.length === 0 ? (
            <EmptyState
              eyebrow="Akış şu an sakin"
              title="Henüz paylaşım yok"
              description="İlk postu oluştur ve müzik kartını akışa bırak."
            />
          ) : (
            <div className="post-list">
              {items.map((item) => (
                <PostCard key={item.postId} item={item} />
              ))}
            </div>
          )}
        </div>
      </div>
    </AppLayout>
  )
}
