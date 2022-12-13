import { Injectable } from '@angular/core';
import { Observable, Subscriber } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConverterService {
  imagesBase64:string[] = [];
  constructor() { }
  convertToBase64(files:File){
    const observe = new Observable((subscriber: Subscriber<any>)=>{
      this.readFile(files, subscriber);
    });

    observe.subscribe((d)=>{
      this.imagesBase64.push(d);
    });
  }

  readFile(file:File, subscriber: Subscriber<any>){
    const fileReader = new FileReader();
    fileReader.readAsDataURL(file);
    fileReader.onload = ()=>{
      subscriber.next(fileReader.result);
      subscriber.complete();
    }
    fileReader.onerror = ()=>{
      subscriber.error();
      subscriber.complete();
    }
    fileReader.onloadend = ()=>{
      subscriber.unsubscribe();
    }
  }
}
