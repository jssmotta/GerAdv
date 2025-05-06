"use client";
import { Auditor4KApi } from "../Apis/ApiAuditor4K";
import { IAuditor4K } from "../Interfaces/interface.Auditor4K";
import { FilterAuditor4K } from "../Filters/Auditor4K";

  export interface IAuditor4KService {
    fetchAuditor4KById: (id: number) => Promise<IAuditor4K>;
    saveAuditor4K: (auditor4k: IAuditor4K) => Promise<IAuditor4K>;
    getList: (filtro?: FilterAuditor4K) => Promise<IAuditor4K[]>;
  }
  
  export class Auditor4KService implements IAuditor4KService {
    constructor(private api: Auditor4KApi) {}
  
    async fetchAuditor4KById(id: number): Promise<IAuditor4K> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveAuditor4K(auditor4k: IAuditor4K): Promise<IAuditor4K> {
      const response = await this.api.addAndUpdate(auditor4k as IAuditor4K);
      return response.data;
    }
 
   async getList(filtro?: FilterAuditor4K): Promise<IAuditor4K[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching auditor4k:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterAuditor4K): Promise<IAuditor4K[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching auditor4k:', error);
      return [];
    }
  }

  }