"use client";
import { GUTPeriodicidadeApi } from "../Apis/ApiGUTPeriodicidade";
import { IGUTPeriodicidade } from "../Interfaces/interface.GUTPeriodicidade";
import { FilterGUTPeriodicidade } from "../Filters/GUTPeriodicidade";

  export interface IGUTPeriodicidadeService {
    fetchGUTPeriodicidadeById: (id: number) => Promise<IGUTPeriodicidade>;
    saveGUTPeriodicidade: (gutperiodicidade: IGUTPeriodicidade) => Promise<IGUTPeriodicidade>;
    getList: (filtro?: FilterGUTPeriodicidade) => Promise<IGUTPeriodicidade[]>;
  }
  
  export class GUTPeriodicidadeService implements IGUTPeriodicidadeService {
    constructor(private api: GUTPeriodicidadeApi) {}
  
    async fetchGUTPeriodicidadeById(id: number): Promise<IGUTPeriodicidade> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveGUTPeriodicidade(gutperiodicidade: IGUTPeriodicidade): Promise<IGUTPeriodicidade> {
      const response = await this.api.addAndUpdate(gutperiodicidade as IGUTPeriodicidade);
      return response.data;
    }
 
   async getList(filtro?: FilterGUTPeriodicidade): Promise<IGUTPeriodicidade[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching gutperiodicidade:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterGUTPeriodicidade): Promise<IGUTPeriodicidade[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching gutperiodicidade:', error);
      return [];
    }
  }

  }