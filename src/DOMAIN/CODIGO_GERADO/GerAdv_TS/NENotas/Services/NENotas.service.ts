"use client";
import { NENotasApi } from "../Apis/ApiNENotas";
import { INENotas } from "../Interfaces/interface.NENotas";
import { FilterNENotas } from "../Filters/NENotas";

  export interface INENotasService {
    fetchNENotasById: (id: number) => Promise<INENotas>;
    saveNENotas: (nenotas: INENotas) => Promise<INENotas>;
    getList: (filtro?: FilterNENotas) => Promise<INENotas[]>;
  }
  
  export class NENotasService implements INENotasService {
    constructor(private api: NENotasApi) {}
  
    async fetchNENotasById(id: number): Promise<INENotas> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveNENotas(nenotas: INENotas): Promise<INENotas> {
      const response = await this.api.addAndUpdate(nenotas as INENotas);
      return response.data;
    }
 
   async getList(filtro?: FilterNENotas): Promise<INENotas[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching nenotas:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterNENotas): Promise<INENotas[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching nenotas:', error);
      return [];
    }
  }

  }