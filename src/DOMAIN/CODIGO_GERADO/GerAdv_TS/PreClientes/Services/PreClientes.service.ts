"use client";
import { PreClientesApi } from "../Apis/ApiPreClientes";
import { IPreClientes } from "../Interfaces/interface.PreClientes";
import { FilterPreClientes } from "../Filters/PreClientes";

  export interface IPreClientesService {
    fetchPreClientesById: (id: number) => Promise<IPreClientes>;
    savePreClientes: (preclientes: IPreClientes) => Promise<IPreClientes>;
    getList: (filtro?: FilterPreClientes) => Promise<IPreClientes[]>;
  }
  
  export class PreClientesService implements IPreClientesService {
    constructor(private api: PreClientesApi) {}
  
    async fetchPreClientesById(id: number): Promise<IPreClientes> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async savePreClientes(preclientes: IPreClientes): Promise<IPreClientes> {
      const response = await this.api.addAndUpdate(preclientes as IPreClientes);
      return response.data;
    }
 
   async getList(filtro?: FilterPreClientes): Promise<IPreClientes[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching preclientes:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterPreClientes): Promise<IPreClientes[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching preclientes:', error);
      return [];
    }
  }

  }