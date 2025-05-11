"use client";
import { AgendaFinanceiroApi } from "../Apis/ApiAgendaFinanceiro";
import { IAgendaFinanceiro } from "../Interfaces/interface.AgendaFinanceiro";
import { FilterAgendaFinanceiro } from "../Filters/AgendaFinanceiro";

  export interface IAgendaFinanceiroService {
    fetchAgendaFinanceiroById: (id: number) => Promise<IAgendaFinanceiro>;
    saveAgendaFinanceiro: (agendafinanceiro: IAgendaFinanceiro) => Promise<IAgendaFinanceiro>;
    
  }
  
  export class AgendaFinanceiroService implements IAgendaFinanceiroService {
    constructor(private api: AgendaFinanceiroApi) {}
  
    async fetchAgendaFinanceiroById(id: number): Promise<IAgendaFinanceiro> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveAgendaFinanceiro(agendafinanceiro: IAgendaFinanceiro): Promise<IAgendaFinanceiro> {
      const response = await this.api.addAndUpdate(agendafinanceiro as IAgendaFinanceiro);
      return response.data;
    }
 
   async getAll(filtro?: FilterAgendaFinanceiro): Promise<IAgendaFinanceiro[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching agendafinanceiro:', error);
      return [];
    }
  }

  }