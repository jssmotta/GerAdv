"use client";
import { AtividadesApi } from "../Apis/ApiAtividades";
import { IAtividades } from "../Interfaces/interface.Atividades";
import { FilterAtividades } from "../Filters/Atividades";

  export interface IAtividadesService {
    fetchAtividadesById: (id: number) => Promise<IAtividades>;
    saveAtividades: (atividades: IAtividades) => Promise<IAtividades>;
    getList: (filtro?: FilterAtividades) => Promise<IAtividades[]>;
  }
  
  export class AtividadesService implements IAtividadesService {
    constructor(private api: AtividadesApi) {}
  
    async fetchAtividadesById(id: number): Promise<IAtividades> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveAtividades(atividades: IAtividades): Promise<IAtividades> {
      const response = await this.api.addAndUpdate(atividades as IAtividades);
      return response.data;
    }
 
   async getList(filtro?: FilterAtividades): Promise<IAtividades[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching atividades:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterAtividades): Promise<IAtividades[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching atividades:', error);
      return [];
    }
  }

  }