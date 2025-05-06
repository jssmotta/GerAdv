"use client";
import { RitoApi } from "../Apis/ApiRito";
import { IRito } from "../Interfaces/interface.Rito";
import { FilterRito } from "../Filters/Rito";

  export interface IRitoService {
    fetchRitoById: (id: number) => Promise<IRito>;
    saveRito: (rito: IRito) => Promise<IRito>;
    getList: (filtro?: FilterRito) => Promise<IRito[]>;
  }
  
  export class RitoService implements IRitoService {
    constructor(private api: RitoApi) {}
  
    async fetchRitoById(id: number): Promise<IRito> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveRito(rito: IRito): Promise<IRito> {
      const response = await this.api.addAndUpdate(rito as IRito);
      return response.data;
    }
 
   async getList(filtro?: FilterRito): Promise<IRito[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching rito:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterRito): Promise<IRito[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching rito:', error);
      return [];
    }
  }

  }