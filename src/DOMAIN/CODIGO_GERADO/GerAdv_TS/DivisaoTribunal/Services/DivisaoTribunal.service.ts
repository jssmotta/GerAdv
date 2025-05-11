"use client";
import { DivisaoTribunalApi } from "../Apis/ApiDivisaoTribunal";
import { IDivisaoTribunal } from "../Interfaces/interface.DivisaoTribunal";
import { FilterDivisaoTribunal } from "../Filters/DivisaoTribunal";

  export interface IDivisaoTribunalService {
    fetchDivisaoTribunalById: (id: number) => Promise<IDivisaoTribunal>;
    saveDivisaoTribunal: (divisaotribunal: IDivisaoTribunal) => Promise<IDivisaoTribunal>;
    
  }
  
  export class DivisaoTribunalService implements IDivisaoTribunalService {
    constructor(private api: DivisaoTribunalApi) {}
  
    async fetchDivisaoTribunalById(id: number): Promise<IDivisaoTribunal> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveDivisaoTribunal(divisaotribunal: IDivisaoTribunal): Promise<IDivisaoTribunal> {
      const response = await this.api.addAndUpdate(divisaotribunal as IDivisaoTribunal);
      return response.data;
    }
 
   async getAll(filtro?: FilterDivisaoTribunal): Promise<IDivisaoTribunal[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching divisaotribunal:', error);
      return [];
    }
  }

  }