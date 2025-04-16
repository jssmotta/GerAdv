"use client";
import { StatusBiuApi } from "../Apis/ApiStatusBiu";
import { IStatusBiu } from "../Interfaces/interface.StatusBiu";
import { FilterStatusBiu } from "../Filters/StatusBiu";

  export interface IStatusBiuService {
    fetchStatusBiuById: (id: number) => Promise<IStatusBiu>;
    saveStatusBiu: (statusbiu: IStatusBiu) => Promise<IStatusBiu>;
    getList: (filtro?: FilterStatusBiu) => Promise<IStatusBiu[]>;
  }
  
  export class StatusBiuService implements IStatusBiuService {
    constructor(private api: StatusBiuApi) {}
  
    async fetchStatusBiuById(id: number): Promise<IStatusBiu> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveStatusBiu(statusbiu: IStatusBiu): Promise<IStatusBiu> {
      const response = await this.api.addAndUpdate(statusbiu as IStatusBiu);
      return response.data;
    }
 
   async getList(filtro?: FilterStatusBiu): Promise<IStatusBiu[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching statusbiu:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterStatusBiu): Promise<IStatusBiu[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching statusbiu:', error);
      return [];
    }
  }

  }