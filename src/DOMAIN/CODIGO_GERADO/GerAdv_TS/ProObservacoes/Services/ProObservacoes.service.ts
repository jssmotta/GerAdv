"use client";
import { ProObservacoesApi } from "../Apis/ApiProObservacoes";
import { IProObservacoes } from "../Interfaces/interface.ProObservacoes";
import { FilterProObservacoes } from "../Filters/ProObservacoes";

  export interface IProObservacoesService {
    fetchProObservacoesById: (id: number) => Promise<IProObservacoes>;
    saveProObservacoes: (proobservacoes: IProObservacoes) => Promise<IProObservacoes>;
    getList: (filtro?: FilterProObservacoes) => Promise<IProObservacoes[]>;
  }
  
  export class ProObservacoesService implements IProObservacoesService {
    constructor(private api: ProObservacoesApi) {}
  
    async fetchProObservacoesById(id: number): Promise<IProObservacoes> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveProObservacoes(proobservacoes: IProObservacoes): Promise<IProObservacoes> {
      const response = await this.api.addAndUpdate(proobservacoes as IProObservacoes);
      return response.data;
    }
 
   async getList(filtro?: FilterProObservacoes): Promise<IProObservacoes[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching proobservacoes:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterProObservacoes): Promise<IProObservacoes[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching proobservacoes:', error);
      return [];
    }
  }

  }