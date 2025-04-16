"use client";
import { BensClassificacaoApi } from "../Apis/ApiBensClassificacao";
import { IBensClassificacao } from "../Interfaces/interface.BensClassificacao";
import { FilterBensClassificacao } from "../Filters/BensClassificacao";

  export interface IBensClassificacaoService {
    fetchBensClassificacaoById: (id: number) => Promise<IBensClassificacao>;
    saveBensClassificacao: (bensclassificacao: IBensClassificacao) => Promise<IBensClassificacao>;
    getList: (filtro?: FilterBensClassificacao) => Promise<IBensClassificacao[]>;
  }
  
  export class BensClassificacaoService implements IBensClassificacaoService {
    constructor(private api: BensClassificacaoApi) {}
  
    async fetchBensClassificacaoById(id: number): Promise<IBensClassificacao> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveBensClassificacao(bensclassificacao: IBensClassificacao): Promise<IBensClassificacao> {
      const response = await this.api.addAndUpdate(bensclassificacao as IBensClassificacao);
      return response.data;
    }
 
   async getList(filtro?: FilterBensClassificacao): Promise<IBensClassificacao[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching bensclassificacao:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterBensClassificacao): Promise<IBensClassificacao[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching bensclassificacao:', error);
      return [];
    }
  }

  }