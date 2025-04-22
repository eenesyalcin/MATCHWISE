import { Directive, ElementRef, HostListener, Input, Renderer2 } from '@angular/core';
import { DeleteParameters } from '../contracts/deleteParameters';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent } from '../components/base/base.component';
import { HttpClientService } from '../services/http-client.service';
import { CustomToastrService } from '../services/custom-toastr.service';
import { SpinnerType } from '../enums/spinnerType';
import { ToastrMessageType } from '../enums/toastrMessageType';
import { ToastrPosition } from '../enums/toastrPosition';
import { DeleteModalService } from '../services/delete-modal.service';

@Directive({
  selector: '[appDelete]'
})
export class DeleteDirective extends BaseComponent {

  // Silme işlemi ile ilgili parametreler HTML tarafından yakalanıyor.
  @Input('appDelete') deleteParameters!: DeleteParameters

  constructor(
    spinnerService: NgxSpinnerService,
    private elementRef: ElementRef,
    private renderer: Renderer2,
    private httpClientService: HttpClientService,
    private customToastrService: CustomToastrService,
    private deleteModalService: DeleteModalService
  ) {
    super(spinnerService);
  }

  // Burada ilk parametre hangi olay olduğunda metodun çalışması gerektiğin belirtir.
  // İkinci parametre ise metoda tıklama anında parametrelerin geçirilmesini sağlar.
  @HostListener('click', ['$event'])
  async onClick(event: MouseEvent) {

    // Olayın sadece tıkladığımız DOM nesnesinde teteiklenmesini sağlar.
    event.stopPropagation();

    // Burada DOM nesnesinden gelen parametreleri değişkenlere atıyoruz.
    const items = this.deleteParameters.items
    const id = this.deleteParameters.id
    const controller = this.deleteParameters.controller

    const msg = this.deleteParameters.confirmMessage || 'Bu kaydı silmek istediğinize emin misiniz';
    const confirmed = await this.deleteModalService.open(msg);
    if (!confirmed) {
      return;
    }

    // Burada yine sileceğimiz "tr" HTML etiketi yoksa ya da silinecek satırın bilgileri gelmediyse yine metodu sonlandırıyoruz.
    const deleteObjectRow = this.elementRef.nativeElement.closest('tr') as HTMLElement;
    if (!deleteObjectRow || !items) {
      return;
    }

    // Burada spinner kütüphanesini başlatıyoruz.
    this.showSpinner(SpinnerType.Cog);

    // Burada delete metodunu çağırıyoruz.
    this.httpClientService.delete<any>({ controller }, id).subscribe({
      // Eğer atılan silme isteği başarılıysa "next()" tetiklenecektir.
      next: () => {
        this.hideSpinner(SpinnerType.Cog);
        this.customToastrService.message("Kurum başarıyla silindi", "BAŞARILI", {
          messageType: ToastrMessageType.Success,
          position: ToastrPosition.TopRight
        });

        // Burada satırın kaybolmasını sağlayacak animasyon başlatıyoruz.
        this.renderer.setStyle(deleteObjectRow, 'transition', 'opacity 0.5s');
        this.renderer.setStyle(deleteObjectRow, 'opacity', '0');

        // Animasyon sona erdikten sonra "items" dizisinden de silme işlemi gerçekleştiriyoruz.
        deleteObjectRow.addEventListener('transitionend', () => {
          const deleteObjectId = items.findIndex(item => item.id === id);
          // Burada eğer bir satır(row) bulunmazsa sonuç "-1" döner. Eğer bulunursa daha büyük bir değer döner ve silme işlemi gerçekleştirilir.
          if (deleteObjectId > -1) {
            // Burada bulunan satırdan itibaren kaç satır(row) silineceği belirtiyoruz.
            items.splice(deleteObjectId, 1);;
          }
          // "addEventListener"a verilen nesnenin sadece bir kez çalışmasını sağlar.
        }, { once: true });
        // Eğer atılan silme isteği başarılı değilse "error()" tetiklenecektir.
      }, error: errorResponse => {
        this.hideSpinner(SpinnerType.Cog);
        this.customToastrService.message("Kurum silinirken bir hata oluştu", "HATA", {
          messageType: ToastrMessageType.Error,
          position: ToastrPosition.TopRight
        });
      }
    });
  }

}
