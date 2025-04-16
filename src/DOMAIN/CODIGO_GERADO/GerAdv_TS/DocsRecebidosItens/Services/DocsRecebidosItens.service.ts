"use client";
import { DocsRecebidosItensApi } from "../Apis/ApiDocsRecebidosItens";
import { IDocsRecebidosItens } from "../Interfaces/interface.DocsRecebidosItens";
import { FilterDocsRecebidosItens } from "../Filters/DocsRecebidosItens";

  export interface IDocsRecebidosItensService {
    fetchDocsRecebidosItensById: (id: number) => Promise<IDocsRecebidosItens>;
    saveDocsRecebidosItens: (docsrecebidositens: IDocsRecebidosItens) => Promise<IDocsRecebidosItens>;
    getList: (filtro?: FilterDocsRecebidosItens) => Promise<IDocsRecebidosItens[]>;
  }
  
  export class DocsRecebidosItensService implements IDocsRecebidosItensService {
    constructor(private api: DocsRecebidosItensApi) {}
  
    async fetchDocsRecebidosItensById(id: number): Promise<IDocsRecebidosItens> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveDocsRecebidosItens(docsrecebidositens: IDocsRecebidosItens): Promise<IDocsRecebidosItens> {
      const response = await this.api.addAndUpdate(docsrecebidositens as IDocsRecebidosItens);
      return response.data;
    }
 
   async getList(filtro?: FilterDocsRecebidosItens): Promise<IDocsRecebidosItens[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching docsrecebidositens:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterDocsRecebidosItens): Promise<IDocsRecebidosItens[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching docsrecebidositens:', error);
      return [];
    }
  }

  }