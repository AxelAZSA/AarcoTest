import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { PostalService } from '../postal.service';
import { Catalogo } from '../Interface/PostalResponse';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-postal-modal',
  standalone: true,
  imports: [CommonModule,ReactiveFormsModule,RouterModule]  ,
  templateUrl: './postal-modal.component.html',
})
export class PostalModalComponent implements OnInit {
  postalForm!: FormGroup;

  @Output() close = new EventEmitter<void>();

  constructor(private fb: FormBuilder, private postalService: PostalService) {}

  ngOnInit(): void {
    this.postalForm = this.fb.group({
      codigoPostal: ['', [Validators.required, Validators.pattern('^[0-9]*$')]],
      estado: [{ value: '', disabled: true }],
      municipio: [{ value: '', disabled: true }],
      colonia: [''],
    });
  }

  onCodigoPostalChange(): void {
    const codigoPostal = this.postalForm.value.codigoPostal;

    if (codigoPostal.length === 5) {
      this.postalService.get(codigoPostal).subscribe(
        (data) => {
          if (data.CatalogoJsonString) {
            const catalogos: Catalogo[] = JSON.parse(data.CatalogoJsonString);

            // Llenar el formulario con los datos
            const estado = catalogos[0]?.Municipio?.Estado?.sEstado || '';
            const municipio = catalogos[0]?.Municipio?.sMunicipio || '';
            const colonia = catalogos[0]?.Ubicacion[0]?.sUbicacion || '';

            this.postalForm.patchValue({
              estado,
              municipio,
              colonia,
            });
          }
        },
        () => {
          // Reiniciar campos si ocurre un error
          this.resetFields();
        }
      );
    } else {
      // Reiniciar campos si el código postal no tiene longitud 5
      this.resetFields();
    }
  }

  resetFields(): void {
    this.postalForm.patchValue({
      estado: '',
      municipio: '',
      colonia: '',
    });
  }

  closeModal(): void {
    this.close.emit();
  }
}
