"use client";
import { ProDepositosApi } from "../Apis/ApiProDepositos";
import { IProDepositos } from "../Interfaces/interface.ProDepositos";
import { FilterProDepositos } from "../Filters/ProDepositos";

  export interface IProDepositosService {
    fetchProDepositosById: (id: number) => Promise<IProDepositos>;
    saveProDepositos: (prodepositos: IProDepositos) => Promise<IProDepositos>;
    
  }
  
  export class ProDepositosService implements IProDepositosService {
    constructor(private api: ProDepositosApi) {}
  
    async fetchProDepositosById(id: number): Promise<IProDepositos> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveProDepositos(prodepositos: IProDepositos): Promise<IProDepositos> {
      const response = await this.api.addAndUpdate(prodepositos as IProDepositos);
      return response.data;
    }
 
   async getAll(filtro?: FilterProDepositos): Promise<IProDepositos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching prodepositos:', error);
      return [];
    }
  }

  }