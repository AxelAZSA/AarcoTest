import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from './enviorement';
import { PostalResponse } from './Interface/PostalResponse';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PostalService {

  private apiUrl = environment.BaseApiUrl;  // URL de tu API

  constructor(private http: HttpClient) { }

  // Obtener todas las entradas de blog
  get(codigoPostal:number): Observable<PostalResponse> {
    return this.http.get<PostalResponse>(`${this.apiUrl+codigoPostal}`);
  }
}
