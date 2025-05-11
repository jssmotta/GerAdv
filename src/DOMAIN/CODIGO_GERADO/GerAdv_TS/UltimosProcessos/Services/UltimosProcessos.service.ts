"use client";
import { UltimosProcessosApi } from "../Apis/ApiUltimosProcessos";
import { IUltimosProcessos } from "../Interfaces/interface.UltimosProcessos";
import { FilterUltimosProcessos } from "../Filters/UltimosProcessos";

  export interface IUltimosProcessosService {
    fetchUltimosProcessosById: (id: number) => Promise<IUltimosProcessos>;
    saveUltimosProcessos: (ultimosprocessos: IUltimosProcessos) => Promise<IUltimosProcessos>;
    
  }
  
  export class UltimosProcessosService implements IUltimosProcessosService {
    constructor(private api: UltimosProcessosApi) {}
  
    async fetchUltimosProcessosById(id: number): Promise<IUltimosProcessos> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveUltimosProcessos(ultimosprocessos: IUltimosProcessos): Promise<IUltimosProcessos> {
      const response = await this.api.addAndUpdate(ultimosprocessos as IUltimosProcessos);
      return response.data;
    }
 
   async getAll(filtro?: FilterUltimosProcessos): Promise<IUltimosProcessos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching ultimosprocessos:', error);
      return [];
    }
  }

  }