import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { NgSelectModule } from '@ng-select/ng-select';
import { ReactiveFormsModule } from '@angular/forms';




import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule} from '@angular/common/http';

import { AppComponent } from './app.component';
import { PersonalInfoComponent } from './Components/personal-info/personal-info.component';

@NgModule({
  declarations: [
    AppComponent,
    PersonalInfoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgSelectModule, 
    ReactiveFormsModule, 
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
