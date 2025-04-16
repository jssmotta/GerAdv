"use client";
import { GUTTipoApi } from "../Apis/ApiGUTTipo";
import { IGUTTipo } from "../Interfaces/interface.GUTTipo";
import { FilterGUTTipo } from "../Filters/GUTTipo";

  export interface IGUTTipoService {
    fetchGUTTipoById: (id: number) => Promise<IGUTTipo>;
    saveGUTTipo: (guttipo: IGUTTipo) => Promise<IGUTTipo>;
    getList: (filtro?: FilterGUTTipo) => Promise<IGUTTipo[]>;
  }
  
  export class GUTTipoService implements IGUTTipoService {
    constructor(private api: GUTTipoApi) {}
  
    async fetchGUTTipoById(id: number): Promise<IGUTTipo> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveGUTTipo(guttipo: IGUTTipo): Promise<IGUTTipo> {
      const response = await this.api.addAndUpdate(guttipo as IGUTTipo);
      return response.data;
    }
 
   async getList(filtro?: FilterGUTTipo): Promise<IGUTTipo[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching guttipo:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterGUTTipo): Promise<IGUTTipo[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching guttipo:', error);
      return [];
    }
  }

  }