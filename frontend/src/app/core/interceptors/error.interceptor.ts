import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, throwError } from 'rxjs';
import { AuthService } from '../services/auth.service';

export function extractErrorMessage(error: HttpErrorResponse): string {
  const body = error.error;

  if (typeof body === 'string' && body.trim().length > 0) {
    return body;
  }
  if (body?.message) {
    return body.message;
  }
  if (body?.title) {
    return body.title;
  }
  if (body?.errors) {
    const firstKey = Object.keys(body.errors)[0];
    const firstError = firstKey ? body.errors[firstKey]?.[0] : null;
    if (firstError) return firstError;
  }
  if (error.status === 0) {
    return "Can't reach the server. Check your connection and try again.";
  }
  return `Something went wrong (${error.status}).`;
}

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  return next(req).pipe(
    catchError((error: HttpErrorResponse) => {
      if (error.status === 401) {
        authService.logout();
        router.navigate(['/login']);
      }
      return throwError(() => new Error(extractErrorMessage(error)));
    }),
  );
};
