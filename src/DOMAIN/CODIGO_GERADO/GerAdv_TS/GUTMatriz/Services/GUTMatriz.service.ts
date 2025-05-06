"use client";
import { GUTMatrizApi } from "../Apis/ApiGUTMatriz";
import { IGUTMatriz } from "../Interfaces/interface.GUTMatriz";
import { FilterGUTMatriz } from "../Filters/GUTMatriz";

  export interface IGUTMatrizService {
    fetchGUTMatrizById: (id: number) => Promise<IGUTMatriz>;
    saveGUTMatriz: (gutmatriz: IGUTMatriz) => Promise<IGUTMatriz>;
    getList: (filtro?: FilterGUTMatriz) => Promise<IGUTMatriz[]>;
  }
  
  export class GUTMatrizService implements IGUTMatrizService {
    constructor(private api: GUTMatrizApi) {}
  
    async fetchGUTMatrizById(id: number): Promise<IGUTMatriz> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveGUTMatriz(gutmatriz: IGUTMatriz): Promise<IGUTMatriz> {
      const response = await this.api.addAndUpdate(gutmatriz as IGUTMatriz);
      return response.data;
    }
 
   async getList(filtro?: FilterGUTMatriz): Promise<IGUTMatriz[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching gutmatriz:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterGUTMatriz): Promise<IGUTMatriz[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching gutmatriz:', error);
      return [];
    }
  }

  }