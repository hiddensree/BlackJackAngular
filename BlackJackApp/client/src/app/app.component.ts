import { Component, inject, OnInit } from '@angular/core';
import { NavComponent } from "./nav/nav.component";
import { LoginComponent } from "./login/login.component";
import { AccountService } from './_services/account.service';
import { HomeComponent } from "./home/home.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [NavComponent, HomeComponent, LoginComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent implements OnInit {
  title = 'BlackJackGame';
  private accountService = inject(AccountService);
  loginMode = false;

  ngOnInit(): void {
    this.setCurrentUser();
  }

  setLoginMode(event: boolean){
    this.loginMode = !event
  }

  setCurrentUser(){
    const playerString = localStorage.getItem('player')
    if (!playerString) return;
    const player = JSON.parse(playerString);
    this.accountService.currentPlayer.set(player) // setting !! 
  }
  
}