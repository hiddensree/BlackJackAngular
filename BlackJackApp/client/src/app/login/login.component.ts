import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  accountService = inject(AccountService)
  private router = inject(Router)
  private toastr = inject(ToastrService)
  model: any ={};

  login(){
    this.accountService.login(this.model).subscribe({
      next: _ => {
        this.router.navigateByUrl('/lists');
      },
      error: error => {
        this.toastr.error(error.error)
        console.log(error)
      }
    })
  }
}