import { Injectable } from "@angular/core";
import { environment } from "./enviroments";
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs";


@Injectable({
  providedIn: 'root',
})
export class BackendService {
  constructor(private http: HttpClient) {}

  gatAllBoxes(): Observable<any> {
    const url = environment.backendapi + '/api/boxes' ;
    return this.http.get<any[]>(url);
  }

  gatBoxByID( id: number): Observable<any> {
    const url = environment.backendapi + 'mobilepos/'+ id;
    return this.http.get<any>(url);
  }

  removeBoxByID(id: number): Observable<any> {
    const url = environment.backendapi + 'mobilepos/'+ id;
    return this.http.get<any>(url);
  }

  editBoxByID(id: number): Observable<any> {
    const url = environment.backendapi + 'mobilepos/'+ id;
    return this.http.get<any>(url);
  }

  getBoxesByCategory(category: string): Observable<any> {
    const url = environment.backendapi + 'mobilepos/'+ category;
    return this.http.get<any>(url);
  }

  createBox(name: number, category: string): Observable<any> {
    const url = environment.backendapi + 'mobilepos/loyalty/activateclubproduct';
    return this.http.post<any>(url, {name: name, category: category});
  }
}
