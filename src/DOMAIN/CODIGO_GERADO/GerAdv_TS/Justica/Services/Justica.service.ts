"use client";
import { JusticaApi } from "../Apis/ApiJustica";
import { IJustica } from "../Interfaces/interface.Justica";
import { FilterJustica } from "../Filters/Justica";

  export interface IJusticaService {
    fetchJusticaById: (id: number) => Promise<IJustica>;
    saveJustica: (justica: IJustica) => Promise<IJustica>;
    getList: (filtro?: FilterJustica) => Promise<IJustica[]>;
  }
  
  export class JusticaService implements IJusticaService {
    constructor(private api: JusticaApi) {}
  
    async fetchJusticaById(id: number): Promise<IJustica> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveJustica(justica: IJustica): Promise<IJustica> {
      const response = await this.api.addAndUpdate(justica as IJustica);
      return response.data;
    }
 
   async getList(filtro?: FilterJustica): Promise<IJustica[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching justica:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterJustica): Promise<IJustica[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching justica:', error);
      return [];
    }
  }

  }