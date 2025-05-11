"use client";
import { ContratosApi } from "../Apis/ApiContratos";
import { IContratos } from "../Interfaces/interface.Contratos";
import { FilterContratos } from "../Filters/Contratos";

  export interface IContratosService {
    fetchContratosById: (id: number) => Promise<IContratos>;
    saveContratos: (contratos: IContratos) => Promise<IContratos>;
    
  }
  
  export class ContratosService implements IContratosService {
    constructor(private api: ContratosApi) {}
  
    async fetchContratosById(id: number): Promise<IContratos> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveContratos(contratos: IContratos): Promise<IContratos> {
      const response = await this.api.addAndUpdate(contratos as IContratos);
      return response.data;
    }
 
   async getAll(filtro?: FilterContratos): Promise<IContratos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching contratos:', error);
      return [];
    }
  }

  }