import { HttpClient } from '@angular/common/http';
import { Injectable, inject, signal } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { API_BASE_URL } from '../../app.config';
import { AboutContentResponse, UpdateAboutContentRequest } from '../models/about.models';

@Injectable({ providedIn: 'root' })
export class AboutService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${API_BASE_URL}/aboutcontents`;

  private readonly _content = signal<AboutContentResponse | null>(null);
  readonly content = this._content.asReadonly();

  load(): Observable<AboutContentResponse> {
    return this.http.get<AboutContentResponse>(this.baseUrl).pipe(tap((c) => this._content.set(c)));
  }

  update(request: UpdateAboutContentRequest): Observable<AboutContentResponse> {
    return this.http.put<AboutContentResponse>(this.baseUrl, request).pipe(tap((c) => this._content.set(c)));
  }
}
