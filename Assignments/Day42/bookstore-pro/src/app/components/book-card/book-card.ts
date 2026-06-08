import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Book } from '../../models/book.model';
import { DiscountPipe } from '../../pipes/discount-pipe';

@Component({
  selector: 'app-book-card',
  imports: [CommonModule, DiscountPipe],
  templateUrl: './book-card.html',
  styleUrl: './book-card.css'
})
export class BookCard {

  @Input() book!: Book;

}