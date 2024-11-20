import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostalModalComponent } from './postal-modal.component';

describe('PostalModalComponent', () => {
  let component: PostalModalComponent;
  let fixture: ComponentFixture<PostalModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PostalModalComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PostalModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
