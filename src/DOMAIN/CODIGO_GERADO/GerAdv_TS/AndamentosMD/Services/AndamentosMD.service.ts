"use client";
import { AndamentosMDApi } from "../Apis/ApiAndamentosMD";
import { IAndamentosMD } from "../Interfaces/interface.AndamentosMD";
import { FilterAndamentosMD } from "../Filters/AndamentosMD";

  export interface IAndamentosMDService {
    fetchAndamentosMDById: (id: number) => Promise<IAndamentosMD>;
    saveAndamentosMD: (andamentosmd: IAndamentosMD) => Promise<IAndamentosMD>;
    getList: (filtro?: FilterAndamentosMD) => Promise<IAndamentosMD[]>;
  }
  
  export class AndamentosMDService implements IAndamentosMDService {
    constructor(private api: AndamentosMDApi) {}
  
    async fetchAndamentosMDById(id: number): Promise<IAndamentosMD> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveAndamentosMD(andamentosmd: IAndamentosMD): Promise<IAndamentosMD> {
      const response = await this.api.addAndUpdate(andamentosmd as IAndamentosMD);
      return response.data;
    }
 
   async getList(filtro?: FilterAndamentosMD): Promise<IAndamentosMD[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching andamentosmd:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterAndamentosMD): Promise<IAndamentosMD[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching andamentosmd:', error);
      return [];
    }
  }

  }