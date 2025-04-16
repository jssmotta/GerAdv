"use client";
import { AgendaRepetirDiasApi } from "../Apis/ApiAgendaRepetirDias";
import { IAgendaRepetirDias } from "../Interfaces/interface.AgendaRepetirDias";
import { FilterAgendaRepetirDias } from "../Filters/AgendaRepetirDias";

  export interface IAgendaRepetirDiasService {
    fetchAgendaRepetirDiasById: (id: number) => Promise<IAgendaRepetirDias>;
    saveAgendaRepetirDias: (agendarepetirdias: IAgendaRepetirDias) => Promise<IAgendaRepetirDias>;
    
  }
  
  export class AgendaRepetirDiasService implements IAgendaRepetirDiasService {
    constructor(private api: AgendaRepetirDiasApi) {}
  
    async fetchAgendaRepetirDiasById(id: number): Promise<IAgendaRepetirDias> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveAgendaRepetirDias(agendarepetirdias: IAgendaRepetirDias): Promise<IAgendaRepetirDias> {
      const response = await this.api.addAndUpdate(agendarepetirdias as IAgendaRepetirDias);
      return response.data;
    }
 
   async getAll(filtro?: FilterAgendaRepetirDias): Promise<IAgendaRepetirDias[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching agendarepetirdias:', error);
      return [];
    }
  }

  }