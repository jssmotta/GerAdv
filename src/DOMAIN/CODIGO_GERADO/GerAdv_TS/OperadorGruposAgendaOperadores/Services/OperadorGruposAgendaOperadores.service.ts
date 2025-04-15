"use client";
import { OperadorGruposAgendaOperadoresApi } from "../Apis/ApiOperadorGruposAgendaOperadores";
import { IOperadorGruposAgendaOperadores } from "../Interfaces/interface.OperadorGruposAgendaOperadores";
import { FilterOperadorGruposAgendaOperadores } from "../Filters/OperadorGruposAgendaOperadores";

  export interface IOperadorGruposAgendaOperadoresService {
    fetchOperadorGruposAgendaOperadoresById: (id: number) => Promise<IOperadorGruposAgendaOperadores>;
    saveOperadorGruposAgendaOperadores: (operadorgruposagendaoperadores: IOperadorGruposAgendaOperadores) => Promise<IOperadorGruposAgendaOperadores>;
    
  }
  
  export class OperadorGruposAgendaOperadoresService implements IOperadorGruposAgendaOperadoresService {
    constructor(private api: OperadorGruposAgendaOperadoresApi) {}
  
    async fetchOperadorGruposAgendaOperadoresById(id: number): Promise<IOperadorGruposAgendaOperadores> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveOperadorGruposAgendaOperadores(operadorgruposagendaoperadores: IOperadorGruposAgendaOperadores): Promise<IOperadorGruposAgendaOperadores> {
      const response = await this.api.addAndUpdate(operadorgruposagendaoperadores as IOperadorGruposAgendaOperadores);
      return response.data;
    }
 
   async getAll(filtro?: FilterOperadorGruposAgendaOperadores): Promise<IOperadorGruposAgendaOperadores[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching operadorgruposagendaoperadores:', error);
      return [];
    }
  }

  }