import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { ReportInsurance } from "../models/report-insurance";
import { Observable, catchError, throwError, retry } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class InsuranceService {

    apiUrl='http://localhost:5246'
    httpOpt = {
        header: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    };

    constructor(private http: HttpClient) {
    }

    GetInsurance(): Observable<ReportInsurance> {
        return this.http
          .get<ReportInsurance>(this.apiUrl + '/insurances/')
          .pipe(retry(1), catchError(this.errorHandl));
      }

    errorHandl(error: any) {
        let errorMessage = '';
        if (error.error instanceof ErrorEvent) {
          errorMessage = error.error.message;
        } else {
          errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
        }
        console.log(errorMessage);
        return throwError(() => {
          return errorMessage;
        });
      }

}