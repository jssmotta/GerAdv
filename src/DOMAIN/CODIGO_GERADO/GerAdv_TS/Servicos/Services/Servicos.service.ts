"use client";
import { ServicosApi } from "../Apis/ApiServicos";
import { IServicos } from "../Interfaces/interface.Servicos";
import { FilterServicos } from "../Filters/Servicos";

  export interface IServicosService {
    fetchServicosById: (id: number) => Promise<IServicos>;
    saveServicos: (servicos: IServicos) => Promise<IServicos>;
    getList: (filtro?: FilterServicos) => Promise<IServicos[]>;
  }
  
  export class ServicosService implements IServicosService {
    constructor(private api: ServicosApi) {}
  
    async fetchServicosById(id: number): Promise<IServicos> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveServicos(servicos: IServicos): Promise<IServicos> {
      const response = await this.api.addAndUpdate(servicos as IServicos);
      return response.data;
    }
 
   async getList(filtro?: FilterServicos): Promise<IServicos[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching servicos:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterServicos): Promise<IServicos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching servicos:', error);
      return [];
    }
  }

  }