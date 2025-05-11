"use client";
import { Diario2Api } from "../Apis/ApiDiario2";
import { IDiario2 } from "../Interfaces/interface.Diario2";
import { FilterDiario2 } from "../Filters/Diario2";

  export interface IDiario2Service {
    fetchDiario2ById: (id: number) => Promise<IDiario2>;
    saveDiario2: (diario2: IDiario2) => Promise<IDiario2>;
    getList: (filtro?: FilterDiario2) => Promise<IDiario2[]>;
  }
  
  export class Diario2Service implements IDiario2Service {
    constructor(private api: Diario2Api) {}
  
    async fetchDiario2ById(id: number): Promise<IDiario2> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveDiario2(diario2: IDiario2): Promise<IDiario2> {
      const response = await this.api.addAndUpdate(diario2 as IDiario2);
      return response.data;
    }
 
   async getList(filtro?: FilterDiario2): Promise<IDiario2[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching diario2:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterDiario2): Promise<IDiario2[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching diario2:', error);
      return [];
    }
  }

  }