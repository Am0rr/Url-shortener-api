export interface AboutContentResponse {
  id: number,
  text: string,
  lastModifiedByEmail: string,
  updatedAt?: string
}

export interface UpdateAboutContentRequest {
  text: string
}
