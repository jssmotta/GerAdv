"use client";
import { ReuniaoPessoasApi } from "../Apis/ApiReuniaoPessoas";
import { IReuniaoPessoas } from "../Interfaces/interface.ReuniaoPessoas";
import { FilterReuniaoPessoas } from "../Filters/ReuniaoPessoas";

  export interface IReuniaoPessoasService {
    fetchReuniaoPessoasById: (id: number) => Promise<IReuniaoPessoas>;
    saveReuniaoPessoas: (reuniaopessoas: IReuniaoPessoas) => Promise<IReuniaoPessoas>;
    
  }
  
  export class ReuniaoPessoasService implements IReuniaoPessoasService {
    constructor(private api: ReuniaoPessoasApi) {}
  
    async fetchReuniaoPessoasById(id: number): Promise<IReuniaoPessoas> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveReuniaoPessoas(reuniaopessoas: IReuniaoPessoas): Promise<IReuniaoPessoas> {
      const response = await this.api.addAndUpdate(reuniaopessoas as IReuniaoPessoas);
      return response.data;
    }
 
   async getAll(filtro?: FilterReuniaoPessoas): Promise<IReuniaoPessoas[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching reuniaopessoas:', error);
      return [];
    }
  }

  }