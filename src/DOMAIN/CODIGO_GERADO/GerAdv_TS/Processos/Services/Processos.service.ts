"use client";
import { ProcessosApi } from "../Apis/ApiProcessos";
import { IProcessos } from "../Interfaces/interface.Processos";
import { FilterProcessos } from "../Filters/Processos";

  export interface IProcessosService {
    fetchProcessosById: (id: number) => Promise<IProcessos>;
    saveProcessos: (processos: IProcessos) => Promise<IProcessos>;
    getList: (filtro?: FilterProcessos) => Promise<IProcessos[]>;
  }
  
  export class ProcessosService implements IProcessosService {
    constructor(private api: ProcessosApi) {}
  
    async fetchProcessosById(id: number): Promise<IProcessos> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveProcessos(processos: IProcessos): Promise<IProcessos> {
      const response = await this.api.addAndUpdate(processos as IProcessos);
      return response.data;
    }
 
   async getList(filtro?: FilterProcessos): Promise<IProcessos[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching processos:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterProcessos): Promise<IProcessos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching processos:', error);
      return [];
    }
  }

  }