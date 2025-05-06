"use client";
import { PenhoraApi } from "../Apis/ApiPenhora";
import { IPenhora } from "../Interfaces/interface.Penhora";
import { FilterPenhora } from "../Filters/Penhora";

  export interface IPenhoraService {
    fetchPenhoraById: (id: number) => Promise<IPenhora>;
    savePenhora: (penhora: IPenhora) => Promise<IPenhora>;
    getList: (filtro?: FilterPenhora) => Promise<IPenhora[]>;
  }
  
  export class PenhoraService implements IPenhoraService {
    constructor(private api: PenhoraApi) {}
  
    async fetchPenhoraById(id: number): Promise<IPenhora> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async savePenhora(penhora: IPenhora): Promise<IPenhora> {
      const response = await this.api.addAndUpdate(penhora as IPenhora);
      return response.data;
    }
 
   async getList(filtro?: FilterPenhora): Promise<IPenhora[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching penhora:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterPenhora): Promise<IPenhora[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching penhora:', error);
      return [];
    }
  }

  }