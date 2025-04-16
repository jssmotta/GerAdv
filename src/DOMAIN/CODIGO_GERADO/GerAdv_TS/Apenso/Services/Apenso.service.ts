"use client";
import { ApensoApi } from "../Apis/ApiApenso";
import { IApenso } from "../Interfaces/interface.Apenso";
import { FilterApenso } from "../Filters/Apenso";

  export interface IApensoService {
    fetchApensoById: (id: number) => Promise<IApenso>;
    saveApenso: (apenso: IApenso) => Promise<IApenso>;
    
  }
  
  export class ApensoService implements IApensoService {
    constructor(private api: ApensoApi) {}
  
    async fetchApensoById(id: number): Promise<IApenso> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveApenso(apenso: IApenso): Promise<IApenso> {
      const response = await this.api.addAndUpdate(apenso as IApenso);
      return response.data;
    }
 
   async getAll(filtro?: FilterApenso): Promise<IApenso[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching apenso:', error);
      return [];
    }
  }

  }