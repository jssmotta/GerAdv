"use client";
import { AcaoApi } from "../Apis/ApiAcao";
import { IAcao } from "../Interfaces/interface.Acao";
import { FilterAcao } from "../Filters/Acao";

  export interface IAcaoService {
    fetchAcaoById: (id: number) => Promise<IAcao>;
    saveAcao: (acao: IAcao) => Promise<IAcao>;
    getList: (filtro?: FilterAcao) => Promise<IAcao[]>;
  }
  
  export class AcaoService implements IAcaoService {
    constructor(private api: AcaoApi) {}
  
    async fetchAcaoById(id: number): Promise<IAcao> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveAcao(acao: IAcao): Promise<IAcao> {
      const response = await this.api.addAndUpdate(acao as IAcao);
      return response.data;
    }
 
   async getList(filtro?: FilterAcao): Promise<IAcao[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching acao:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterAcao): Promise<IAcao[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching acao:', error);
      return [];
    }
  }

  }