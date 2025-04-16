"use client";
import { AgendaStatusApi } from "../Apis/ApiAgendaStatus";
import { IAgendaStatus } from "../Interfaces/interface.AgendaStatus";
import { FilterAgendaStatus } from "../Filters/AgendaStatus";

  export interface IAgendaStatusService {
    fetchAgendaStatusById: (id: number) => Promise<IAgendaStatus>;
    saveAgendaStatus: (agendastatus: IAgendaStatus) => Promise<IAgendaStatus>;
    
  }
  
  export class AgendaStatusService implements IAgendaStatusService {
    constructor(private api: AgendaStatusApi) {}
  
    async fetchAgendaStatusById(id: number): Promise<IAgendaStatus> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveAgendaStatus(agendastatus: IAgendaStatus): Promise<IAgendaStatus> {
      const response = await this.api.addAndUpdate(agendastatus as IAgendaStatus);
      return response.data;
    }
 
   async getAll(filtro?: FilterAgendaStatus): Promise<IAgendaStatus[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching agendastatus:', error);
      return [];
    }
  }

  }