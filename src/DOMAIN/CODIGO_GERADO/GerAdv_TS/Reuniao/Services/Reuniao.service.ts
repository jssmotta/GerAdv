"use client";
import { ReuniaoApi } from "../Apis/ApiReuniao";
import { IReuniao } from "../Interfaces/interface.Reuniao";
import { FilterReuniao } from "../Filters/Reuniao";

  export interface IReuniaoService {
    fetchReuniaoById: (id: number) => Promise<IReuniao>;
    saveReuniao: (reuniao: IReuniao) => Promise<IReuniao>;
    
  }
  
  export class ReuniaoService implements IReuniaoService {
    constructor(private api: ReuniaoApi) {}
  
    async fetchReuniaoById(id: number): Promise<IReuniao> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveReuniao(reuniao: IReuniao): Promise<IReuniao> {
      const response = await this.api.addAndUpdate(reuniao as IReuniao);
      return response.data;
    }
 
   async getAll(filtro?: FilterReuniao): Promise<IReuniao[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching reuniao:', error);
      return [];
    }
  }

  }