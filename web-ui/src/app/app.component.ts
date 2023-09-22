import { Component, OnInit } from '@angular/core';
import { InsuranceService } from './services/insurance.service';
import { ReportInsurance } from './models/report-insurance';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'web-ui';
  report: ReportInsurance | undefined;
  displayedColumns: string[] = ['insuranceId', 'name', 'vehicle', 'vehiclePrize', 'insurancePrize'];
  dataSource: any=[];

  constructor(private insuranceService: InsuranceService) {
      
  }
  ngOnInit(): void {
    this.insuranceService.GetInsurance()
    .subscribe(result => 
      {
        this.report=result;
        this.dataSource=this.report.insurances;
      });
  }
}
