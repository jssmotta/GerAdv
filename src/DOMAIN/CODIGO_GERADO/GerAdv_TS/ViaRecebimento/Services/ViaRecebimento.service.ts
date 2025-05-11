"use client";
import { ViaRecebimentoApi } from "../Apis/ApiViaRecebimento";
import { IViaRecebimento } from "../Interfaces/interface.ViaRecebimento";
import { FilterViaRecebimento } from "../Filters/ViaRecebimento";

  export interface IViaRecebimentoService {
    fetchViaRecebimentoById: (id: number) => Promise<IViaRecebimento>;
    saveViaRecebimento: (viarecebimento: IViaRecebimento) => Promise<IViaRecebimento>;
    getList: (filtro?: FilterViaRecebimento) => Promise<IViaRecebimento[]>;
  }
  
  export class ViaRecebimentoService implements IViaRecebimentoService {
    constructor(private api: ViaRecebimentoApi) {}
  
    async fetchViaRecebimentoById(id: number): Promise<IViaRecebimento> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveViaRecebimento(viarecebimento: IViaRecebimento): Promise<IViaRecebimento> {
      const response = await this.api.addAndUpdate(viarecebimento as IViaRecebimento);
      return response.data;
    }
 
   async getList(filtro?: FilterViaRecebimento): Promise<IViaRecebimento[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching viarecebimento:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterViaRecebimento): Promise<IViaRecebimento[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching viarecebimento:', error);
      return [];
    }
  }

  }