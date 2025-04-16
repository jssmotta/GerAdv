"use client";
import { EnquadramentoEmpresaApi } from "../Apis/ApiEnquadramentoEmpresa";
import { IEnquadramentoEmpresa } from "../Interfaces/interface.EnquadramentoEmpresa";
import { FilterEnquadramentoEmpresa } from "../Filters/EnquadramentoEmpresa";

  export interface IEnquadramentoEmpresaService {
    fetchEnquadramentoEmpresaById: (id: number) => Promise<IEnquadramentoEmpresa>;
    saveEnquadramentoEmpresa: (enquadramentoempresa: IEnquadramentoEmpresa) => Promise<IEnquadramentoEmpresa>;
    getList: (filtro?: FilterEnquadramentoEmpresa) => Promise<IEnquadramentoEmpresa[]>;
  }
  
  export class EnquadramentoEmpresaService implements IEnquadramentoEmpresaService {
    constructor(private api: EnquadramentoEmpresaApi) {}
  
    async fetchEnquadramentoEmpresaById(id: number): Promise<IEnquadramentoEmpresa> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveEnquadramentoEmpresa(enquadramentoempresa: IEnquadramentoEmpresa): Promise<IEnquadramentoEmpresa> {
      const response = await this.api.addAndUpdate(enquadramentoempresa as IEnquadramentoEmpresa);
      return response.data;
    }
 
   async getList(filtro?: FilterEnquadramentoEmpresa): Promise<IEnquadramentoEmpresa[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching enquadramentoempresa:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterEnquadramentoEmpresa): Promise<IEnquadramentoEmpresa[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching enquadramentoempresa:', error);
      return [];
    }
  }

  }