"use client";
import { UFApi } from "../Apis/ApiUF";
import { IUF } from "../Interfaces/interface.UF";
import { FilterUF } from "../Filters/UF";

  export interface IUFService {
    fetchUFById: (id: number) => Promise<IUF>;
    saveUF: (uf: IUF) => Promise<IUF>;
    getList: (filtro?: FilterUF) => Promise<IUF[]>;
  }
  
  export class UFService implements IUFService {
    constructor(private api: UFApi) {}
  
    async fetchUFById(id: number): Promise<IUF> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveUF(uf: IUF): Promise<IUF> {
      const response = await this.api.addAndUpdate(uf as IUF);
      return response.data;
    }
 
   async getList(filtro?: FilterUF): Promise<IUF[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching uf:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterUF): Promise<IUF[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching uf:', error);
      return [];
    }
  }

  }