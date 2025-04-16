"use client";
import { ForoApi } from "../Apis/ApiForo";
import { IForo } from "../Interfaces/interface.Foro";
import { FilterForo } from "../Filters/Foro";

  export interface IForoService {
    fetchForoById: (id: number) => Promise<IForo>;
    saveForo: (foro: IForo) => Promise<IForo>;
    getList: (filtro?: FilterForo) => Promise<IForo[]>;
  }
  
  export class ForoService implements IForoService {
    constructor(private api: ForoApi) {}
  
    async fetchForoById(id: number): Promise<IForo> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveForo(foro: IForo): Promise<IForo> {
      const response = await this.api.addAndUpdate(foro as IForo);
      return response.data;
    }
 
   async getList(filtro?: FilterForo): Promise<IForo[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching foro:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterForo): Promise<IForo[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching foro:', error);
      return [];
    }
  }

  }