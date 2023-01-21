import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PersonalService {
  baseApiUrl: string =environment.apiUrl;
  constructor(private http:HttpClient) { }
  
  delete(id:any){
    return this.http.delete(this.baseApiUrl+'/api/Personal/Delete/'+id);
  }

  getAll(){
    return this.http.get(this.baseApiUrl+'/api/Personal/GetPersonal');
  }

  getAllSkill(){
    return this.http.get(this.baseApiUrl+'/api/Personal/GetAllSkill');
  }

  getAllCountry(){
    return this.http.get(this.baseApiUrl+'/api/Personal/GetAllCountry');
  }

  getAllCity(id:number){
    return this.http.get(this.baseApiUrl+'/api/Personal/GetAllCity/'+id);
  }

  savePerson(person:any){
    
    return this.http.post(this.baseApiUrl+'/api/Personal/CreatePerson',person);
  }

}