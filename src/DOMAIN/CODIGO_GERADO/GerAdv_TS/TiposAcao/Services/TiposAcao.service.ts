"use client";
import { TiposAcaoApi } from "../Apis/ApiTiposAcao";
import { ITiposAcao } from "../Interfaces/interface.TiposAcao";
import { FilterTiposAcao } from "../Filters/TiposAcao";

  export interface ITiposAcaoService {
    fetchTiposAcaoById: (id: number) => Promise<ITiposAcao>;
    saveTiposAcao: (tiposacao: ITiposAcao) => Promise<ITiposAcao>;
    getList: (filtro?: FilterTiposAcao) => Promise<ITiposAcao[]>;
  }
  
  export class TiposAcaoService implements ITiposAcaoService {
    constructor(private api: TiposAcaoApi) {}
  
    async fetchTiposAcaoById(id: number): Promise<ITiposAcao> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveTiposAcao(tiposacao: ITiposAcao): Promise<ITiposAcao> {
      const response = await this.api.addAndUpdate(tiposacao as ITiposAcao);
      return response.data;
    }
 
   async getList(filtro?: FilterTiposAcao): Promise<ITiposAcao[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching tiposacao:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterTiposAcao): Promise<ITiposAcao[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching tiposacao:', error);
      return [];
    }
  }

  }