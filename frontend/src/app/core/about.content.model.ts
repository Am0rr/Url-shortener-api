export interface AboutContentResponse {
  id: string,
  text: string,
  lastModifiedByEmail: string,
  updatedAt?: string
}

export interface UpdateAboutContentRequest {
  text: string
}
