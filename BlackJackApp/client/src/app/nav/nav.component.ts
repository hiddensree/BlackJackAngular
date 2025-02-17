import { Component, inject } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { TitleCasePipe } from '@angular/common';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [RouterLink, RouterLinkActive, TitleCasePipe],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  accountService = inject(AccountService)

  model = {};
  inLogInPage = true;

  logout() {
    this.accountService.logout();
    console.log("Logged out successfully")
    this.isLoginPageSwitched()
  }

  isLoginPageSwitched() {
    this.inLogInPage = !this.inLogInPage;
  }
}
