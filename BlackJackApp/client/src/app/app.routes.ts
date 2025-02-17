import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PlayerListComponent } from './players/player-list/player-list.component';
import { PlayerDetailComponent } from './players/player-detail/player-detail.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import { LoginComponent } from './login/login.component';
import { authGuard } from './_guards/auth.guard';

export const routes: Routes = [
    {path: '',component: HomeComponent},
    {
        path: '', // authguard set up
        runGuardsAndResolvers: 'always',
        canActivate: [authGuard],
        children:[
            {path: 'players',component: PlayerListComponent},
            {path: 'players/:id',component: PlayerDetailComponent},
            {path: 'lists',component: ListsComponent},
            {path: 'messages',component: MessagesComponent},
        ]
    },
    {path: 'login',component: LoginComponent},
    {path: '**',component: HomeComponent, pathMatch: 'full'},  
];
