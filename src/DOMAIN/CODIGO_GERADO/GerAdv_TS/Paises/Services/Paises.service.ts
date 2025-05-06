"use client";
import { PaisesApi } from "../Apis/ApiPaises";
import { IPaises } from "../Interfaces/interface.Paises";
import { FilterPaises } from "../Filters/Paises";

  export interface IPaisesService {
    fetchPaisesById: (id: number) => Promise<IPaises>;
    savePaises: (paises: IPaises) => Promise<IPaises>;
    getList: (filtro?: FilterPaises) => Promise<IPaises[]>;
  }
  
  export class PaisesService implements IPaisesService {
    constructor(private api: PaisesApi) {}
  
    async fetchPaisesById(id: number): Promise<IPaises> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async savePaises(paises: IPaises): Promise<IPaises> {
      const response = await this.api.addAndUpdate(paises as IPaises);
      return response.data;
    }
 
   async getList(filtro?: FilterPaises): Promise<IPaises[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching paises:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterPaises): Promise<IPaises[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching paises:', error);
      return [];
    }
  }

  }