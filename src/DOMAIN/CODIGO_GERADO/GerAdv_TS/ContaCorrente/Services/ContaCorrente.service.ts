"use client";
import { ContaCorrenteApi } from "../Apis/ApiContaCorrente";
import { IContaCorrente } from "../Interfaces/interface.ContaCorrente";
import { FilterContaCorrente } from "../Filters/ContaCorrente";

  export interface IContaCorrenteService {
    fetchContaCorrenteById: (id: number) => Promise<IContaCorrente>;
    saveContaCorrente: (contacorrente: IContaCorrente) => Promise<IContaCorrente>;
    
  }
  
  export class ContaCorrenteService implements IContaCorrenteService {
    constructor(private api: ContaCorrenteApi) {}
  
    async fetchContaCorrenteById(id: number): Promise<IContaCorrente> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveContaCorrente(contacorrente: IContaCorrente): Promise<IContaCorrente> {
      const response = await this.api.addAndUpdate(contacorrente as IContaCorrente);
      return response.data;
    }
 
   async getAll(filtro?: FilterContaCorrente): Promise<IContaCorrente[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching contacorrente:', error);
      return [];
    }
  }

  }