"use client";
import { ProCDAApi } from "../Apis/ApiProCDA";
import { IProCDA } from "../Interfaces/interface.ProCDA";
import { FilterProCDA } from "../Filters/ProCDA";

  export interface IProCDAService {
    fetchProCDAById: (id: number) => Promise<IProCDA>;
    saveProCDA: (procda: IProCDA) => Promise<IProCDA>;
    getList: (filtro?: FilterProCDA) => Promise<IProCDA[]>;
  }
  
  export class ProCDAService implements IProCDAService {
    constructor(private api: ProCDAApi) {}
  
    async fetchProCDAById(id: number): Promise<IProCDA> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveProCDA(procda: IProCDA): Promise<IProCDA> {
      const response = await this.api.addAndUpdate(procda as IProCDA);
      return response.data;
    }
 
   async getList(filtro?: FilterProCDA): Promise<IProCDA[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching procda:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterProCDA): Promise<IProCDA[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching procda:', error);
      return [];
    }
  }

  }