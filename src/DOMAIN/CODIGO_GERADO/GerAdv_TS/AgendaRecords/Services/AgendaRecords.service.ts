"use client";
import { AgendaRecordsApi } from "../Apis/ApiAgendaRecords";
import { IAgendaRecords } from "../Interfaces/interface.AgendaRecords";
import { FilterAgendaRecords } from "../Filters/AgendaRecords";

  export interface IAgendaRecordsService {
    fetchAgendaRecordsById: (id: number) => Promise<IAgendaRecords>;
    saveAgendaRecords: (agendarecords: IAgendaRecords) => Promise<IAgendaRecords>;
    
  }
  
  export class AgendaRecordsService implements IAgendaRecordsService {
    constructor(private api: AgendaRecordsApi) {}
  
    async fetchAgendaRecordsById(id: number): Promise<IAgendaRecords> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveAgendaRecords(agendarecords: IAgendaRecords): Promise<IAgendaRecords> {
      const response = await this.api.addAndUpdate(agendarecords as IAgendaRecords);
      return response.data;
    }
 
   async getAll(filtro?: FilterAgendaRecords): Promise<IAgendaRecords[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching agendarecords:', error);
      return [];
    }
  }

  }