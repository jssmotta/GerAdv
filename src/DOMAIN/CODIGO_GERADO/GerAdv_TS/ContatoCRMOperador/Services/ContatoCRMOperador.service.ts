"use client";
import { ContatoCRMOperadorApi } from "../Apis/ApiContatoCRMOperador";
import { IContatoCRMOperador } from "../Interfaces/interface.ContatoCRMOperador";
import { FilterContatoCRMOperador } from "../Filters/ContatoCRMOperador";

  export interface IContatoCRMOperadorService {
    fetchContatoCRMOperadorById: (id: number) => Promise<IContatoCRMOperador>;
    saveContatoCRMOperador: (contatocrmoperador: IContatoCRMOperador) => Promise<IContatoCRMOperador>;
    
  }
  
  export class ContatoCRMOperadorService implements IContatoCRMOperadorService {
    constructor(private api: ContatoCRMOperadorApi) {}
  
    async fetchContatoCRMOperadorById(id: number): Promise<IContatoCRMOperador> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveContatoCRMOperador(contatocrmoperador: IContatoCRMOperador): Promise<IContatoCRMOperador> {
      const response = await this.api.addAndUpdate(contatocrmoperador as IContatoCRMOperador);
      return response.data;
    }
 
   async getAll(filtro?: FilterContatoCRMOperador): Promise<IContatoCRMOperador[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching contatocrmoperador:', error);
      return [];
    }
  }

  }