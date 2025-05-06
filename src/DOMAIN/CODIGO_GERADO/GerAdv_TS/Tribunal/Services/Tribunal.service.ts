"use client";
import { TribunalApi } from "../Apis/ApiTribunal";
import { ITribunal } from "../Interfaces/interface.Tribunal";
import { FilterTribunal } from "../Filters/Tribunal";

  export interface ITribunalService {
    fetchTribunalById: (id: number) => Promise<ITribunal>;
    saveTribunal: (tribunal: ITribunal) => Promise<ITribunal>;
    getList: (filtro?: FilterTribunal) => Promise<ITribunal[]>;
  }
  
  export class TribunalService implements ITribunalService {
    constructor(private api: TribunalApi) {}
  
    async fetchTribunalById(id: number): Promise<ITribunal> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveTribunal(tribunal: ITribunal): Promise<ITribunal> {
      const response = await this.api.addAndUpdate(tribunal as ITribunal);
      return response.data;
    }
 
   async getList(filtro?: FilterTribunal): Promise<ITribunal[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching tribunal:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterTribunal): Promise<ITribunal[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching tribunal:', error);
      return [];
    }
  }

  }