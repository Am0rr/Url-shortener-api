import { HttpClient } from '@angular/common/http';
import { Injectable, inject, signal } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { API_BASE_URL } from '../../app.config';
import { CreateShortUrlRequest, ShortUrlResponse } from '../models/short-url.models';

@Injectable({ providedIn: 'root' })
export class ShortUrlService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${API_BASE_URL}/shorturls`;

  private readonly _urls = signal<ShortUrlResponse[]>([]);
  private readonly _loading = signal(false);

  readonly urls = this._urls.asReadonly();
  readonly loading = this._loading.asReadonly();

  loadAll(): void {
    this._loading.set(true);
    this.http.get<ShortUrlResponse[]>(this.baseUrl).subscribe({
      next: (urls) => {
        this._urls.set(urls);
        this._loading.set(false);
      },
      error: () => this._loading.set(false),
    });
  }

  getById(id: number): Observable<ShortUrlResponse> {
    return this.http.get<ShortUrlResponse>(`${this.baseUrl}/${id}`);
  }

  create(request: CreateShortUrlRequest): Observable<ShortUrlResponse> {
    return this.http.post<ShortUrlResponse>(this.baseUrl, request).pipe(
      tap((created) => this._urls.update((current) => [created, ...current])),
    );
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`).pipe(
      tap(() => this._urls.update((current) => current.filter((u) => u.id !== id))),
    );
  }
}
