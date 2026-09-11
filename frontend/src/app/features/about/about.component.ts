import { Component, OnInit, inject, signal } from '@angular/core';
import { DatePipe } from '@angular/common';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../../core/services/auth.service';
import { AboutService } from '../../core/services/about.service';

@Component({
  selector: 'app-about',
  imports: [ReactiveFormsModule, DatePipe],
  templateUrl: './about.component.html',
  styleUrl: './about.component.scss',
})
export class AboutComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly aboutService = inject(AboutService);
  private readonly authService = inject(AuthService);

  readonly content = this.aboutService.content;
  readonly isAdmin = this.authService.isAdmin;

  readonly editing = signal(false);
  readonly submitting = signal(false);
  readonly errorMessage = signal<string | null>(null);

  readonly form = this.fb.nonNullable.group({
    text: ['', Validators.required],
  });

  ngOnInit(): void {
    this.aboutService.load().subscribe();
  }

  startEdit(): void {
    this.form.setValue({ text: this.content()?.text ?? '' });
    this.editing.set(true);
  }

  cancelEdit(): void {
    this.editing.set(false);
    this.errorMessage.set(null);
  }

  save(): void {
    if (this.form.invalid || this.submitting()) return;

    this.submitting.set(true);
    this.errorMessage.set(null);

    this.aboutService.update(this.form.getRawValue()).subscribe({
      next: () => {
        this.submitting.set(false);
        this.editing.set(false);
      },
      error: (err: Error) => {
        this.errorMessage.set(err.message);
        this.submitting.set(false);
      },
    });
  }
}
