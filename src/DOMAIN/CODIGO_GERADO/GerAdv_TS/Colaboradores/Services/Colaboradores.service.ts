"use client";
import { ColaboradoresApi } from "../Apis/ApiColaboradores";
import { IColaboradores } from "../Interfaces/interface.Colaboradores";
import { FilterColaboradores } from "../Filters/Colaboradores";

  export interface IColaboradoresService {
    fetchColaboradoresById: (id: number) => Promise<IColaboradores>;
    saveColaboradores: (colaboradores: IColaboradores) => Promise<IColaboradores>;
    getList: (filtro?: FilterColaboradores) => Promise<IColaboradores[]>;
  }
  
  export class ColaboradoresService implements IColaboradoresService {
    constructor(private api: ColaboradoresApi) {}
  
    async fetchColaboradoresById(id: number): Promise<IColaboradores> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveColaboradores(colaboradores: IColaboradores): Promise<IColaboradores> {
      const response = await this.api.addAndUpdate(colaboradores as IColaboradores);
      return response.data;
    }
 
   async getList(filtro?: FilterColaboradores): Promise<IColaboradores[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching colaboradores:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterColaboradores): Promise<IColaboradores[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching colaboradores:', error);
      return [];
    }
  }

  }