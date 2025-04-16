"use client";
import { ParteClienteOutrasApi } from "../Apis/ApiParteClienteOutras";
import { IParteClienteOutras } from "../Interfaces/interface.ParteClienteOutras";
import { FilterParteClienteOutras } from "../Filters/ParteClienteOutras";

  export interface IParteClienteOutrasService {
    fetchParteClienteOutrasById: (id: number) => Promise<IParteClienteOutras>;
    saveParteClienteOutras: (parteclienteoutras: IParteClienteOutras) => Promise<IParteClienteOutras>;
    
  }
  
  export class ParteClienteOutrasService implements IParteClienteOutrasService {
    constructor(private api: ParteClienteOutrasApi) {}
  
    async fetchParteClienteOutrasById(id: number): Promise<IParteClienteOutras> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveParteClienteOutras(parteclienteoutras: IParteClienteOutras): Promise<IParteClienteOutras> {
      const response = await this.api.addAndUpdate(parteclienteoutras as IParteClienteOutras);
      return response.data;
    }
 
   async getAll(filtro?: FilterParteClienteOutras): Promise<IParteClienteOutras[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching parteclienteoutras:', error);
      return [];
    }
  }

  }