"use client";
import { StatusInstanciaApi } from "../Apis/ApiStatusInstancia";
import { IStatusInstancia } from "../Interfaces/interface.StatusInstancia";
import { FilterStatusInstancia } from "../Filters/StatusInstancia";

  export interface IStatusInstanciaService {
    fetchStatusInstanciaById: (id: number) => Promise<IStatusInstancia>;
    saveStatusInstancia: (statusinstancia: IStatusInstancia) => Promise<IStatusInstancia>;
    getList: (filtro?: FilterStatusInstancia) => Promise<IStatusInstancia[]>;
  }
  
  export class StatusInstanciaService implements IStatusInstanciaService {
    constructor(private api: StatusInstanciaApi) {}
  
    async fetchStatusInstanciaById(id: number): Promise<IStatusInstancia> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveStatusInstancia(statusinstancia: IStatusInstancia): Promise<IStatusInstancia> {
      const response = await this.api.addAndUpdate(statusinstancia as IStatusInstancia);
      return response.data;
    }
 
   async getList(filtro?: FilterStatusInstancia): Promise<IStatusInstancia[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching statusinstancia:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterStatusInstancia): Promise<IStatusInstancia[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching statusinstancia:', error);
      return [];
    }
  }

  }