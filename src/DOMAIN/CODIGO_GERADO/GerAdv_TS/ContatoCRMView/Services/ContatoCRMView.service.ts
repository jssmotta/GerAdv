"use client";
import { ContatoCRMViewApi } from "../Apis/ApiContatoCRMView";
import { IContatoCRMView } from "../Interfaces/interface.ContatoCRMView";
import { FilterContatoCRMView } from "../Filters/ContatoCRMView";

  export interface IContatoCRMViewService {
    fetchContatoCRMViewById: (id: number) => Promise<IContatoCRMView>;
    saveContatoCRMView: (contatocrmview: IContatoCRMView) => Promise<IContatoCRMView>;
    
  }
  
  export class ContatoCRMViewService implements IContatoCRMViewService {
    constructor(private api: ContatoCRMViewApi) {}
  
    async fetchContatoCRMViewById(id: number): Promise<IContatoCRMView> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveContatoCRMView(contatocrmview: IContatoCRMView): Promise<IContatoCRMView> {
      const response = await this.api.addAndUpdate(contatocrmview as IContatoCRMView);
      return response.data;
    }
 
   async getAll(filtro?: FilterContatoCRMView): Promise<IContatoCRMView[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching contatocrmview:', error);
      return [];
    }
  }

  }