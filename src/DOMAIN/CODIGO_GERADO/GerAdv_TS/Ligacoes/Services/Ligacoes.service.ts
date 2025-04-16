"use client";
import { LigacoesApi } from "../Apis/ApiLigacoes";
import { ILigacoes } from "../Interfaces/interface.Ligacoes";
import { FilterLigacoes } from "../Filters/Ligacoes";

  export interface ILigacoesService {
    fetchLigacoesById: (id: number) => Promise<ILigacoes>;
    saveLigacoes: (ligacoes: ILigacoes) => Promise<ILigacoes>;
    getList: (filtro?: FilterLigacoes) => Promise<ILigacoes[]>;
  }
  
  export class LigacoesService implements ILigacoesService {
    constructor(private api: LigacoesApi) {}
  
    async fetchLigacoesById(id: number): Promise<ILigacoes> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveLigacoes(ligacoes: ILigacoes): Promise<ILigacoes> {
      const response = await this.api.addAndUpdate(ligacoes as ILigacoes);
      return response.data;
    }
 
   async getList(filtro?: FilterLigacoes): Promise<ILigacoes[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching ligacoes:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterLigacoes): Promise<ILigacoes[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching ligacoes:', error);
      return [];
    }
  }

  }