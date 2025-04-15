"use client";
import { AgendaApi } from "../Apis/ApiAgenda";
import { IAgenda } from "../Interfaces/interface.Agenda";
import { FilterAgenda } from "../Filters/Agenda";

  export interface IAgendaService {
    fetchAgendaById: (id: number) => Promise<IAgenda>;
    saveAgenda: (agenda: IAgenda) => Promise<IAgenda>;
    
  }
  
  export class AgendaService implements IAgendaService {
    constructor(private api: AgendaApi) {}
  
    async fetchAgendaById(id: number): Promise<IAgenda> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveAgenda(agenda: IAgenda): Promise<IAgenda> {
      const response = await this.api.addAndUpdate(agenda as IAgenda);
      return response.data;
    }
 
   async getAll(filtro?: FilterAgenda): Promise<IAgenda[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching agenda:', error);
      return [];
    }
  }

  }