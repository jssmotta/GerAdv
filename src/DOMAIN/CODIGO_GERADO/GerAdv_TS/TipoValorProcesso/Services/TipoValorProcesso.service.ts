"use client";
import { TipoValorProcessoApi } from "../Apis/ApiTipoValorProcesso";
import { ITipoValorProcesso } from "../Interfaces/interface.TipoValorProcesso";
import { FilterTipoValorProcesso } from "../Filters/TipoValorProcesso";

  export interface ITipoValorProcessoService {
    fetchTipoValorProcessoById: (id: number) => Promise<ITipoValorProcesso>;
    saveTipoValorProcesso: (tipovalorprocesso: ITipoValorProcesso) => Promise<ITipoValorProcesso>;
    getList: (filtro?: FilterTipoValorProcesso) => Promise<ITipoValorProcesso[]>;
  }
  
  export class TipoValorProcessoService implements ITipoValorProcessoService {
    constructor(private api: TipoValorProcessoApi) {}
  
    async fetchTipoValorProcessoById(id: number): Promise<ITipoValorProcesso> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveTipoValorProcesso(tipovalorprocesso: ITipoValorProcesso): Promise<ITipoValorProcesso> {
      const response = await this.api.addAndUpdate(tipovalorprocesso as ITipoValorProcesso);
      return response.data;
    }
 
   async getList(filtro?: FilterTipoValorProcesso): Promise<ITipoValorProcesso[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching tipovalorprocesso:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterTipoValorProcesso): Promise<ITipoValorProcesso[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching tipovalorprocesso:', error);
      return [];
    }
  }

  }