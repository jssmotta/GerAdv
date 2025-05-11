"use client";
import { StatusTarefasApi } from "../Apis/ApiStatusTarefas";
import { IStatusTarefas } from "../Interfaces/interface.StatusTarefas";
import { FilterStatusTarefas } from "../Filters/StatusTarefas";

  export interface IStatusTarefasService {
    fetchStatusTarefasById: (id: number) => Promise<IStatusTarefas>;
    saveStatusTarefas: (statustarefas: IStatusTarefas) => Promise<IStatusTarefas>;
    getList: (filtro?: FilterStatusTarefas) => Promise<IStatusTarefas[]>;
  }
  
  export class StatusTarefasService implements IStatusTarefasService {
    constructor(private api: StatusTarefasApi) {}
  
    async fetchStatusTarefasById(id: number): Promise<IStatusTarefas> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveStatusTarefas(statustarefas: IStatusTarefas): Promise<IStatusTarefas> {
      const response = await this.api.addAndUpdate(statustarefas as IStatusTarefas);
      return response.data;
    }
 
   async getList(filtro?: FilterStatusTarefas): Promise<IStatusTarefas[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching statustarefas:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterStatusTarefas): Promise<IStatusTarefas[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching statustarefas:', error);
      return [];
    }
  }

  }