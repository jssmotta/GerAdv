"use client";
import { ProDespesasApi } from "../Apis/ApiProDespesas";
import { IProDespesas } from "../Interfaces/interface.ProDespesas";
import { FilterProDespesas } from "../Filters/ProDespesas";

  export interface IProDespesasService {
    fetchProDespesasById: (id: number) => Promise<IProDespesas>;
    saveProDespesas: (prodespesas: IProDespesas) => Promise<IProDespesas>;
    
  }
  
  export class ProDespesasService implements IProDespesasService {
    constructor(private api: ProDespesasApi) {}
  
    async fetchProDespesasById(id: number): Promise<IProDespesas> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveProDespesas(prodespesas: IProDespesas): Promise<IProDespesas> {
      const response = await this.api.addAndUpdate(prodespesas as IProDespesas);
      return response.data;
    }
 
   async getAll(filtro?: FilterProDespesas): Promise<IProDespesas[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching prodespesas:', error);
      return [];
    }
  }

  }