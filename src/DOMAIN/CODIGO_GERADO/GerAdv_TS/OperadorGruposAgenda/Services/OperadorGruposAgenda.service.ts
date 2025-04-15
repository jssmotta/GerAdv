"use client";
import { OperadorGruposAgendaApi } from "../Apis/ApiOperadorGruposAgenda";
import { IOperadorGruposAgenda } from "../Interfaces/interface.OperadorGruposAgenda";
import { FilterOperadorGruposAgenda } from "../Filters/OperadorGruposAgenda";

  export interface IOperadorGruposAgendaService {
    fetchOperadorGruposAgendaById: (id: number) => Promise<IOperadorGruposAgenda>;
    saveOperadorGruposAgenda: (operadorgruposagenda: IOperadorGruposAgenda) => Promise<IOperadorGruposAgenda>;
    getList: (filtro?: FilterOperadorGruposAgenda) => Promise<IOperadorGruposAgenda[]>;
  }
  
  export class OperadorGruposAgendaService implements IOperadorGruposAgendaService {
    constructor(private api: OperadorGruposAgendaApi) {}
  
    async fetchOperadorGruposAgendaById(id: number): Promise<IOperadorGruposAgenda> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveOperadorGruposAgenda(operadorgruposagenda: IOperadorGruposAgenda): Promise<IOperadorGruposAgenda> {
      const response = await this.api.addAndUpdate(operadorgruposagenda as IOperadorGruposAgenda);
      return response.data;
    }
 
   async getList(filtro?: FilterOperadorGruposAgenda): Promise<IOperadorGruposAgenda[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching operadorgruposagenda:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterOperadorGruposAgenda): Promise<IOperadorGruposAgenda[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching operadorgruposagenda:', error);
      return [];
    }
  }

  }