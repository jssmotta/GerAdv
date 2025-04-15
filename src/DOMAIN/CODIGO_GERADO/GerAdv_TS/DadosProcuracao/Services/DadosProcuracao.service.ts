"use client";
import { DadosProcuracaoApi } from "../Apis/ApiDadosProcuracao";
import { IDadosProcuracao } from "../Interfaces/interface.DadosProcuracao";
import { FilterDadosProcuracao } from "../Filters/DadosProcuracao";

  export interface IDadosProcuracaoService {
    fetchDadosProcuracaoById: (id: number) => Promise<IDadosProcuracao>;
    saveDadosProcuracao: (dadosprocuracao: IDadosProcuracao) => Promise<IDadosProcuracao>;
    
  }
  
  export class DadosProcuracaoService implements IDadosProcuracaoService {
    constructor(private api: DadosProcuracaoApi) {}
  
    async fetchDadosProcuracaoById(id: number): Promise<IDadosProcuracao> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveDadosProcuracao(dadosprocuracao: IDadosProcuracao): Promise<IDadosProcuracao> {
      const response = await this.api.addAndUpdate(dadosprocuracao as IDadosProcuracao);
      return response.data;
    }
 
   async getAll(filtro?: FilterDadosProcuracao): Promise<IDadosProcuracao[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching dadosprocuracao:', error);
      return [];
    }
  }

  }