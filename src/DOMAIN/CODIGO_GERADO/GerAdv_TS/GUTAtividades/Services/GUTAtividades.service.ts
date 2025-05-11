"use client";
import { GUTAtividadesApi } from "../Apis/ApiGUTAtividades";
import { IGUTAtividades } from "../Interfaces/interface.GUTAtividades";
import { FilterGUTAtividades } from "../Filters/GUTAtividades";

  export interface IGUTAtividadesService {
    fetchGUTAtividadesById: (id: number) => Promise<IGUTAtividades>;
    saveGUTAtividades: (gutatividades: IGUTAtividades) => Promise<IGUTAtividades>;
    getList: (filtro?: FilterGUTAtividades) => Promise<IGUTAtividades[]>;
  }
  
  export class GUTAtividadesService implements IGUTAtividadesService {
    constructor(private api: GUTAtividadesApi) {}
  
    async fetchGUTAtividadesById(id: number): Promise<IGUTAtividades> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveGUTAtividades(gutatividades: IGUTAtividades): Promise<IGUTAtividades> {
      const response = await this.api.addAndUpdate(gutatividades as IGUTAtividades);
      return response.data;
    }
 
   async getList(filtro?: FilterGUTAtividades): Promise<IGUTAtividades[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching gutatividades:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterGUTAtividades): Promise<IGUTAtividades[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching gutatividades:', error);
      return [];
    }
  }

  }