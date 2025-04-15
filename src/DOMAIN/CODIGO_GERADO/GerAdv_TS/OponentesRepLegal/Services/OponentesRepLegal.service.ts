"use client";
import { OponentesRepLegalApi } from "../Apis/ApiOponentesRepLegal";
import { IOponentesRepLegal } from "../Interfaces/interface.OponentesRepLegal";
import { FilterOponentesRepLegal } from "../Filters/OponentesRepLegal";

  export interface IOponentesRepLegalService {
    fetchOponentesRepLegalById: (id: number) => Promise<IOponentesRepLegal>;
    saveOponentesRepLegal: (oponentesreplegal: IOponentesRepLegal) => Promise<IOponentesRepLegal>;
    getList: (filtro?: FilterOponentesRepLegal) => Promise<IOponentesRepLegal[]>;
  }
  
  export class OponentesRepLegalService implements IOponentesRepLegalService {
    constructor(private api: OponentesRepLegalApi) {}
  
    async fetchOponentesRepLegalById(id: number): Promise<IOponentesRepLegal> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveOponentesRepLegal(oponentesreplegal: IOponentesRepLegal): Promise<IOponentesRepLegal> {
      const response = await this.api.addAndUpdate(oponentesreplegal as IOponentesRepLegal);
      return response.data;
    }
 
   async getList(filtro?: FilterOponentesRepLegal): Promise<IOponentesRepLegal[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching oponentesreplegal:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterOponentesRepLegal): Promise<IOponentesRepLegal[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching oponentesreplegal:', error);
      return [];
    }
  }

  }