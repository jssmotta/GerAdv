"use client";
import { ProSucumbenciaApi } from "../Apis/ApiProSucumbencia";
import { IProSucumbencia } from "../Interfaces/interface.ProSucumbencia";
import { FilterProSucumbencia } from "../Filters/ProSucumbencia";

  export interface IProSucumbenciaService {
    fetchProSucumbenciaById: (id: number) => Promise<IProSucumbencia>;
    saveProSucumbencia: (prosucumbencia: IProSucumbencia) => Promise<IProSucumbencia>;
    getList: (filtro?: FilterProSucumbencia) => Promise<IProSucumbencia[]>;
  }
  
  export class ProSucumbenciaService implements IProSucumbenciaService {
    constructor(private api: ProSucumbenciaApi) {}
  
    async fetchProSucumbenciaById(id: number): Promise<IProSucumbencia> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveProSucumbencia(prosucumbencia: IProSucumbencia): Promise<IProSucumbencia> {
      const response = await this.api.addAndUpdate(prosucumbencia as IProSucumbencia);
      return response.data;
    }
 
   async getList(filtro?: FilterProSucumbencia): Promise<IProSucumbencia[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching prosucumbencia:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterProSucumbencia): Promise<IProSucumbencia[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching prosucumbencia:', error);
      return [];
    }
  }

  }