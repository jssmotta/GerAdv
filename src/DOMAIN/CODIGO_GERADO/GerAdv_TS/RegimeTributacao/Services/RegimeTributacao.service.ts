"use client";
import { RegimeTributacaoApi } from "../Apis/ApiRegimeTributacao";
import { IRegimeTributacao } from "../Interfaces/interface.RegimeTributacao";
import { FilterRegimeTributacao } from "../Filters/RegimeTributacao";

  export interface IRegimeTributacaoService {
    fetchRegimeTributacaoById: (id: number) => Promise<IRegimeTributacao>;
    saveRegimeTributacao: (regimetributacao: IRegimeTributacao) => Promise<IRegimeTributacao>;
    getList: (filtro?: FilterRegimeTributacao) => Promise<IRegimeTributacao[]>;
  }
  
  export class RegimeTributacaoService implements IRegimeTributacaoService {
    constructor(private api: RegimeTributacaoApi) {}
  
    async fetchRegimeTributacaoById(id: number): Promise<IRegimeTributacao> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveRegimeTributacao(regimetributacao: IRegimeTributacao): Promise<IRegimeTributacao> {
      const response = await this.api.addAndUpdate(regimetributacao as IRegimeTributacao);
      return response.data;
    }
 
   async getList(filtro?: FilterRegimeTributacao): Promise<IRegimeTributacao[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching regimetributacao:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterRegimeTributacao): Promise<IRegimeTributacao[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching regimetributacao:', error);
      return [];
    }
  }

  }