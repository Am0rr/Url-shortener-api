export interface ShortUrlResponse {
  id: string,
  originalUrl: string,
  shortCode: string,
  createdByEmail: string,
  createdAt: string
}

export interface CreateShortUrlRequest {
  originalUrl: string
}
