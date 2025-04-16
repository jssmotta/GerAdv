"use client";
import { PrecatoriaApi } from "../Apis/ApiPrecatoria";
import { IPrecatoria } from "../Interfaces/interface.Precatoria";
import { FilterPrecatoria } from "../Filters/Precatoria";

  export interface IPrecatoriaService {
    fetchPrecatoriaById: (id: number) => Promise<IPrecatoria>;
    savePrecatoria: (precatoria: IPrecatoria) => Promise<IPrecatoria>;
    
  }
  
  export class PrecatoriaService implements IPrecatoriaService {
    constructor(private api: PrecatoriaApi) {}
  
    async fetchPrecatoriaById(id: number): Promise<IPrecatoria> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async savePrecatoria(precatoria: IPrecatoria): Promise<IPrecatoria> {
      const response = await this.api.addAndUpdate(precatoria as IPrecatoria);
      return response.data;
    }
 
   async getAll(filtro?: FilterPrecatoria): Promise<IPrecatoria[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching precatoria:', error);
      return [];
    }
  }

  }