"use client";
import { NECompromissosApi } from "../Apis/ApiNECompromissos";
import { INECompromissos } from "../Interfaces/interface.NECompromissos";
import { FilterNECompromissos } from "../Filters/NECompromissos";

  export interface INECompromissosService {
    fetchNECompromissosById: (id: number) => Promise<INECompromissos>;
    saveNECompromissos: (necompromissos: INECompromissos) => Promise<INECompromissos>;
    
  }
  
  export class NECompromissosService implements INECompromissosService {
    constructor(private api: NECompromissosApi) {}
  
    async fetchNECompromissosById(id: number): Promise<INECompromissos> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveNECompromissos(necompromissos: INECompromissos): Promise<INECompromissos> {
      const response = await this.api.addAndUpdate(necompromissos as INECompromissos);
      return response.data;
    }
 
   async getAll(filtro?: FilterNECompromissos): Promise<INECompromissos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching necompromissos:', error);
      return [];
    }
  }

  }