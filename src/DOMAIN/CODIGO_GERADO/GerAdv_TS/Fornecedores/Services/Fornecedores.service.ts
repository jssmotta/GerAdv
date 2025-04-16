"use client";
import { FornecedoresApi } from "../Apis/ApiFornecedores";
import { IFornecedores } from "../Interfaces/interface.Fornecedores";
import { FilterFornecedores } from "../Filters/Fornecedores";

  export interface IFornecedoresService {
    fetchFornecedoresById: (id: number) => Promise<IFornecedores>;
    saveFornecedores: (fornecedores: IFornecedores) => Promise<IFornecedores>;
    getList: (filtro?: FilterFornecedores) => Promise<IFornecedores[]>;
  }
  
  export class FornecedoresService implements IFornecedoresService {
    constructor(private api: FornecedoresApi) {}
  
    async fetchFornecedoresById(id: number): Promise<IFornecedores> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveFornecedores(fornecedores: IFornecedores): Promise<IFornecedores> {
      const response = await this.api.addAndUpdate(fornecedores as IFornecedores);
      return response.data;
    }
 
   async getList(filtro?: FilterFornecedores): Promise<IFornecedores[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching fornecedores:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterFornecedores): Promise<IFornecedores[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching fornecedores:', error);
      return [];
    }
  }

  }