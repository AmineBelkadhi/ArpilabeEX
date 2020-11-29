/*import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PersonneDataModel } from '../app/Models/personne.datamodel';

@Injectable({
  providedIn: 'root'
})

export class PersonneService {
  appUrl: string;
  apiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  }

  constructor(private httpObj: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    this.appUrl = _baseUrl;
    this.apiUrl = 'api/Personne/';
  }

  getAllPersonnes(): Observable<PersonneDataModel> {
    return this.httpObj.get<PersonneDataModel>(this.appUrl + this.apiUrl);
  }

  getPersonne(id: number): Observable<PersonneDataModel> {
    return this.httpObj.get<PersonneDataModel>(this.appUrl + this.apiUrl + id).pipe()
             
  }

  createPersonne(personne): Observable<PersonneDataModel> {
    return this.httpObj.post<PersonneDataModel>(this.appUrl+this.apiUrl, JSON.stringify(personne), this.httpOptions).pipe()
  }

  deletePersonne(id: number): Observable<PersonneDataModel> {
    return this.httpObj.delete<PersonneDataModel>(this.appUrl + this.apiUrl + id).pipe()
      
  }

  updatePersonne(id: number, personne): Observable<PersonneDataModel> {
    return this.httpObj.put<PersonneDataModel>(this.appUrl + this.apiUrl + id, JSON.stringify(personne), this.httpOptions).pipe()
      
  }



}*/

