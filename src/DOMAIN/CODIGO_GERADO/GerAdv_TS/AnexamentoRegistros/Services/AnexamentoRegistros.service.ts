"use client";
import { AnexamentoRegistrosApi } from "../Apis/ApiAnexamentoRegistros";
import { IAnexamentoRegistros } from "../Interfaces/interface.AnexamentoRegistros";
import { FilterAnexamentoRegistros } from "../Filters/AnexamentoRegistros";

  export interface IAnexamentoRegistrosService {
    fetchAnexamentoRegistrosById: (id: number) => Promise<IAnexamentoRegistros>;
    saveAnexamentoRegistros: (anexamentoregistros: IAnexamentoRegistros) => Promise<IAnexamentoRegistros>;
    
  }
  
  export class AnexamentoRegistrosService implements IAnexamentoRegistrosService {
    constructor(private api: AnexamentoRegistrosApi) {}
  
    async fetchAnexamentoRegistrosById(id: number): Promise<IAnexamentoRegistros> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveAnexamentoRegistros(anexamentoregistros: IAnexamentoRegistros): Promise<IAnexamentoRegistros> {
      const response = await this.api.addAndUpdate(anexamentoregistros as IAnexamentoRegistros);
      return response.data;
    }
 
   async getAll(filtro?: FilterAnexamentoRegistros): Promise<IAnexamentoRegistros[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching anexamentoregistros:', error);
      return [];
    }
  }

  }