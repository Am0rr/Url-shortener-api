import { Component, OnInit, computed, inject, signal } from '@angular/core';
import { DatePipe } from '@angular/common';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';
import { ShortUrlService } from '../../../core/services/short-url.service';

@Component({
  selector: 'app-short-urls-table',
  imports: [ReactiveFormsModule, RouterLink, DatePipe],
  templateUrl: './short-urls-table.component.html',
  styleUrl: './short-urls-table.component.scss',
})
export class ShortUrlsTableComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly shortUrlService = inject(ShortUrlService);
  private readonly authService = inject(AuthService);

  readonly urls = this.shortUrlService.urls;
  readonly loading = this.shortUrlService.loading;
  readonly isAuthenticated = this.authService.isAuthenticated;
  readonly isAdmin = this.authService.isAdmin;
  readonly currentUserEmail = computed(() => this.authService.currentUser()?.email);

  readonly submitting = signal(false);
  readonly formError = signal<string | null>(null);
  readonly deletingId = signal<number | null>(null);

  readonly form = this.fb.nonNullable.group({
    originalUrl: ['', [Validators.required, Validators.pattern(/^https?:\/\/.+/i)]],
  });

  ngOnInit(): void {
    this.shortUrlService.loadAll();
  }

  canDelete(createdByEmail: string): boolean {
    return this.isAdmin() || this.currentUserEmail() === createdByEmail;
  }

  submit(): void {
    if (this.form.invalid || this.submitting()) {
      this.form.markAllAsTouched();
      return;
    }

    this.submitting.set(true);
    this.formError.set(null);

    this.shortUrlService.create(this.form.getRawValue()).subscribe({
      next: () => {
        this.form.reset();
        this.submitting.set(false);
      },
      error: (err: Error) => {
        this.formError.set(err.message);
        this.submitting.set(false);
      },
    });
  }

  remove(id: number): void {
    if (!confirm('Delete this URL?')) return;

    this.deletingId.set(id);
    this.shortUrlService.delete(id).subscribe({
      next: () => this.deletingId.set(null),
      error: () => this.deletingId.set(null),
    });
  }
}
