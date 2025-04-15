"use client";
import { OperadorGrupoApi } from "../Apis/ApiOperadorGrupo";
import { IOperadorGrupo } from "../Interfaces/interface.OperadorGrupo";
import { FilterOperadorGrupo } from "../Filters/OperadorGrupo";

  export interface IOperadorGrupoService {
    fetchOperadorGrupoById: (id: number) => Promise<IOperadorGrupo>;
    saveOperadorGrupo: (operadorgrupo: IOperadorGrupo) => Promise<IOperadorGrupo>;
    
  }
  
  export class OperadorGrupoService implements IOperadorGrupoService {
    constructor(private api: OperadorGrupoApi) {}
  
    async fetchOperadorGrupoById(id: number): Promise<IOperadorGrupo> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveOperadorGrupo(operadorgrupo: IOperadorGrupo): Promise<IOperadorGrupo> {
      const response = await this.api.addAndUpdate(operadorgrupo as IOperadorGrupo);
      return response.data;
    }
 
   async getAll(filtro?: FilterOperadorGrupo): Promise<IOperadorGrupo[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching operadorgrupo:', error);
      return [];
    }
  }

  }