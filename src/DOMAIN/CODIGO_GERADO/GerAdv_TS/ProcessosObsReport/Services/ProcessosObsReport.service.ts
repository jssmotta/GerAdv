"use client";
import { ProcessosObsReportApi } from "../Apis/ApiProcessosObsReport";
import { IProcessosObsReport } from "../Interfaces/interface.ProcessosObsReport";
import { FilterProcessosObsReport } from "../Filters/ProcessosObsReport";

  export interface IProcessosObsReportService {
    fetchProcessosObsReportById: (id: number) => Promise<IProcessosObsReport>;
    saveProcessosObsReport: (processosobsreport: IProcessosObsReport) => Promise<IProcessosObsReport>;
    
  }
  
  export class ProcessosObsReportService implements IProcessosObsReportService {
    constructor(private api: ProcessosObsReportApi) {}
  
    async fetchProcessosObsReportById(id: number): Promise<IProcessosObsReport> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveProcessosObsReport(processosobsreport: IProcessosObsReport): Promise<IProcessosObsReport> {
      const response = await this.api.addAndUpdate(processosobsreport as IProcessosObsReport);
      return response.data;
    }
 
   async getAll(filtro?: FilterProcessosObsReport): Promise<IProcessosObsReport[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching processosobsreport:', error);
      return [];
    }
  }

  }