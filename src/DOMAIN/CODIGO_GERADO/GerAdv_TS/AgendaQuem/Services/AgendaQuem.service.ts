"use client";
import { AgendaQuemApi } from "../Apis/ApiAgendaQuem";
import { IAgendaQuem } from "../Interfaces/interface.AgendaQuem";
import { FilterAgendaQuem } from "../Filters/AgendaQuem";

  export interface IAgendaQuemService {
    fetchAgendaQuemById: (id: number) => Promise<IAgendaQuem>;
    saveAgendaQuem: (agendaquem: IAgendaQuem) => Promise<IAgendaQuem>;
    
  }
  
  export class AgendaQuemService implements IAgendaQuemService {
    constructor(private api: AgendaQuemApi) {}
  
    async fetchAgendaQuemById(id: number): Promise<IAgendaQuem> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveAgendaQuem(agendaquem: IAgendaQuem): Promise<IAgendaQuem> {
      const response = await this.api.addAndUpdate(agendaquem as IAgendaQuem);
      return response.data;
    }
 
   async getAll(filtro?: FilterAgendaQuem): Promise<IAgendaQuem[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching agendaquem:', error);
      return [];
    }
  }

  }