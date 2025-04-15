"use client";
import { HorasTrabApi } from "../Apis/ApiHorasTrab";
import { IHorasTrab } from "../Interfaces/interface.HorasTrab";
import { FilterHorasTrab } from "../Filters/HorasTrab";

  export interface IHorasTrabService {
    fetchHorasTrabById: (id: number) => Promise<IHorasTrab>;
    saveHorasTrab: (horastrab: IHorasTrab) => Promise<IHorasTrab>;
    
  }
  
  export class HorasTrabService implements IHorasTrabService {
    constructor(private api: HorasTrabApi) {}
  
    async fetchHorasTrabById(id: number): Promise<IHorasTrab> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveHorasTrab(horastrab: IHorasTrab): Promise<IHorasTrab> {
      const response = await this.api.addAndUpdate(horastrab as IHorasTrab);
      return response.data;
    }
 
   async getAll(filtro?: FilterHorasTrab): Promise<IHorasTrab[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching horastrab:', error);
      return [];
    }
  }

  }