"use client";
import { StatusAndamentoApi } from "../Apis/ApiStatusAndamento";
import { IStatusAndamento } from "../Interfaces/interface.StatusAndamento";
import { FilterStatusAndamento } from "../Filters/StatusAndamento";

  export interface IStatusAndamentoService {
    fetchStatusAndamentoById: (id: number) => Promise<IStatusAndamento>;
    saveStatusAndamento: (statusandamento: IStatusAndamento) => Promise<IStatusAndamento>;
    getList: (filtro?: FilterStatusAndamento) => Promise<IStatusAndamento[]>;
  }
  
  export class StatusAndamentoService implements IStatusAndamentoService {
    constructor(private api: StatusAndamentoApi) {}
  
    async fetchStatusAndamentoById(id: number): Promise<IStatusAndamento> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveStatusAndamento(statusandamento: IStatusAndamento): Promise<IStatusAndamento> {
      const response = await this.api.addAndUpdate(statusandamento as IStatusAndamento);
      return response.data;
    }
 
   async getList(filtro?: FilterStatusAndamento): Promise<IStatusAndamento[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching statusandamento:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterStatusAndamento): Promise<IStatusAndamento[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching statusandamento:', error);
      return [];
    }
  }

  }