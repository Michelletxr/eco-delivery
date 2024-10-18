import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { NavigationEnd, Router, RouterOutlet, } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'EcoDeliveryApp';
  isLoginPage: boolean = false;

  constructor(private router: Router) {
    // Ouve eventos de navegação para verificar a rota ativa
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        // Define 'isLoginPage' como true se a rota for 'login'
        this.isLoginPage = this.router.url.includes('/login');
      }
    });
  }
}
