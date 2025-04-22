import { ApplicationRef, ComponentFactoryResolver, ComponentRef, EmbeddedViewRef, Injectable, Injector } from '@angular/core';
import { DeleteModalComponent } from '../components/delete-modal/delete-modal.component';

@Injectable({
  providedIn: 'root'
})
export class DeleteModalService {

  constructor(
    private resolver: ComponentFactoryResolver,
    private injector: Injector,
    private appRef: ApplicationRef
  ) { }

  open(message: string): Promise<boolean> {
    // 1. ModalComponent referansı oluştur
    const factory = this.resolver.resolveComponentFactory(DeleteModalComponent);
    const compRef = factory.create(this.injector);
    compRef.instance.message = message;

    // 2. View’ü Angular’a ekle, DOM’a yerleştir
    this.appRef.attachView(compRef.hostView);
    const dom = (compRef.hostView as EmbeddedViewRef<any>).rootNodes[0] as HTMLElement;
    document.body.appendChild(dom);

    // 3. Promise üzerinden kullanıcı cevabını döndür
    return new Promise<boolean>(resolve => {
      compRef.instance.confirm.subscribe(() => {
        resolve(true);
        this._destroy(compRef);
      });
      compRef.instance.cancel.subscribe(() => {
        resolve(false);
        this._destroy(compRef);
      });
    });
  }

  private _destroy(compRef: ComponentRef<DeleteModalComponent>) {
    this.appRef.detachView(compRef.hostView);
    compRef.destroy();
  }

}
