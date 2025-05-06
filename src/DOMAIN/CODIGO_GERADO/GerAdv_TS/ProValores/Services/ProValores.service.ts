"use client";
import { ProValoresApi } from "../Apis/ApiProValores";
import { IProValores } from "../Interfaces/interface.ProValores";
import { FilterProValores } from "../Filters/ProValores";

  export interface IProValoresService {
    fetchProValoresById: (id: number) => Promise<IProValores>;
    saveProValores: (provalores: IProValores) => Promise<IProValores>;
    
  }
  
  export class ProValoresService implements IProValoresService {
    constructor(private api: ProValoresApi) {}
  
    async fetchProValoresById(id: number): Promise<IProValores> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveProValores(provalores: IProValores): Promise<IProValores> {
      const response = await this.api.addAndUpdate(provalores as IProValores);
      return response.data;
    }
 
   async getAll(filtro?: FilterProValores): Promise<IProValores[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching provalores:', error);
      return [];
    }
  }

  }