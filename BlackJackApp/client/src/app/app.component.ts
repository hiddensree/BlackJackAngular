import { Component, inject, OnInit } from '@angular/core';
import { NavComponent } from "./nav/nav.component";
import { AccountService } from './_services/account.service';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [NavComponent, RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent implements OnInit {
  title = 'BlackJackGame';
  private accountService = inject(AccountService);
  loginMode =false;

  ngOnInit(): void {
    this.setCurrentUser();
  }

  setCurrentUser(){
    const playerString = localStorage.getItem('player')
    if (!playerString) return;
    const player = JSON.parse(playerString);
    this.accountService.currentPlayer.set(player) // setting !! 
  }
  
}