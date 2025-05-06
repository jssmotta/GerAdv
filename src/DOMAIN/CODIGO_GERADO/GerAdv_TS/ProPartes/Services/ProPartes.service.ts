"use client";
import { ProPartesApi } from "../Apis/ApiProPartes";
import { IProPartes } from "../Interfaces/interface.ProPartes";
import { FilterProPartes } from "../Filters/ProPartes";

  export interface IProPartesService {
    fetchProPartesById: (id: number) => Promise<IProPartes>;
    saveProPartes: (propartes: IProPartes) => Promise<IProPartes>;
    
  }
  
  export class ProPartesService implements IProPartesService {
    constructor(private api: ProPartesApi) {}
  
    async fetchProPartesById(id: number): Promise<IProPartes> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveProPartes(propartes: IProPartes): Promise<IProPartes> {
      const response = await this.api.addAndUpdate(propartes as IProPartes);
      return response.data;
    }
 
   async getAll(filtro?: FilterProPartes): Promise<IProPartes[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching propartes:', error);
      return [];
    }
  }

  }