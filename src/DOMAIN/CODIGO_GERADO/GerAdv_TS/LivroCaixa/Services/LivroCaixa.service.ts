"use client";
import { LivroCaixaApi } from "../Apis/ApiLivroCaixa";
import { ILivroCaixa } from "../Interfaces/interface.LivroCaixa";
import { FilterLivroCaixa } from "../Filters/LivroCaixa";

  export interface ILivroCaixaService {
    fetchLivroCaixaById: (id: number) => Promise<ILivroCaixa>;
    saveLivroCaixa: (livrocaixa: ILivroCaixa) => Promise<ILivroCaixa>;
    
  }
  
  export class LivroCaixaService implements ILivroCaixaService {
    constructor(private api: LivroCaixaApi) {}
  
    async fetchLivroCaixaById(id: number): Promise<ILivroCaixa> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveLivroCaixa(livrocaixa: ILivroCaixa): Promise<ILivroCaixa> {
      const response = await this.api.addAndUpdate(livrocaixa as ILivroCaixa);
      return response.data;
    }
 
   async getAll(filtro?: FilterLivroCaixa): Promise<ILivroCaixa[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching livrocaixa:', error);
      return [];
    }
  }

  }