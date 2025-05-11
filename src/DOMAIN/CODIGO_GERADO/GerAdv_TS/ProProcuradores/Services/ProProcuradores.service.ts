"use client";
import { ProProcuradoresApi } from "../Apis/ApiProProcuradores";
import { IProProcuradores } from "../Interfaces/interface.ProProcuradores";
import { FilterProProcuradores } from "../Filters/ProProcuradores";

  export interface IProProcuradoresService {
    fetchProProcuradoresById: (id: number) => Promise<IProProcuradores>;
    saveProProcuradores: (proprocuradores: IProProcuradores) => Promise<IProProcuradores>;
    getList: (filtro?: FilterProProcuradores) => Promise<IProProcuradores[]>;
  }
  
  export class ProProcuradoresService implements IProProcuradoresService {
    constructor(private api: ProProcuradoresApi) {}
  
    async fetchProProcuradoresById(id: number): Promise<IProProcuradores> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveProProcuradores(proprocuradores: IProProcuradores): Promise<IProProcuradores> {
      const response = await this.api.addAndUpdate(proprocuradores as IProProcuradores);
      return response.data;
    }
 
   async getList(filtro?: FilterProProcuradores): Promise<IProProcuradores[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching proprocuradores:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterProProcuradores): Promise<IProProcuradores[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching proprocuradores:', error);
      return [];
    }
  }

  }