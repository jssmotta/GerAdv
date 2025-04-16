"use client";
import { OperadoresApi } from "../Apis/ApiOperadores";
import { IOperadores } from "../Interfaces/interface.Operadores";
import { FilterOperadores } from "../Filters/Operadores";

  export interface IOperadoresService {
    fetchOperadoresById: (id: number) => Promise<IOperadores>;
    saveOperadores: (operadores: IOperadores) => Promise<IOperadores>;
    getList: (filtro?: FilterOperadores) => Promise<IOperadores[]>;
  }
  
  export class OperadoresService implements IOperadoresService {
    constructor(private api: OperadoresApi) {}
  
    async fetchOperadoresById(id: number): Promise<IOperadores> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveOperadores(operadores: IOperadores): Promise<IOperadores> {
      const response = await this.api.addAndUpdate(operadores as IOperadores);
      return response.data;
    }
 
   async getList(filtro?: FilterOperadores): Promise<IOperadores[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching operadores:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterOperadores): Promise<IOperadores[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching operadores:', error);
      return [];
    }
  }

  }