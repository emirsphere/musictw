export type AuthResponse = {
  token: string
  expiresAtUtc: string
  userId: string
  userName: string
  email: string
}

export type CurrentUser = {
  userId: string
  userName: string
  email: string
  isAuthenticated: boolean
}

export type LoginRequest = {
  email: string
  password: string
}

export type RegisterRequest = {
  userName: string
  email: string
  password: string
}

export type SongListItem = {
  id: string
  title: string
  artist: string
  album: string | null
  coverImageUrl: string | null
  duration: string
}

export type CreatePostRequest = {
  songId: string
  content: string
}

export type PostDto = {
  postId: string
  content: string
  createdAt: string
  updatedAt: string | null
  userId: string
  userName: string
  avatarUrl: string | null
  songId: string
  songTitle: string
  songArtist: string
  songCoverImageUrl: string | null
  songDuration: string
  commentCount: number
  likeCount: number
  isLikedByCurrentUser: boolean
}

export type FeedItem = PostDto

export type Comment = {
  commentId: string
  postId: string
  userId: string
  userName: string
  avatarUrl: string | null
  content: string
  createdAt: string
}

export type CreateCommentRequest = {
  content: string
}

export type LikeToggleResponse = {
  postId: string
  likeCount: number
  isLikedByCurrentUser: boolean
}

export type Profile = {
  userId: string
  userName: string
  email: string | null
  bio: string | null
  avatarUrl: string | null
  followerCount: number
  followingCount: number
  postCount: number
  isCurrentUser: boolean
  isFollowedByCurrentUser: boolean
}

export type FollowToggleResponse = {
  userId: string
  followerCount: number
  followingCount: number
  isFollowedByCurrentUser: boolean
}
