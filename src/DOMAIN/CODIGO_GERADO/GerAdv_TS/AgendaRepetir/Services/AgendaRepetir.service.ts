"use client";
import { AgendaRepetirApi } from "../Apis/ApiAgendaRepetir";
import { IAgendaRepetir } from "../Interfaces/interface.AgendaRepetir";
import { FilterAgendaRepetir } from "../Filters/AgendaRepetir";

  export interface IAgendaRepetirService {
    fetchAgendaRepetirById: (id: number) => Promise<IAgendaRepetir>;
    saveAgendaRepetir: (agendarepetir: IAgendaRepetir) => Promise<IAgendaRepetir>;
    
  }
  
  export class AgendaRepetirService implements IAgendaRepetirService {
    constructor(private api: AgendaRepetirApi) {}
  
    async fetchAgendaRepetirById(id: number): Promise<IAgendaRepetir> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveAgendaRepetir(agendarepetir: IAgendaRepetir): Promise<IAgendaRepetir> {
      const response = await this.api.addAndUpdate(agendarepetir as IAgendaRepetir);
      return response.data;
    }
 
   async getAll(filtro?: FilterAgendaRepetir): Promise<IAgendaRepetir[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching agendarepetir:', error);
      return [];
    }
  }

  }