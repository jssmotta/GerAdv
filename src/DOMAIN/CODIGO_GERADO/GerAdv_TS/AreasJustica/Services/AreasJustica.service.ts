"use client";
import { AreasJusticaApi } from "../Apis/ApiAreasJustica";
import { IAreasJustica } from "../Interfaces/interface.AreasJustica";
import { FilterAreasJustica } from "../Filters/AreasJustica";

  export interface IAreasJusticaService {
    fetchAreasJusticaById: (id: number) => Promise<IAreasJustica>;
    saveAreasJustica: (areasjustica: IAreasJustica) => Promise<IAreasJustica>;
    
  }
  
  export class AreasJusticaService implements IAreasJusticaService {
    constructor(private api: AreasJusticaApi) {}
  
    async fetchAreasJusticaById(id: number): Promise<IAreasJustica> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveAreasJustica(areasjustica: IAreasJustica): Promise<IAreasJustica> {
      const response = await this.api.addAndUpdate(areasjustica as IAreasJustica);
      return response.data;
    }
 
   async getAll(filtro?: FilterAreasJustica): Promise<IAreasJustica[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching areasjustica:', error);
      return [];
    }
  }

  }