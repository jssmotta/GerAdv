"use client";
import { GUTPeriodicidadeStatusApi } from "../Apis/ApiGUTPeriodicidadeStatus";
import { IGUTPeriodicidadeStatus } from "../Interfaces/interface.GUTPeriodicidadeStatus";
import { FilterGUTPeriodicidadeStatus } from "../Filters/GUTPeriodicidadeStatus";

  export interface IGUTPeriodicidadeStatusService {
    fetchGUTPeriodicidadeStatusById: (id: number) => Promise<IGUTPeriodicidadeStatus>;
    saveGUTPeriodicidadeStatus: (gutperiodicidadestatus: IGUTPeriodicidadeStatus) => Promise<IGUTPeriodicidadeStatus>;
    
  }
  
  export class GUTPeriodicidadeStatusService implements IGUTPeriodicidadeStatusService {
    constructor(private api: GUTPeriodicidadeStatusApi) {}
  
    async fetchGUTPeriodicidadeStatusById(id: number): Promise<IGUTPeriodicidadeStatus> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveGUTPeriodicidadeStatus(gutperiodicidadestatus: IGUTPeriodicidadeStatus): Promise<IGUTPeriodicidadeStatus> {
      const response = await this.api.addAndUpdate(gutperiodicidadestatus as IGUTPeriodicidadeStatus);
      return response.data;
    }
 
   async getAll(filtro?: FilterGUTPeriodicidadeStatus): Promise<IGUTPeriodicidadeStatus[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching gutperiodicidadestatus:', error);
      return [];
    }
  }

  }