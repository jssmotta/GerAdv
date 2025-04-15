"use client";
import { CargosApi } from "../Apis/ApiCargos";
import { ICargos } from "../Interfaces/interface.Cargos";
import { FilterCargos } from "../Filters/Cargos";

  export interface ICargosService {
    fetchCargosById: (id: number) => Promise<ICargos>;
    saveCargos: (cargos: ICargos) => Promise<ICargos>;
    getList: (filtro?: FilterCargos) => Promise<ICargos[]>;
  }
  
  export class CargosService implements ICargosService {
    constructor(private api: CargosApi) {}
  
    async fetchCargosById(id: number): Promise<ICargos> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveCargos(cargos: ICargos): Promise<ICargos> {
      const response = await this.api.addAndUpdate(cargos as ICargos);
      return response.data;
    }
 
   async getList(filtro?: FilterCargos): Promise<ICargos[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching cargos:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterCargos): Promise<ICargos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching cargos:', error);
      return [];
    }
  }

  }