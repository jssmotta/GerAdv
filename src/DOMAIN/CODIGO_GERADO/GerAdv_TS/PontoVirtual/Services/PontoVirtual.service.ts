"use client";
import { PontoVirtualApi } from "../Apis/ApiPontoVirtual";
import { IPontoVirtual } from "../Interfaces/interface.PontoVirtual";
import { FilterPontoVirtual } from "../Filters/PontoVirtual";

  export interface IPontoVirtualService {
    fetchPontoVirtualById: (id: number) => Promise<IPontoVirtual>;
    savePontoVirtual: (pontovirtual: IPontoVirtual) => Promise<IPontoVirtual>;
    
  }
  
  export class PontoVirtualService implements IPontoVirtualService {
    constructor(private api: PontoVirtualApi) {}
  
    async fetchPontoVirtualById(id: number): Promise<IPontoVirtual> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async savePontoVirtual(pontovirtual: IPontoVirtual): Promise<IPontoVirtual> {
      const response = await this.api.addAndUpdate(pontovirtual as IPontoVirtual);
      return response.data;
    }
 
   async getAll(filtro?: FilterPontoVirtual): Promise<IPontoVirtual[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching pontovirtual:', error);
      return [];
    }
  }

  }