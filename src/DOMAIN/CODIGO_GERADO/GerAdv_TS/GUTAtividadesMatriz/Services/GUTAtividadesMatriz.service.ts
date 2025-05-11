"use client";
import { GUTAtividadesMatrizApi } from "../Apis/ApiGUTAtividadesMatriz";
import { IGUTAtividadesMatriz } from "../Interfaces/interface.GUTAtividadesMatriz";
import { FilterGUTAtividadesMatriz } from "../Filters/GUTAtividadesMatriz";

  export interface IGUTAtividadesMatrizService {
    fetchGUTAtividadesMatrizById: (id: number) => Promise<IGUTAtividadesMatriz>;
    saveGUTAtividadesMatriz: (gutatividadesmatriz: IGUTAtividadesMatriz) => Promise<IGUTAtividadesMatriz>;
    
  }
  
  export class GUTAtividadesMatrizService implements IGUTAtividadesMatrizService {
    constructor(private api: GUTAtividadesMatrizApi) {}
  
    async fetchGUTAtividadesMatrizById(id: number): Promise<IGUTAtividadesMatriz> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveGUTAtividadesMatriz(gutatividadesmatriz: IGUTAtividadesMatriz): Promise<IGUTAtividadesMatriz> {
      const response = await this.api.addAndUpdate(gutatividadesmatriz as IGUTAtividadesMatriz);
      return response.data;
    }
 
   async getAll(filtro?: FilterGUTAtividadesMatriz): Promise<IGUTAtividadesMatriz[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching gutatividadesmatriz:', error);
      return [];
    }
  }

  }