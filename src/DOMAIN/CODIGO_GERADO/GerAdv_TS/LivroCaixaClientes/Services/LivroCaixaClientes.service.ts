"use client";
import { LivroCaixaClientesApi } from "../Apis/ApiLivroCaixaClientes";
import { ILivroCaixaClientes } from "../Interfaces/interface.LivroCaixaClientes";
import { FilterLivroCaixaClientes } from "../Filters/LivroCaixaClientes";

  export interface ILivroCaixaClientesService {
    fetchLivroCaixaClientesById: (id: number) => Promise<ILivroCaixaClientes>;
    saveLivroCaixaClientes: (livrocaixaclientes: ILivroCaixaClientes) => Promise<ILivroCaixaClientes>;
    
  }
  
  export class LivroCaixaClientesService implements ILivroCaixaClientesService {
    constructor(private api: LivroCaixaClientesApi) {}
  
    async fetchLivroCaixaClientesById(id: number): Promise<ILivroCaixaClientes> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveLivroCaixaClientes(livrocaixaclientes: ILivroCaixaClientes): Promise<ILivroCaixaClientes> {
      const response = await this.api.addAndUpdate(livrocaixaclientes as ILivroCaixaClientes);
      return response.data;
    }
 
   async getAll(filtro?: FilterLivroCaixaClientes): Promise<ILivroCaixaClientes[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching livrocaixaclientes:', error);
      return [];
    }
  }

  }