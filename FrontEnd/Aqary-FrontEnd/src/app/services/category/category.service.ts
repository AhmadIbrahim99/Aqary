import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICategory } from 'src/app/interfaces/ICategory/icategory';
import { environment } from 'src/environments/environment';
import { RepositoryService } from '../repository/repository.service';

@Injectable({
  providedIn: 'root'
})
export class CategoryService extends RepositoryService<ICategory> {

  constructor(http: HttpClient) {
    super(http,environment.endPoints[1]);
  }

}
