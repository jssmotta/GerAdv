"use client";
import { OutrasPartesClienteApi } from "../Apis/ApiOutrasPartesCliente";
import { IOutrasPartesCliente } from "../Interfaces/interface.OutrasPartesCliente";
import { FilterOutrasPartesCliente } from "../Filters/OutrasPartesCliente";

  export interface IOutrasPartesClienteService {
    fetchOutrasPartesClienteById: (id: number) => Promise<IOutrasPartesCliente>;
    saveOutrasPartesCliente: (outraspartescliente: IOutrasPartesCliente) => Promise<IOutrasPartesCliente>;
    getList: (filtro?: FilterOutrasPartesCliente) => Promise<IOutrasPartesCliente[]>;
  }
  
  export class OutrasPartesClienteService implements IOutrasPartesClienteService {
    constructor(private api: OutrasPartesClienteApi) {}
  
    async fetchOutrasPartesClienteById(id: number): Promise<IOutrasPartesCliente> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveOutrasPartesCliente(outraspartescliente: IOutrasPartesCliente): Promise<IOutrasPartesCliente> {
      const response = await this.api.addAndUpdate(outraspartescliente as IOutrasPartesCliente);
      return response.data;
    }
 
   async getList(filtro?: FilterOutrasPartesCliente): Promise<IOutrasPartesCliente[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching outraspartescliente:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterOutrasPartesCliente): Promise<IOutrasPartesCliente[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching outraspartescliente:', error);
      return [];
    }
  }

  }