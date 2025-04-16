"use client";
import { EnderecosApi } from "../Apis/ApiEnderecos";
import { IEnderecos } from "../Interfaces/interface.Enderecos";
import { FilterEnderecos } from "../Filters/Enderecos";

  export interface IEnderecosService {
    fetchEnderecosById: (id: number) => Promise<IEnderecos>;
    saveEnderecos: (enderecos: IEnderecos) => Promise<IEnderecos>;
    getList: (filtro?: FilterEnderecos) => Promise<IEnderecos[]>;
  }
  
  export class EnderecosService implements IEnderecosService {
    constructor(private api: EnderecosApi) {}
  
    async fetchEnderecosById(id: number): Promise<IEnderecos> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveEnderecos(enderecos: IEnderecos): Promise<IEnderecos> {
      const response = await this.api.addAndUpdate(enderecos as IEnderecos);
      return response.data;
    }
 
   async getList(filtro?: FilterEnderecos): Promise<IEnderecos[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching enderecos:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterEnderecos): Promise<IEnderecos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching enderecos:', error);
      return [];
    }
  }

  }