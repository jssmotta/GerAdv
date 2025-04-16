"use client";
import { ClientesSociosApi } from "../Apis/ApiClientesSocios";
import { IClientesSocios } from "../Interfaces/interface.ClientesSocios";
import { FilterClientesSocios } from "../Filters/ClientesSocios";

  export interface IClientesSociosService {
    fetchClientesSociosById: (id: number) => Promise<IClientesSocios>;
    saveClientesSocios: (clientessocios: IClientesSocios) => Promise<IClientesSocios>;
    getList: (filtro?: FilterClientesSocios) => Promise<IClientesSocios[]>;
  }
  
  export class ClientesSociosService implements IClientesSociosService {
    constructor(private api: ClientesSociosApi) {}
  
    async fetchClientesSociosById(id: number): Promise<IClientesSocios> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveClientesSocios(clientessocios: IClientesSocios): Promise<IClientesSocios> {
      const response = await this.api.addAndUpdate(clientessocios as IClientesSocios);
      return response.data;
    }
 
   async getList(filtro?: FilterClientesSocios): Promise<IClientesSocios[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching clientessocios:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterClientesSocios): Promise<IClientesSocios[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching clientessocios:', error);
      return [];
    }
  }

  }