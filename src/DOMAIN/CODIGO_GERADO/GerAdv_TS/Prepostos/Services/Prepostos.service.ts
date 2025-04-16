"use client";
import { PrepostosApi } from "../Apis/ApiPrepostos";
import { IPrepostos } from "../Interfaces/interface.Prepostos";
import { FilterPrepostos } from "../Filters/Prepostos";

  export interface IPrepostosService {
    fetchPrepostosById: (id: number) => Promise<IPrepostos>;
    savePrepostos: (prepostos: IPrepostos) => Promise<IPrepostos>;
    getList: (filtro?: FilterPrepostos) => Promise<IPrepostos[]>;
  }
  
  export class PrepostosService implements IPrepostosService {
    constructor(private api: PrepostosApi) {}
  
    async fetchPrepostosById(id: number): Promise<IPrepostos> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async savePrepostos(prepostos: IPrepostos): Promise<IPrepostos> {
      const response = await this.api.addAndUpdate(prepostos as IPrepostos);
      return response.data;
    }
 
   async getList(filtro?: FilterPrepostos): Promise<IPrepostos[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching prepostos:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterPrepostos): Promise<IPrepostos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching prepostos:', error);
      return [];
    }
  }

  }