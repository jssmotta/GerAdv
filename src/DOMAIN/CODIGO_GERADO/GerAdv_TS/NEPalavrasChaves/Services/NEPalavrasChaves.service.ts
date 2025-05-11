"use client";
import { NEPalavrasChavesApi } from "../Apis/ApiNEPalavrasChaves";
import { INEPalavrasChaves } from "../Interfaces/interface.NEPalavrasChaves";
import { FilterNEPalavrasChaves } from "../Filters/NEPalavrasChaves";

  export interface INEPalavrasChavesService {
    fetchNEPalavrasChavesById: (id: number) => Promise<INEPalavrasChaves>;
    saveNEPalavrasChaves: (nepalavraschaves: INEPalavrasChaves) => Promise<INEPalavrasChaves>;
    getList: (filtro?: FilterNEPalavrasChaves) => Promise<INEPalavrasChaves[]>;
  }
  
  export class NEPalavrasChavesService implements INEPalavrasChavesService {
    constructor(private api: NEPalavrasChavesApi) {}
  
    async fetchNEPalavrasChavesById(id: number): Promise<INEPalavrasChaves> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveNEPalavrasChaves(nepalavraschaves: INEPalavrasChaves): Promise<INEPalavrasChaves> {
      const response = await this.api.addAndUpdate(nepalavraschaves as INEPalavrasChaves);
      return response.data;
    }
 
   async getList(filtro?: FilterNEPalavrasChaves): Promise<INEPalavrasChaves[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching nepalavraschaves:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterNEPalavrasChaves): Promise<INEPalavrasChaves[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching nepalavraschaves:', error);
      return [];
    }
  }

  }