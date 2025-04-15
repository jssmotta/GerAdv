"use client";
import { StatusHTrabApi } from "../Apis/ApiStatusHTrab";
import { IStatusHTrab } from "../Interfaces/interface.StatusHTrab";
import { FilterStatusHTrab } from "../Filters/StatusHTrab";

  export interface IStatusHTrabService {
    fetchStatusHTrabById: (id: number) => Promise<IStatusHTrab>;
    saveStatusHTrab: (statushtrab: IStatusHTrab) => Promise<IStatusHTrab>;
    getList: (filtro?: FilterStatusHTrab) => Promise<IStatusHTrab[]>;
  }
  
  export class StatusHTrabService implements IStatusHTrabService {
    constructor(private api: StatusHTrabApi) {}
  
    async fetchStatusHTrabById(id: number): Promise<IStatusHTrab> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveStatusHTrab(statushtrab: IStatusHTrab): Promise<IStatusHTrab> {
      const response = await this.api.addAndUpdate(statushtrab as IStatusHTrab);
      return response.data;
    }
 
   async getList(filtro?: FilterStatusHTrab): Promise<IStatusHTrab[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching statushtrab:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterStatusHTrab): Promise<IStatusHTrab[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching statushtrab:', error);
      return [];
    }
  }

  }