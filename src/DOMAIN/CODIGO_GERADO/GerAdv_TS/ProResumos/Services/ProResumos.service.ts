"use client";
import { ProResumosApi } from "../Apis/ApiProResumos";
import { IProResumos } from "../Interfaces/interface.ProResumos";
import { FilterProResumos } from "../Filters/ProResumos";

  export interface IProResumosService {
    fetchProResumosById: (id: number) => Promise<IProResumos>;
    saveProResumos: (proresumos: IProResumos) => Promise<IProResumos>;
    
  }
  
  export class ProResumosService implements IProResumosService {
    constructor(private api: ProResumosApi) {}
  
    async fetchProResumosById(id: number): Promise<IProResumos> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveProResumos(proresumos: IProResumos): Promise<IProResumos> {
      const response = await this.api.addAndUpdate(proresumos as IProResumos);
      return response.data;
    }
 
   async getAll(filtro?: FilterProResumos): Promise<IProResumos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching proresumos:', error);
      return [];
    }
  }

  }