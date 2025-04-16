"use client";
import { EscritoriosApi } from "../Apis/ApiEscritorios";
import { IEscritorios } from "../Interfaces/interface.Escritorios";
import { FilterEscritorios } from "../Filters/Escritorios";

  export interface IEscritoriosService {
    fetchEscritoriosById: (id: number) => Promise<IEscritorios>;
    saveEscritorios: (escritorios: IEscritorios) => Promise<IEscritorios>;
    getList: (filtro?: FilterEscritorios) => Promise<IEscritorios[]>;
  }
  
  export class EscritoriosService implements IEscritoriosService {
    constructor(private api: EscritoriosApi) {}
  
    async fetchEscritoriosById(id: number): Promise<IEscritorios> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveEscritorios(escritorios: IEscritorios): Promise<IEscritorios> {
      const response = await this.api.addAndUpdate(escritorios as IEscritorios);
      return response.data;
    }
 
   async getList(filtro?: FilterEscritorios): Promise<IEscritorios[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching escritorios:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterEscritorios): Promise<IEscritorios[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching escritorios:', error);
      return [];
    }
  }

  }