"use client";
import { FuncaoApi } from "../Apis/ApiFuncao";
import { IFuncao } from "../Interfaces/interface.Funcao";
import { FilterFuncao } from "../Filters/Funcao";

  export interface IFuncaoService {
    fetchFuncaoById: (id: number) => Promise<IFuncao>;
    saveFuncao: (funcao: IFuncao) => Promise<IFuncao>;
    getList: (filtro?: FilterFuncao) => Promise<IFuncao[]>;
  }
  
  export class FuncaoService implements IFuncaoService {
    constructor(private api: FuncaoApi) {}
  
    async fetchFuncaoById(id: number): Promise<IFuncao> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveFuncao(funcao: IFuncao): Promise<IFuncao> {
      const response = await this.api.addAndUpdate(funcao as IFuncao);
      return response.data;
    }
 
   async getList(filtro?: FilterFuncao): Promise<IFuncao[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching funcao:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterFuncao): Promise<IFuncao[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching funcao:', error);
      return [];
    }
  }

  }