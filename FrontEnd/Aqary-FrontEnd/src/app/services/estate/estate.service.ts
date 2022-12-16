import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IEstate, IEstates } from 'src/app/interfaces/iEstate/i-estate';
import { RepositoryService } from '../repository/repository.service';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class EstateService extends RepositoryService<IEstate> {
  constructor(http: HttpClient) {
    super(http, environment.endPoints[0]);
  }

  public getSortedEstates(
    page: number = 1,
    pageSize: number = 10,
    searchText: string = '',
    sortColumn: string = '',
    sortDirection: string = 'ascending'
  ): Observable<IEstates> {
    return this.http.get<IEstates>(
      `${this.baseUrl}${environment.endPoints[2]}?page=${page}&pageSize=${pageSize}&searchText=${searchText}&sortColumn=${sortColumn}&sortDirection=${sortDirection}`
    );
  }
}
