import { Component, OnInit, inject, signal } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { DatePipe } from '@angular/common';
import { ShortUrlService } from '../../../core/services/short-url.service';
import { ShortUrlResponse } from '../../../core/models/short-url.models';

@Component({
  selector: 'app-short-url-info',
  imports: [RouterLink, DatePipe],
  templateUrl: './short-url-info.component.html',
  styleUrl: './short-url-info.component.scss',
})
export class ShortUrlInfoComponent implements OnInit {
  private readonly route = inject(ActivatedRoute);
  private readonly shortUrlService = inject(ShortUrlService);

  readonly url = signal<ShortUrlResponse | null>(null);
  readonly loading = signal(true);
  readonly errorMessage = signal<string | null>(null);

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    this.shortUrlService.getById(id).subscribe({
      next: (url) => {
        this.url.set(url);
        this.loading.set(false);
      },
      error: (err: Error) => {
        this.errorMessage.set(err.message);
        this.loading.set(false);
      },
    });
  }
}
