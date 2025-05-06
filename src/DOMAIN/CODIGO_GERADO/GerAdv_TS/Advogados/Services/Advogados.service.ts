"use client";
import { AdvogadosApi } from "../Apis/ApiAdvogados";
import { IAdvogados } from "../Interfaces/interface.Advogados";
import { FilterAdvogados } from "../Filters/Advogados";

  export interface IAdvogadosService {
    fetchAdvogadosById: (id: number) => Promise<IAdvogados>;
    saveAdvogados: (advogados: IAdvogados) => Promise<IAdvogados>;
    getList: (filtro?: FilterAdvogados) => Promise<IAdvogados[]>;
  }
  
  export class AdvogadosService implements IAdvogadosService {
    constructor(private api: AdvogadosApi) {}
  
    async fetchAdvogadosById(id: number): Promise<IAdvogados> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveAdvogados(advogados: IAdvogados): Promise<IAdvogados> {
      const response = await this.api.addAndUpdate(advogados as IAdvogados);
      return response.data;
    }
 
   async getList(filtro?: FilterAdvogados): Promise<IAdvogados[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching advogados:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterAdvogados): Promise<IAdvogados[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching advogados:', error);
      return [];
    }
  }

  }