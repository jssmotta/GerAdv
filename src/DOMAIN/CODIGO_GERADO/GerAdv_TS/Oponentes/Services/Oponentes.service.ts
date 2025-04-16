"use client";
import { OponentesApi } from "../Apis/ApiOponentes";
import { IOponentes } from "../Interfaces/interface.Oponentes";
import { FilterOponentes } from "../Filters/Oponentes";

  export interface IOponentesService {
    fetchOponentesById: (id: number) => Promise<IOponentes>;
    saveOponentes: (oponentes: IOponentes) => Promise<IOponentes>;
    getList: (filtro?: FilterOponentes) => Promise<IOponentes[]>;
  }
  
  export class OponentesService implements IOponentesService {
    constructor(private api: OponentesApi) {}
  
    async fetchOponentesById(id: number): Promise<IOponentes> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveOponentes(oponentes: IOponentes): Promise<IOponentes> {
      const response = await this.api.addAndUpdate(oponentes as IOponentes);
      return response.data;
    }
 
   async getList(filtro?: FilterOponentes): Promise<IOponentes[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching oponentes:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterOponentes): Promise<IOponentes[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching oponentes:', error);
      return [];
    }
  }

  }