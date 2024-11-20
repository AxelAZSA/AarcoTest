import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { PostalModalComponent } from './postal-modal/postal-modal.component';
import { HomePageComponent } from './home-page/home-page.component';

@Component({
  selector: 'app-root',
  imports: [CommonModule,RouterOutlet,RouterModule, PostalModalComponent, HomePageComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Aarco';
}
