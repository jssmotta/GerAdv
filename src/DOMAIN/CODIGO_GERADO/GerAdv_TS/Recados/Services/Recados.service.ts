"use client";
import { RecadosApi } from "../Apis/ApiRecados";
import { IRecados } from "../Interfaces/interface.Recados";
import { FilterRecados } from "../Filters/Recados";

  export interface IRecadosService {
    fetchRecadosById: (id: number) => Promise<IRecados>;
    saveRecados: (recados: IRecados) => Promise<IRecados>;
    
  }
  
  export class RecadosService implements IRecadosService {
    constructor(private api: RecadosApi) {}
  
    async fetchRecadosById(id: number): Promise<IRecados> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveRecados(recados: IRecados): Promise<IRecados> {
      const response = await this.api.addAndUpdate(recados as IRecados);
      return response.data;
    }
 
   async getAll(filtro?: FilterRecados): Promise<IRecados[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching recados:', error);
      return [];
    }
  }

  }