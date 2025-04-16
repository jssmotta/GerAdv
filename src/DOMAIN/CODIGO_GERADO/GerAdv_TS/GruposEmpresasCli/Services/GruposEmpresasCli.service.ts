"use client";
import { GruposEmpresasCliApi } from "../Apis/ApiGruposEmpresasCli";
import { IGruposEmpresasCli } from "../Interfaces/interface.GruposEmpresasCli";
import { FilterGruposEmpresasCli } from "../Filters/GruposEmpresasCli";

  export interface IGruposEmpresasCliService {
    fetchGruposEmpresasCliById: (id: number) => Promise<IGruposEmpresasCli>;
    saveGruposEmpresasCli: (gruposempresascli: IGruposEmpresasCli) => Promise<IGruposEmpresasCli>;
    
  }
  
  export class GruposEmpresasCliService implements IGruposEmpresasCliService {
    constructor(private api: GruposEmpresasCliApi) {}
  
    async fetchGruposEmpresasCliById(id: number): Promise<IGruposEmpresasCli> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveGruposEmpresasCli(gruposempresascli: IGruposEmpresasCli): Promise<IGruposEmpresasCli> {
      const response = await this.api.addAndUpdate(gruposempresascli as IGruposEmpresasCli);
      return response.data;
    }
 
   async getAll(filtro?: FilterGruposEmpresasCli): Promise<IGruposEmpresasCli[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching gruposempresascli:', error);
      return [];
    }
  }

  }