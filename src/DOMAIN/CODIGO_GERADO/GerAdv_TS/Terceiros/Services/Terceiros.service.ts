"use client";
import { TerceirosApi } from "../Apis/ApiTerceiros";
import { ITerceiros } from "../Interfaces/interface.Terceiros";
import { FilterTerceiros } from "../Filters/Terceiros";

  export interface ITerceirosService {
    fetchTerceirosById: (id: number) => Promise<ITerceiros>;
    saveTerceiros: (terceiros: ITerceiros) => Promise<ITerceiros>;
    getList: (filtro?: FilterTerceiros) => Promise<ITerceiros[]>;
  }
  
  export class TerceirosService implements ITerceirosService {
    constructor(private api: TerceirosApi) {}
  
    async fetchTerceirosById(id: number): Promise<ITerceiros> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveTerceiros(terceiros: ITerceiros): Promise<ITerceiros> {
      const response = await this.api.addAndUpdate(terceiros as ITerceiros);
      return response.data;
    }
 
   async getList(filtro?: FilterTerceiros): Promise<ITerceiros[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching terceiros:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterTerceiros): Promise<ITerceiros[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching terceiros:', error);
      return [];
    }
  }

  }