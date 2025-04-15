"use client";
import { CargosEscClassApi } from "../Apis/ApiCargosEscClass";
import { ICargosEscClass } from "../Interfaces/interface.CargosEscClass";
import { FilterCargosEscClass } from "../Filters/CargosEscClass";

  export interface ICargosEscClassService {
    fetchCargosEscClassById: (id: number) => Promise<ICargosEscClass>;
    saveCargosEscClass: (cargosescclass: ICargosEscClass) => Promise<ICargosEscClass>;
    getList: (filtro?: FilterCargosEscClass) => Promise<ICargosEscClass[]>;
  }
  
  export class CargosEscClassService implements ICargosEscClassService {
    constructor(private api: CargosEscClassApi) {}
  
    async fetchCargosEscClassById(id: number): Promise<ICargosEscClass> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveCargosEscClass(cargosescclass: ICargosEscClass): Promise<ICargosEscClass> {
      const response = await this.api.addAndUpdate(cargosescclass as ICargosEscClass);
      return response.data;
    }
 
   async getList(filtro?: FilterCargosEscClass): Promise<ICargosEscClass[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching cargosescclass:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterCargosEscClass): Promise<ICargosEscClass[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching cargosescclass:', error);
      return [];
    }
  }

  }