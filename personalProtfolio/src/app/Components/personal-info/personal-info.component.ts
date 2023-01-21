import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PersonalService } from 'src/app/personal.service';

@Component({
  selector: 'app-personal-info',
  templateUrl: './personal-info.component.html',
  styleUrls: ['./personal-info.component.css']
})
export class PersonalInfoComponent implements OnInit {
  personalForm: FormGroup;
  person:any;
  listSkill:any[]=[];
  SelectlistSkill:number[];
  listOfPerson:any[]=[];
  listOfCity:any[]=[];
  listOfCountry:any[]=[];
  country:number=0;
  city:number=0;
  filess:any;
  
  constructor(
    private _fb:FormBuilder,
    public _personalService:PersonalService,
    ) { }

  ngOnInit(): void {
    this.SelectlistSkill=new Array<number>();
    this.ceratForm();
    this.getAll();
    this.getAllSkill();
    this.getCountry();
  }

  selectFileEvent(e:any){
   this.filess=e.target.files[0];
  }

  delete(id:number){
    console.log(id);
    this._personalService.delete(id).subscribe(res=>{
      
    })
  }

  savePerson(){
    const formData:FormData = new FormData();
    formData.append('personalId',this.personalForm.value.personalId)
    formData.append('personName',this.personalForm.value.personName)
    formData.append('countryId',this.personalForm.value.countryId)
    formData.append('cityId',this.personalForm.value.cityId)
    formData.append('dateOfBirth',this.personalForm.value.dateOfBirth)
    formData.append('files',this.filess)
    for (let i = 0; i < this.personalForm.value.skills.length; i++) {
      formData.append("skills",this.personalForm.value.skills[i])
    }
    console.log(this.personalForm.value.skills,"this.personalForm.value");

    this._personalService.savePerson(formData).subscribe(res=>{
      console.log(this.personalForm.value,"this.personalForm.value");
    })
  }

  getId(e:any,id:number){
   if(e.target.checked)
   {
     this.SelectlistSkill.push(id);
   }
   else
   {
    this.SelectlistSkill=this.SelectlistSkill.filter(m=>m!=id);
   }
  }

  getAllSkill(){
    this._personalService.getAllSkill().subscribe(res=>{
      this.listSkill=res as any[];
    })
  }

  getCountry(){
    this._personalService.getAllCountry().subscribe(res=>{
      this.listOfCountry=res as any[];
    })
  }

  getCity(country:any){
    this._personalService.getAllCity(this.country).subscribe(res=>{
      this.listOfCity=res as any[];
      console.log("this.listOfCity",this.listOfCity);
    })
  }

  getAll(){
    this._personalService.getAll().subscribe(res=>{
      this.listOfPerson=res as any[];
    })
  }

  

  hasError(key): boolean {
    const field = this.personalForm.get(key)
    if (field.invalid && (field.dirty || field.touched) && field.errors) {
      return true;
    } else { return false }
  }
  ceratForm(){
  this.personalForm=this._fb.group({
    personalId:[0,[]],
    personName:[,[Validators.required]],
    countryId:[,[]],
    cityId:[,[]],
    skills:[this.SelectlistSkill,[]],
    dateOfBirth:[,[Validators.required]],
    files:[,[Validators.required]],
  })
}

get f(){
  return this.personalForm.value;
}
}
