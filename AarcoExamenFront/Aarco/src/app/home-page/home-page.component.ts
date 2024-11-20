import { Component } from '@angular/core';
import { PostalModalComponent } from '../postal-modal/postal-modal.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home-page',
  imports: [CommonModule,PostalModalComponent],
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.css'
})
export class HomePageComponent {
  isModalOpen = false;

  profileImage = 'path/to/profile.jpg';
  userName = 'Nombre Apellido';
  userAlias = '@Alias.Emprendedor';
  imglogo = '../assets/image.png'

  openModal(): void {
    this.isModalOpen = true;
  }

  closeModal(): void {
    this.isModalOpen = false;
  }
}
