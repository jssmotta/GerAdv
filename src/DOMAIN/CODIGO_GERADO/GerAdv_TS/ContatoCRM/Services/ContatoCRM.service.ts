"use client";
import { ContatoCRMApi } from "../Apis/ApiContatoCRM";
import { IContatoCRM } from "../Interfaces/interface.ContatoCRM";
import { FilterContatoCRM } from "../Filters/ContatoCRM";

  export interface IContatoCRMService {
    fetchContatoCRMById: (id: number) => Promise<IContatoCRM>;
    saveContatoCRM: (contatocrm: IContatoCRM) => Promise<IContatoCRM>;
    
  }
  
  export class ContatoCRMService implements IContatoCRMService {
    constructor(private api: ContatoCRMApi) {}
  
    async fetchContatoCRMById(id: number): Promise<IContatoCRM> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveContatoCRM(contatocrm: IContatoCRM): Promise<IContatoCRM> {
      const response = await this.api.addAndUpdate(contatocrm as IContatoCRM);
      return response.data;
    }
 
   async getAll(filtro?: FilterContatoCRM): Promise<IContatoCRM[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching contatocrm:', error);
      return [];
    }
  }

  }