"use client";
import { CidadeApi } from "../Apis/ApiCidade";
import { ICidade } from "../Interfaces/interface.Cidade";
import { FilterCidade } from "../Filters/Cidade";

  export interface ICidadeService {
    fetchCidadeById: (id: number) => Promise<ICidade>;
    saveCidade: (cidade: ICidade) => Promise<ICidade>;
    getList: (filtro?: FilterCidade) => Promise<ICidade[]>;
  }
  
  export class CidadeService implements ICidadeService {
    constructor(private api: CidadeApi) {}
  
    async fetchCidadeById(id: number): Promise<ICidade> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveCidade(cidade: ICidade): Promise<ICidade> {
      const response = await this.api.addAndUpdate(cidade as ICidade);
      return response.data;
    }
 
   async getList(filtro?: FilterCidade): Promise<ICidade[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching cidade:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterCidade): Promise<ICidade[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching cidade:', error);
      return [];
    }
  }

  }