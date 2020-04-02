import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ResponseModel } from './components/response.model';
import { Observable, from } from 'rxjs';
import { switchMap } from 'rxjs/operators';
@Injectable({
    providedIn: 'root'
})
export class RecorderService {
    constructor(private http: HttpClient) {}
    public getResponse(recorded: Blob): Observable<ResponseModel> {
        return from(new Response(recorded).arrayBuffer()).pipe(
            switchMap(bytes =>
                this.http.post<ResponseModel>(
                    'https://localhost:44302/weatherforecast',
                    bytes
                )
            )
        );

        // new Response(recorded).arrayBuffer().then(bytes => {
        //     return this.http.post<ResponseModel>(
        //         'https://localhost:44302/weatherforecast',
        //         bytes
        //     );
        // });
    }
}
