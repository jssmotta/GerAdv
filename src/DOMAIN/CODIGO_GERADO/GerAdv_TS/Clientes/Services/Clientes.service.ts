"use client";
import { ClientesApi } from "../Apis/ApiClientes";
import { IClientes } from "../Interfaces/interface.Clientes";
import { FilterClientes } from "../Filters/Clientes";

  export interface IClientesService {
    fetchClientesById: (id: number) => Promise<IClientes>;
    saveClientes: (clientes: IClientes) => Promise<IClientes>;
    getList: (filtro?: FilterClientes) => Promise<IClientes[]>;
  }
  
  export class ClientesService implements IClientesService {
    constructor(private api: ClientesApi) {}
  
    async fetchClientesById(id: number): Promise<IClientes> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveClientes(clientes: IClientes): Promise<IClientes> {
      const response = await this.api.addAndUpdate(clientes as IClientes);
      return response.data;
    }
 
   async getList(filtro?: FilterClientes): Promise<IClientes[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching clientes:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterClientes): Promise<IClientes[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching clientes:', error);
      return [];
    }
  }

  }