"use client";
import { ProcessosParadosApi } from "../Apis/ApiProcessosParados";
import { IProcessosParados } from "../Interfaces/interface.ProcessosParados";
import { FilterProcessosParados } from "../Filters/ProcessosParados";

  export interface IProcessosParadosService {
    fetchProcessosParadosById: (id: number) => Promise<IProcessosParados>;
    saveProcessosParados: (processosparados: IProcessosParados) => Promise<IProcessosParados>;
    
  }
  
  export class ProcessosParadosService implements IProcessosParadosService {
    constructor(private api: ProcessosParadosApi) {}
  
    async fetchProcessosParadosById(id: number): Promise<IProcessosParados> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveProcessosParados(processosparados: IProcessosParados): Promise<IProcessosParados> {
      const response = await this.api.addAndUpdate(processosparados as IProcessosParados);
      return response.data;
    }
 
   async getAll(filtro?: FilterProcessosParados): Promise<IProcessosParados[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching processosparados:', error);
      return [];
    }
  }

  }