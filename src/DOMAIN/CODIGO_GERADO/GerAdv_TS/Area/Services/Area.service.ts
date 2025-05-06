"use client";
import { AreaApi } from "../Apis/ApiArea";
import { IArea } from "../Interfaces/interface.Area";
import { FilterArea } from "../Filters/Area";

  export interface IAreaService {
    fetchAreaById: (id: number) => Promise<IArea>;
    saveArea: (area: IArea) => Promise<IArea>;
    getList: (filtro?: FilterArea) => Promise<IArea[]>;
  }
  
  export class AreaService implements IAreaService {
    constructor(private api: AreaApi) {}
  
    async fetchAreaById(id: number): Promise<IArea> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveArea(area: IArea): Promise<IArea> {
      const response = await this.api.addAndUpdate(area as IArea);
      return response.data;
    }
 
   async getList(filtro?: FilterArea): Promise<IArea[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching area:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterArea): Promise<IArea[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching area:', error);
      return [];
    }
  }

  }