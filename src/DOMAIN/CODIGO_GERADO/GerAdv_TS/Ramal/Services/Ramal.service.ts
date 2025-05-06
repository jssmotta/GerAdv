"use client";
import { RamalApi } from "../Apis/ApiRamal";
import { IRamal } from "../Interfaces/interface.Ramal";
import { FilterRamal } from "../Filters/Ramal";

  export interface IRamalService {
    fetchRamalById: (id: number) => Promise<IRamal>;
    saveRamal: (ramal: IRamal) => Promise<IRamal>;
    getList: (filtro?: FilterRamal) => Promise<IRamal[]>;
  }
  
  export class RamalService implements IRamalService {
    constructor(private api: RamalApi) {}
  
    async fetchRamalById(id: number): Promise<IRamal> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveRamal(ramal: IRamal): Promise<IRamal> {
      const response = await this.api.addAndUpdate(ramal as IRamal);
      return response.data;
    }
 
   async getList(filtro?: FilterRamal): Promise<IRamal[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching ramal:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterRamal): Promise<IRamal[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching ramal:', error);
      return [];
    }
  }

  }