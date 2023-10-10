import { Injectable } from '@angular/core';
import { environment } from './enviroments';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root',
})
export class BackendService {
  constructor(private http: HttpClient) {}

  gatAllBoxes(): Observable<any> {
    const url = environment.backendapi + '/api/boxes';
    return this.http.get<any[]>(url);
  }

  gatBoxByID(id: number): Observable<any> {
    const url = environment.backendapi + '/api/box/' + id;
    return this.http.get<any>(url);
  }

  removeBoxByID(id: number): Observable<any> {
    const url = environment.backendapi + '/api/DeleteBox/' + id;
    return this.http.delete<any>(url);
  }

  editBoxByID(id: number, name: string, category: string): Observable<any> {
    const url = environment.backendapi + '/api/UpdateBox/' + id;
    return this.http.put<any>(url, {
      BoxName: name,
      BoxCategory: category,
    });
  }

  createBox(name: string,  category: string): Observable<any> {
    const url = environment.backendapi + '/api/NewBox"';
    return this.http.post<any>(url, {
      BoxName: name,
      BoxCategory: category,
    });

  }



  }

