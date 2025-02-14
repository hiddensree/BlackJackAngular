import { Component, inject } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  accountService = inject(AccountService)
  model = {};

  logout(){
    this.accountService.logout();
    console.log("Logged out successfully")
  }
}
