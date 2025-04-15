"use client";
import { FuncionariosApi } from "../Apis/ApiFuncionarios";
import { IFuncionarios } from "../Interfaces/interface.Funcionarios";
import { FilterFuncionarios } from "../Filters/Funcionarios";

  export interface IFuncionariosService {
    fetchFuncionariosById: (id: number) => Promise<IFuncionarios>;
    saveFuncionarios: (funcionarios: IFuncionarios) => Promise<IFuncionarios>;
    getList: (filtro?: FilterFuncionarios) => Promise<IFuncionarios[]>;
  }
  
  export class FuncionariosService implements IFuncionariosService {
    constructor(private api: FuncionariosApi) {}
  
    async fetchFuncionariosById(id: number): Promise<IFuncionarios> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveFuncionarios(funcionarios: IFuncionarios): Promise<IFuncionarios> {
      const response = await this.api.addAndUpdate(funcionarios as IFuncionarios);
      return response.data;
    }
 
   async getList(filtro?: FilterFuncionarios): Promise<IFuncionarios[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching funcionarios:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterFuncionarios): Promise<IFuncionarios[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching funcionarios:', error);
      return [];
    }
  }

  }