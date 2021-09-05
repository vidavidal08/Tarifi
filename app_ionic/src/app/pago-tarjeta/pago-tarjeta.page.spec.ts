import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';

import { PagoTarjetaPage } from './pago-tarjeta.page';

describe('PagoTarjetaPage', () => {
  let component: PagoTarjetaPage;
  let fixture: ComponentFixture<PagoTarjetaPage>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ PagoTarjetaPage ],
      imports: [IonicModule.forRoot(),
        FormsModule,
        ReactiveFormsModule
      
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(PagoTarjetaPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
