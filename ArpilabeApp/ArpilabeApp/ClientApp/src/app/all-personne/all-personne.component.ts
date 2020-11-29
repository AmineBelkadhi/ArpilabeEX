/*import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PersonneService } from '../../Services/personne.service';*/
/*import { PersonneDataModel } from '../Models/personne.datamodel';

@Component({
  selector: 'app-all-personne',
  templateUrl: './all-personne.component.html',
  styleUrls: ['./all-personne.component.css']
})
export class AllPersonneComponent implements OnInit {
  personnes$: Observable<PersonneDataModel>;

  constructor(private servicePersonne: PersonneService) {


  }

  ngOnInit() {
    this.loadPersonnes();
  }

  loadPersonnes() {
    this.personnes$ = this.servicePersonne.getAllPersonnes();
  }

  getAllPersonne() {
    this.servicePersonne.getAllPersonnes().subscribe(data => this.loadPersonnes());
  }

  delete(id) {
    
      this.servicePersonne.deletePersonne(id).subscribe((data) => {
        this.loadPersonnes();
      })
    }
  
}*/
