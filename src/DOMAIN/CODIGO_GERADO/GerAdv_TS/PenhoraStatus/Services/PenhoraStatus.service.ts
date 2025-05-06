"use client";
import { PenhoraStatusApi } from "../Apis/ApiPenhoraStatus";
import { IPenhoraStatus } from "../Interfaces/interface.PenhoraStatus";
import { FilterPenhoraStatus } from "../Filters/PenhoraStatus";

  export interface IPenhoraStatusService {
    fetchPenhoraStatusById: (id: number) => Promise<IPenhoraStatus>;
    savePenhoraStatus: (penhorastatus: IPenhoraStatus) => Promise<IPenhoraStatus>;
    getList: (filtro?: FilterPenhoraStatus) => Promise<IPenhoraStatus[]>;
  }
  
  export class PenhoraStatusService implements IPenhoraStatusService {
    constructor(private api: PenhoraStatusApi) {}
  
    async fetchPenhoraStatusById(id: number): Promise<IPenhoraStatus> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async savePenhoraStatus(penhorastatus: IPenhoraStatus): Promise<IPenhoraStatus> {
      const response = await this.api.addAndUpdate(penhorastatus as IPenhoraStatus);
      return response.data;
    }
 
   async getList(filtro?: FilterPenhoraStatus): Promise<IPenhoraStatus[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching penhorastatus:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterPenhoraStatus): Promise<IPenhoraStatus[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching penhorastatus:', error);
      return [];
    }
  }

  }