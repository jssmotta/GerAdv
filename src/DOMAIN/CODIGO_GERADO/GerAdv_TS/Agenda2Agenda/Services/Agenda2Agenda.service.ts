"use client";
import { Agenda2AgendaApi } from "../Apis/ApiAgenda2Agenda";
import { IAgenda2Agenda } from "../Interfaces/interface.Agenda2Agenda";
import { FilterAgenda2Agenda } from "../Filters/Agenda2Agenda";

  export interface IAgenda2AgendaService {
    fetchAgenda2AgendaById: (id: number) => Promise<IAgenda2Agenda>;
    saveAgenda2Agenda: (agenda2agenda: IAgenda2Agenda) => Promise<IAgenda2Agenda>;
    
  }
  
  export class Agenda2AgendaService implements IAgenda2AgendaService {
    constructor(private api: Agenda2AgendaApi) {}
  
    async fetchAgenda2AgendaById(id: number): Promise<IAgenda2Agenda> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveAgenda2Agenda(agenda2agenda: IAgenda2Agenda): Promise<IAgenda2Agenda> {
      const response = await this.api.addAndUpdate(agenda2agenda as IAgenda2Agenda);
      return response.data;
    }
 
   async getAll(filtro?: FilterAgenda2Agenda): Promise<IAgenda2Agenda[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching agenda2agenda:', error);
      return [];
    }
  }

  }