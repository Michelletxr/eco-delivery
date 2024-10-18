import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatToolbarModule } from '@angular/material/toolbar';
import { HttpClient } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { jwtDecode } from "jwt-decode";
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css'],
  standalone: true,  // Definir o componente como standalone
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatInputModule,
    MatCardModule,
    MatToolbarModule,
    MatIconModule,
    MatFormFieldModule,
    HttpClientModule
  ],
  

})
export class LoginPageComponent {
  loginForm: FormGroup;
 
  constructor(private formBuilder: FormBuilder, private http: HttpClient,  private router: Router) {
    this.loginForm = this.formBuilder.group({
      nome: ['', [Validators.required]], // Validação do campo nome
      senha: ['', Validators.required] // Validação do campo senha
    });
  }

  onSubmit() {
    if (this.loginForm.valid) {
      const formData = this.loginForm.value;

      var apiUrl = 'http://localhost:5062/api/Authenticate'; // URL da API
      this.http.post(`${apiUrl}/login`, formData).subscribe((response: any) => {
        
        // Armazena o token JWT no localStorage
         try {
          localStorage.setItem('token', response.token);
        } catch (error) {
          console.log("erro ao tentar realizar login!")
        }

        //decoficar token
        const token = response.token;
        const decodedToken = this.decodeToken(token);
        console.log('Token decodificado:', decodedToken); 

        if (decodedToken && decodedToken.jti) {
          const id = decodedToken.jti; //Captura o valor do id do usuario no campo 'jti'
          this.router.navigate(['/dashboard', id]);
        }
        
      });
    }
  }

  decodeToken(token: string): any {
    try {
      return jwtDecode(token); // Decodifica o token
    } catch (error) {
      console.error('Erro ao decodificar o token:', error);
      return null;
    }
  }
}
