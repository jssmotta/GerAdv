"use client";
import { AndCompApi } from "../Apis/ApiAndComp";
import { IAndComp } from "../Interfaces/interface.AndComp";
import { FilterAndComp } from "../Filters/AndComp";

  export interface IAndCompService {
    fetchAndCompById: (id: number) => Promise<IAndComp>;
    saveAndComp: (andcomp: IAndComp) => Promise<IAndComp>;
    
  }
  
  export class AndCompService implements IAndCompService {
    constructor(private api: AndCompApi) {}
  
    async fetchAndCompById(id: number): Promise<IAndComp> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveAndComp(andcomp: IAndComp): Promise<IAndComp> {
      const response = await this.api.addAndUpdate(andcomp as IAndComp);
      return response.data;
    }
 
   async getAll(filtro?: FilterAndComp): Promise<IAndComp[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching andcomp:', error);
      return [];
    }
  }

  }