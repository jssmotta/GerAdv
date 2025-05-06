"use client";
import { TipoRecursoApi } from "../Apis/ApiTipoRecurso";
import { ITipoRecurso } from "../Interfaces/interface.TipoRecurso";
import { FilterTipoRecurso } from "../Filters/TipoRecurso";

  export interface ITipoRecursoService {
    fetchTipoRecursoById: (id: number) => Promise<ITipoRecurso>;
    saveTipoRecurso: (tiporecurso: ITipoRecurso) => Promise<ITipoRecurso>;
    getList: (filtro?: FilterTipoRecurso) => Promise<ITipoRecurso[]>;
  }
  
  export class TipoRecursoService implements ITipoRecursoService {
    constructor(private api: TipoRecursoApi) {}
  
    async fetchTipoRecursoById(id: number): Promise<ITipoRecurso> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveTipoRecurso(tiporecurso: ITipoRecurso): Promise<ITipoRecurso> {
      const response = await this.api.addAndUpdate(tiporecurso as ITipoRecurso);
      return response.data;
    }
 
   async getList(filtro?: FilterTipoRecurso): Promise<ITipoRecurso[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching tiporecurso:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterTipoRecurso): Promise<ITipoRecurso[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching tiporecurso:', error);
      return [];
    }
  }

  }