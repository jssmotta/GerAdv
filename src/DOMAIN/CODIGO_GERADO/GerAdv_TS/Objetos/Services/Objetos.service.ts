"use client";
import { ObjetosApi } from "../Apis/ApiObjetos";
import { IObjetos } from "../Interfaces/interface.Objetos";
import { FilterObjetos } from "../Filters/Objetos";

  export interface IObjetosService {
    fetchObjetosById: (id: number) => Promise<IObjetos>;
    saveObjetos: (objetos: IObjetos) => Promise<IObjetos>;
    getList: (filtro?: FilterObjetos) => Promise<IObjetos[]>;
  }
  
  export class ObjetosService implements IObjetosService {
    constructor(private api: ObjetosApi) {}
  
    async fetchObjetosById(id: number): Promise<IObjetos> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveObjetos(objetos: IObjetos): Promise<IObjetos> {
      const response = await this.api.addAndUpdate(objetos as IObjetos);
      return response.data;
    }
 
   async getList(filtro?: FilterObjetos): Promise<IObjetos[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching objetos:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterObjetos): Promise<IObjetos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching objetos:', error);
      return [];
    }
  }

  }