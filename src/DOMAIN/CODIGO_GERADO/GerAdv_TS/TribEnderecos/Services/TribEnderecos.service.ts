"use client";
import { TribEnderecosApi } from "../Apis/ApiTribEnderecos";
import { ITribEnderecos } from "../Interfaces/interface.TribEnderecos";
import { FilterTribEnderecos } from "../Filters/TribEnderecos";

  export interface ITribEnderecosService {
    fetchTribEnderecosById: (id: number) => Promise<ITribEnderecos>;
    saveTribEnderecos: (tribenderecos: ITribEnderecos) => Promise<ITribEnderecos>;
    
  }
  
  export class TribEnderecosService implements ITribEnderecosService {
    constructor(private api: TribEnderecosApi) {}
  
    async fetchTribEnderecosById(id: number): Promise<ITribEnderecos> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveTribEnderecos(tribenderecos: ITribEnderecos): Promise<ITribEnderecos> {
      const response = await this.api.addAndUpdate(tribenderecos as ITribEnderecos);
      return response.data;
    }
 
   async getAll(filtro?: FilterTribEnderecos): Promise<ITribEnderecos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching tribenderecos:', error);
      return [];
    }
  }

  }