"use client";
import { EndTitApi } from "../Apis/ApiEndTit";
import { IEndTit } from "../Interfaces/interface.EndTit";
import { FilterEndTit } from "../Filters/EndTit";

  export interface IEndTitService {
    fetchEndTitById: (id: number) => Promise<IEndTit>;
    saveEndTit: (endtit: IEndTit) => Promise<IEndTit>;
    
  }
  
  export class EndTitService implements IEndTitService {
    constructor(private api: EndTitApi) {}
  
    async fetchEndTitById(id: number): Promise<IEndTit> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveEndTit(endtit: IEndTit): Promise<IEndTit> {
      const response = await this.api.addAndUpdate(endtit as IEndTit);
      return response.data;
    }
 
   async getAll(filtro?: FilterEndTit): Promise<IEndTit[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching endtit:', error);
      return [];
    }
  }

  }