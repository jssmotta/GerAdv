"use client";
import { BensMateriaisApi } from "../Apis/ApiBensMateriais";
import { IBensMateriais } from "../Interfaces/interface.BensMateriais";
import { FilterBensMateriais } from "../Filters/BensMateriais";

  export interface IBensMateriaisService {
    fetchBensMateriaisById: (id: number) => Promise<IBensMateriais>;
    saveBensMateriais: (bensmateriais: IBensMateriais) => Promise<IBensMateriais>;
    getList: (filtro?: FilterBensMateriais) => Promise<IBensMateriais[]>;
  }
  
  export class BensMateriaisService implements IBensMateriaisService {
    constructor(private api: BensMateriaisApi) {}
  
    async fetchBensMateriaisById(id: number): Promise<IBensMateriais> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveBensMateriais(bensmateriais: IBensMateriais): Promise<IBensMateriais> {
      const response = await this.api.addAndUpdate(bensmateriais as IBensMateriais);
      return response.data;
    }
 
   async getList(filtro?: FilterBensMateriais): Promise<IBensMateriais[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching bensmateriais:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterBensMateriais): Promise<IBensMateriais[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching bensmateriais:', error);
      return [];
    }
  }

  }