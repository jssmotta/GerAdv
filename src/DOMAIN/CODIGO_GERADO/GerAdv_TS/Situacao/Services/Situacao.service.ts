"use client";
import { SituacaoApi } from "../Apis/ApiSituacao";
import { ISituacao } from "../Interfaces/interface.Situacao";
import { FilterSituacao } from "../Filters/Situacao";

  export interface ISituacaoService {
    fetchSituacaoById: (id: number) => Promise<ISituacao>;
    saveSituacao: (situacao: ISituacao) => Promise<ISituacao>;
    
  }
  
  export class SituacaoService implements ISituacaoService {
    constructor(private api: SituacaoApi) {}
  
    async fetchSituacaoById(id: number): Promise<ISituacao> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveSituacao(situacao: ISituacao): Promise<ISituacao> {
      const response = await this.api.addAndUpdate(situacao as ISituacao);
      return response.data;
    }
 
   async getAll(filtro?: FilterSituacao): Promise<ISituacao[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching situacao:', error);
      return [];
    }
  }

  }