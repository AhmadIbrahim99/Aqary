import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EstateItemComponent } from './estate-item.component';

describe('EstateItemComponent', () => {
  let component: EstateItemComponent;
  let fixture: ComponentFixture<EstateItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EstateItemComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EstateItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
