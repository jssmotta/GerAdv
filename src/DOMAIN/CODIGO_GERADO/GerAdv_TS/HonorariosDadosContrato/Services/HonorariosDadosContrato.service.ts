"use client";
import { HonorariosDadosContratoApi } from "../Apis/ApiHonorariosDadosContrato";
import { IHonorariosDadosContrato } from "../Interfaces/interface.HonorariosDadosContrato";
import { FilterHonorariosDadosContrato } from "../Filters/HonorariosDadosContrato";

  export interface IHonorariosDadosContratoService {
    fetchHonorariosDadosContratoById: (id: number) => Promise<IHonorariosDadosContrato>;
    saveHonorariosDadosContrato: (honorariosdadoscontrato: IHonorariosDadosContrato) => Promise<IHonorariosDadosContrato>;
    
  }
  
  export class HonorariosDadosContratoService implements IHonorariosDadosContratoService {
    constructor(private api: HonorariosDadosContratoApi) {}
  
    async fetchHonorariosDadosContratoById(id: number): Promise<IHonorariosDadosContrato> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveHonorariosDadosContrato(honorariosdadoscontrato: IHonorariosDadosContrato): Promise<IHonorariosDadosContrato> {
      const response = await this.api.addAndUpdate(honorariosdadoscontrato as IHonorariosDadosContrato);
      return response.data;
    }
 
   async getAll(filtro?: FilterHonorariosDadosContrato): Promise<IHonorariosDadosContrato[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching honorariosdadoscontrato:', error);
      return [];
    }
  }

  }