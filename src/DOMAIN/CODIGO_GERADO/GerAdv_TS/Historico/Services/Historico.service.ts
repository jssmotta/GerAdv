"use client";
import { HistoricoApi } from "../Apis/ApiHistorico";
import { IHistorico } from "../Interfaces/interface.Historico";
import { FilterHistorico } from "../Filters/Historico";

  export interface IHistoricoService {
    fetchHistoricoById: (id: number) => Promise<IHistorico>;
    saveHistorico: (historico: IHistorico) => Promise<IHistorico>;
    
  }
  
  export class HistoricoService implements IHistoricoService {
    constructor(private api: HistoricoApi) {}
  
    async fetchHistoricoById(id: number): Promise<IHistorico> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveHistorico(historico: IHistorico): Promise<IHistorico> {
      const response = await this.api.addAndUpdate(historico as IHistorico);
      return response.data;
    }
 
   async getAll(filtro?: FilterHistorico): Promise<IHistorico[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching historico:', error);
      return [];
    }
  }

  }