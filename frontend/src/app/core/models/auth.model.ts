export type UserRole = 'User' | 'Administrator';

export interface AuthResponse {
  accessToken: string;
  id: number;
  email: string;
  role: UserRole;
}

export interface LoginRequest {
  email: string;
  password: string;
}
