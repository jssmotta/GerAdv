"use client";
import { OperadorApi } from "../Apis/ApiOperador";
import { IOperador } from "../Interfaces/interface.Operador";
import { FilterOperador } from "../Filters/Operador";

  export interface IOperadorService {
    fetchOperadorById: (id: number) => Promise<IOperador>;
    saveOperador: (operador: IOperador) => Promise<IOperador>;
    getList: (filtro?: FilterOperador) => Promise<IOperador[]>;
  }
  
  export class OperadorService implements IOperadorService {
    constructor(private api: OperadorApi) {}
  
    async fetchOperadorById(id: number): Promise<IOperador> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveOperador(operador: IOperador): Promise<IOperador> {
      const response = await this.api.addAndUpdate(operador as IOperador);
      return response.data;
    }
 
   async getList(filtro?: FilterOperador): Promise<IOperador[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching operador:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterOperador): Promise<IOperador[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching operador:', error);
      return [];
    }
  }

  }