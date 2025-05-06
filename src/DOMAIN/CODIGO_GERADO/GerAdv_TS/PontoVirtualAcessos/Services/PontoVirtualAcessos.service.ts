"use client";
import { PontoVirtualAcessosApi } from "../Apis/ApiPontoVirtualAcessos";
import { IPontoVirtualAcessos } from "../Interfaces/interface.PontoVirtualAcessos";
import { FilterPontoVirtualAcessos } from "../Filters/PontoVirtualAcessos";

  export interface IPontoVirtualAcessosService {
    fetchPontoVirtualAcessosById: (id: number) => Promise<IPontoVirtualAcessos>;
    savePontoVirtualAcessos: (pontovirtualacessos: IPontoVirtualAcessos) => Promise<IPontoVirtualAcessos>;
    
  }
  
  export class PontoVirtualAcessosService implements IPontoVirtualAcessosService {
    constructor(private api: PontoVirtualAcessosApi) {}
  
    async fetchPontoVirtualAcessosById(id: number): Promise<IPontoVirtualAcessos> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async savePontoVirtualAcessos(pontovirtualacessos: IPontoVirtualAcessos): Promise<IPontoVirtualAcessos> {
      const response = await this.api.addAndUpdate(pontovirtualacessos as IPontoVirtualAcessos);
      return response.data;
    }
 
   async getAll(filtro?: FilterPontoVirtualAcessos): Promise<IPontoVirtualAcessos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching pontovirtualacessos:', error);
      return [];
    }
  }

  }