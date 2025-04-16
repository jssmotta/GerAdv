"use client";
import { CargosEscApi } from "../Apis/ApiCargosEsc";
import { ICargosEsc } from "../Interfaces/interface.CargosEsc";
import { FilterCargosEsc } from "../Filters/CargosEsc";

  export interface ICargosEscService {
    fetchCargosEscById: (id: number) => Promise<ICargosEsc>;
    saveCargosEsc: (cargosesc: ICargosEsc) => Promise<ICargosEsc>;
    getList: (filtro?: FilterCargosEsc) => Promise<ICargosEsc[]>;
  }
  
  export class CargosEscService implements ICargosEscService {
    constructor(private api: CargosEscApi) {}
  
    async fetchCargosEscById(id: number): Promise<ICargosEsc> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveCargosEsc(cargosesc: ICargosEsc): Promise<ICargosEsc> {
      const response = await this.api.addAndUpdate(cargosesc as ICargosEsc);
      return response.data;
    }
 
   async getList(filtro?: FilterCargosEsc): Promise<ICargosEsc[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching cargosesc:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterCargosEsc): Promise<ICargosEsc[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching cargosesc:', error);
      return [];
    }
  }

  }