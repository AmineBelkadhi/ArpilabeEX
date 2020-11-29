import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PersonneComponent } from './personne/personne.component';

const routes: Routes = [

  { path: 'personne-data', component: PersonneComponent}


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
