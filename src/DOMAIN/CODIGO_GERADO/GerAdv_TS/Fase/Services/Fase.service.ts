"use client";
import { FaseApi } from "../Apis/ApiFase";
import { IFase } from "../Interfaces/interface.Fase";
import { FilterFase } from "../Filters/Fase";

  export interface IFaseService {
    fetchFaseById: (id: number) => Promise<IFase>;
    saveFase: (fase: IFase) => Promise<IFase>;
    getList: (filtro?: FilterFase) => Promise<IFase[]>;
  }
  
  export class FaseService implements IFaseService {
    constructor(private api: FaseApi) {}
  
    async fetchFaseById(id: number): Promise<IFase> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveFase(fase: IFase): Promise<IFase> {
      const response = await this.api.addAndUpdate(fase as IFase);
      return response.data;
    }
 
   async getList(filtro?: FilterFase): Promise<IFase[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching fase:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterFase): Promise<IFase[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching fase:', error);
      return [];
    }
  }

  }