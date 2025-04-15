"use client";
import { GruposEmpresasApi } from "../Apis/ApiGruposEmpresas";
import { IGruposEmpresas } from "../Interfaces/interface.GruposEmpresas";
import { FilterGruposEmpresas } from "../Filters/GruposEmpresas";

  export interface IGruposEmpresasService {
    fetchGruposEmpresasById: (id: number) => Promise<IGruposEmpresas>;
    saveGruposEmpresas: (gruposempresas: IGruposEmpresas) => Promise<IGruposEmpresas>;
    getList: (filtro?: FilterGruposEmpresas) => Promise<IGruposEmpresas[]>;
  }
  
  export class GruposEmpresasService implements IGruposEmpresasService {
    constructor(private api: GruposEmpresasApi) {}
  
    async fetchGruposEmpresasById(id: number): Promise<IGruposEmpresas> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveGruposEmpresas(gruposempresas: IGruposEmpresas): Promise<IGruposEmpresas> {
      const response = await this.api.addAndUpdate(gruposempresas as IGruposEmpresas);
      return response.data;
    }
 
   async getList(filtro?: FilterGruposEmpresas): Promise<IGruposEmpresas[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching gruposempresas:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterGruposEmpresas): Promise<IGruposEmpresas[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching gruposempresas:', error);
      return [];
    }
  }

  }