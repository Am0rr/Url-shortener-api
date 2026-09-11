export interface ShortUrlResponse {
  id: number,
  originalUrl: string,
  shortCode: string,
  createdByEmail: string,
  createdAt: string
}

export interface CreateShortUrlRequest {
  originalUrl: string
}
