"use client";
import { EventoPrazoAgendaApi } from "../Apis/ApiEventoPrazoAgenda";
import { IEventoPrazoAgenda } from "../Interfaces/interface.EventoPrazoAgenda";
import { FilterEventoPrazoAgenda } from "../Filters/EventoPrazoAgenda";

  export interface IEventoPrazoAgendaService {
    fetchEventoPrazoAgendaById: (id: number) => Promise<IEventoPrazoAgenda>;
    saveEventoPrazoAgenda: (eventoprazoagenda: IEventoPrazoAgenda) => Promise<IEventoPrazoAgenda>;
    getList: (filtro?: FilterEventoPrazoAgenda) => Promise<IEventoPrazoAgenda[]>;
  }
  
  export class EventoPrazoAgendaService implements IEventoPrazoAgendaService {
    constructor(private api: EventoPrazoAgendaApi) {}
  
    async fetchEventoPrazoAgendaById(id: number): Promise<IEventoPrazoAgenda> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveEventoPrazoAgenda(eventoprazoagenda: IEventoPrazoAgenda): Promise<IEventoPrazoAgenda> {
      const response = await this.api.addAndUpdate(eventoprazoagenda as IEventoPrazoAgenda);
      return response.data;
    }
 
   async getList(filtro?: FilterEventoPrazoAgenda): Promise<IEventoPrazoAgenda[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching eventoprazoagenda:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterEventoPrazoAgenda): Promise<IEventoPrazoAgenda[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching eventoprazoagenda:', error);
      return [];
    }
  }

  }