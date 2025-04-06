import { HttpHeaders } from "@angular/common/http";

export class RequestParameters{
    controller?: string;
    action?: string;
    
    headers?: HttpHeaders;
    baserUrl?: string;
    fullEndPoint?: string;
}
