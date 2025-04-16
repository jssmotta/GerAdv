"use client";
import { InstanciaApi } from "../Apis/ApiInstancia";
import { IInstancia } from "../Interfaces/interface.Instancia";
import { FilterInstancia } from "../Filters/Instancia";

  export interface IInstanciaService {
    fetchInstanciaById: (id: number) => Promise<IInstancia>;
    saveInstancia: (instancia: IInstancia) => Promise<IInstancia>;
    getList: (filtro?: FilterInstancia) => Promise<IInstancia[]>;
  }
  
  export class InstanciaService implements IInstanciaService {
    constructor(private api: InstanciaApi) {}
  
    async fetchInstanciaById(id: number): Promise<IInstancia> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveInstancia(instancia: IInstancia): Promise<IInstancia> {
      const response = await this.api.addAndUpdate(instancia as IInstancia);
      return response.data;
    }
 
   async getList(filtro?: FilterInstancia): Promise<IInstancia[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching instancia:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterInstancia): Promise<IInstancia[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching instancia:', error);
      return [];
    }
  }

  }