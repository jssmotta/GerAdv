"use client";
import { TipoCompromissoApi } from "../Apis/ApiTipoCompromisso";
import { ITipoCompromisso } from "../Interfaces/interface.TipoCompromisso";
import { FilterTipoCompromisso } from "../Filters/TipoCompromisso";

  export interface ITipoCompromissoService {
    fetchTipoCompromissoById: (id: number) => Promise<ITipoCompromisso>;
    saveTipoCompromisso: (tipocompromisso: ITipoCompromisso) => Promise<ITipoCompromisso>;
    getList: (filtro?: FilterTipoCompromisso) => Promise<ITipoCompromisso[]>;
  }
  
  export class TipoCompromissoService implements ITipoCompromissoService {
    constructor(private api: TipoCompromissoApi) {}
  
    async fetchTipoCompromissoById(id: number): Promise<ITipoCompromisso> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveTipoCompromisso(tipocompromisso: ITipoCompromisso): Promise<ITipoCompromisso> {
      const response = await this.api.addAndUpdate(tipocompromisso as ITipoCompromisso);
      return response.data;
    }
 
   async getList(filtro?: FilterTipoCompromisso): Promise<ITipoCompromisso[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching tipocompromisso:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterTipoCompromisso): Promise<ITipoCompromisso[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching tipocompromisso:', error);
      return [];
    }
  }

  }