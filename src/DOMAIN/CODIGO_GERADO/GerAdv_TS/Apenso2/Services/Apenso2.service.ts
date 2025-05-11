"use client";
import { Apenso2Api } from "../Apis/ApiApenso2";
import { IApenso2 } from "../Interfaces/interface.Apenso2";
import { FilterApenso2 } from "../Filters/Apenso2";

  export interface IApenso2Service {
    fetchApenso2ById: (id: number) => Promise<IApenso2>;
    saveApenso2: (apenso2: IApenso2) => Promise<IApenso2>;
    
  }
  
  export class Apenso2Service implements IApenso2Service {
    constructor(private api: Apenso2Api) {}
  
    async fetchApenso2ById(id: number): Promise<IApenso2> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveApenso2(apenso2: IApenso2): Promise<IApenso2> {
      const response = await this.api.addAndUpdate(apenso2 as IApenso2);
      return response.data;
    }
 
   async getAll(filtro?: FilterApenso2): Promise<IApenso2[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching apenso2:', error);
      return [];
    }
  }

  }