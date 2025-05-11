"use client";
import { ParceriaProcApi } from "../Apis/ApiParceriaProc";
import { IParceriaProc } from "../Interfaces/interface.ParceriaProc";
import { FilterParceriaProc } from "../Filters/ParceriaProc";

  export interface IParceriaProcService {
    fetchParceriaProcById: (id: number) => Promise<IParceriaProc>;
    saveParceriaProc: (parceriaproc: IParceriaProc) => Promise<IParceriaProc>;
    
  }
  
  export class ParceriaProcService implements IParceriaProcService {
    constructor(private api: ParceriaProcApi) {}
  
    async fetchParceriaProcById(id: number): Promise<IParceriaProc> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveParceriaProc(parceriaproc: IParceriaProc): Promise<IParceriaProc> {
      const response = await this.api.addAndUpdate(parceriaproc as IParceriaProc);
      return response.data;
    }
 
   async getAll(filtro?: FilterParceriaProc): Promise<IParceriaProc[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching parceriaproc:', error);
      return [];
    }
  }

  }