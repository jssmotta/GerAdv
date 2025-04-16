"use client";
import { OperadorGruposApi } from "../Apis/ApiOperadorGrupos";
import { IOperadorGrupos } from "../Interfaces/interface.OperadorGrupos";
import { FilterOperadorGrupos } from "../Filters/OperadorGrupos";

  export interface IOperadorGruposService {
    fetchOperadorGruposById: (id: number) => Promise<IOperadorGrupos>;
    saveOperadorGrupos: (operadorgrupos: IOperadorGrupos) => Promise<IOperadorGrupos>;
    getList: (filtro?: FilterOperadorGrupos) => Promise<IOperadorGrupos[]>;
  }
  
  export class OperadorGruposService implements IOperadorGruposService {
    constructor(private api: OperadorGruposApi) {}
  
    async fetchOperadorGruposById(id: number): Promise<IOperadorGrupos> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveOperadorGrupos(operadorgrupos: IOperadorGrupos): Promise<IOperadorGrupos> {
      const response = await this.api.addAndUpdate(operadorgrupos as IOperadorGrupos);
      return response.data;
    }
 
   async getList(filtro?: FilterOperadorGrupos): Promise<IOperadorGrupos[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching operadorgrupos:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterOperadorGrupos): Promise<IOperadorGrupos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching operadorgrupos:', error);
      return [];
    }
  }

  }