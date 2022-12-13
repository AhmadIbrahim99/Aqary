import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";

export class RepositoryService<T extends {id:number}> {
  baseUrl:string= environment.baseUrl;
  constructor(protected http:HttpClient, private endPoint: string) { }

  get getEntities(): Observable<T[]> {
    return this.http.get<T[]>(`${this.baseUrl}${this.endPoint}`);
  }

  public getEntityById(id: number): Observable<T> {
    return this.http.get<T>(
      `${this.baseUrl}${this.endPoint}/GetById/?id=${id}`
    );
  }

  public deleteEntity(id: number): Observable<any> {
    return this.http.delete<any>(
      `${this.baseUrl}${this.endPoint}/?id=${id}`
    );
  }

  public createEntity(entity: T): Observable<any> {
    return this.http.post(`${this.baseUrl}${this.endPoint}`, entity);
  }

  public updateEntity(entity: T): Observable<any> {
    return this.http.put(`${this.baseUrl}${this.endPoint}/?id=${entity.id}`, entity);
  }
}
