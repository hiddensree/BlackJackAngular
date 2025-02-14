import { Component, inject, OnInit, output } from '@angular/core';
import { RegisterComponent } from "../register/register.component";
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RegisterComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})

export class HomeComponent implements OnInit {
  http = inject(HttpClient) // Injection // before we used constructors - class approach and no constructor - main advantage of using ts.
  registerMode = false;
  registerModeStatusToApp = output<boolean>()
  players: any;

  ngOnInit(): void {
    this.getPlayers();
  }

  registerToggle(){
    this.registerMode = !this.registerMode;
  }

  cancelRegisterMode(event: boolean){
    this.registerMode = event // sets the boolean value from register component.
    this.registerModeStatusToApp.emit(event);
  }

  getPlayers() {
    // Lifecycle event // connect with API endpoint - observables - lazy by default
    this.http.get('https://localhost:8001/api/players').subscribe({
      next: response => { this.players = response },
      error: error => console.log(error),
      complete: () => console.log('Request has been completed')
    })
  }
}
