"use client";
import { PosicaoOutrasPartesApi } from "../Apis/ApiPosicaoOutrasPartes";
import { IPosicaoOutrasPartes } from "../Interfaces/interface.PosicaoOutrasPartes";
import { FilterPosicaoOutrasPartes } from "../Filters/PosicaoOutrasPartes";

  export interface IPosicaoOutrasPartesService {
    fetchPosicaoOutrasPartesById: (id: number) => Promise<IPosicaoOutrasPartes>;
    savePosicaoOutrasPartes: (posicaooutraspartes: IPosicaoOutrasPartes) => Promise<IPosicaoOutrasPartes>;
    getList: (filtro?: FilterPosicaoOutrasPartes) => Promise<IPosicaoOutrasPartes[]>;
  }
  
  export class PosicaoOutrasPartesService implements IPosicaoOutrasPartesService {
    constructor(private api: PosicaoOutrasPartesApi) {}
  
    async fetchPosicaoOutrasPartesById(id: number): Promise<IPosicaoOutrasPartes> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async savePosicaoOutrasPartes(posicaooutraspartes: IPosicaoOutrasPartes): Promise<IPosicaoOutrasPartes> {
      const response = await this.api.addAndUpdate(posicaooutraspartes as IPosicaoOutrasPartes);
      return response.data;
    }
 
   async getList(filtro?: FilterPosicaoOutrasPartes): Promise<IPosicaoOutrasPartes[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching posicaooutraspartes:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterPosicaoOutrasPartes): Promise<IPosicaoOutrasPartes[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching posicaooutraspartes:', error);
      return [];
    }
  }

  }