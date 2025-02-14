import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { Player } from '../_models/player';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private http = inject(HttpClient)
  baseUrl = 'http://localhost:8000/api/';
  currentPlayer = signal<Player | null>(null) // initial value

  login(model: any){
    return this.http.post<Player>(this.baseUrl + 'account/login', model).pipe( // signal set up
      map(player => {
        if (player){
          localStorage.setItem('player', JSON.stringify(player));
          this.currentPlayer.set(player);
        }
      })
    )
  }
  
  logout(){
    localStorage.removeItem('player');
    this.currentPlayer.set(null);
  }
}
