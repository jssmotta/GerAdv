"use client";
import { EnderecoSistemaApi } from "../Apis/ApiEnderecoSistema";
import { IEnderecoSistema } from "../Interfaces/interface.EnderecoSistema";
import { FilterEnderecoSistema } from "../Filters/EnderecoSistema";

  export interface IEnderecoSistemaService {
    fetchEnderecoSistemaById: (id: number) => Promise<IEnderecoSistema>;
    saveEnderecoSistema: (enderecosistema: IEnderecoSistema) => Promise<IEnderecoSistema>;
    
  }
  
  export class EnderecoSistemaService implements IEnderecoSistemaService {
    constructor(private api: EnderecoSistemaApi) {}
  
    async fetchEnderecoSistemaById(id: number): Promise<IEnderecoSistema> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveEnderecoSistema(enderecosistema: IEnderecoSistema): Promise<IEnderecoSistema> {
      const response = await this.api.addAndUpdate(enderecosistema as IEnderecoSistema);
      return response.data;
    }
 
   async getAll(filtro?: FilterEnderecoSistema): Promise<IEnderecoSistema[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching enderecosistema:', error);
      return [];
    }
  }

  }