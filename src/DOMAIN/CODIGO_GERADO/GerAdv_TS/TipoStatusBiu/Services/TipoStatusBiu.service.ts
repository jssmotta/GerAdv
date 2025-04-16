"use client";
import { TipoStatusBiuApi } from "../Apis/ApiTipoStatusBiu";
import { ITipoStatusBiu } from "../Interfaces/interface.TipoStatusBiu";
import { FilterTipoStatusBiu } from "../Filters/TipoStatusBiu";

  export interface ITipoStatusBiuService {
    fetchTipoStatusBiuById: (id: number) => Promise<ITipoStatusBiu>;
    saveTipoStatusBiu: (tipostatusbiu: ITipoStatusBiu) => Promise<ITipoStatusBiu>;
    getList: (filtro?: FilterTipoStatusBiu) => Promise<ITipoStatusBiu[]>;
  }
  
  export class TipoStatusBiuService implements ITipoStatusBiuService {
    constructor(private api: TipoStatusBiuApi) {}
  
    async fetchTipoStatusBiuById(id: number): Promise<ITipoStatusBiu> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveTipoStatusBiu(tipostatusbiu: ITipoStatusBiu): Promise<ITipoStatusBiu> {
      const response = await this.api.addAndUpdate(tipostatusbiu as ITipoStatusBiu);
      return response.data;
    }
 
   async getList(filtro?: FilterTipoStatusBiu): Promise<ITipoStatusBiu[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching tipostatusbiu:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterTipoStatusBiu): Promise<ITipoStatusBiu[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching tipostatusbiu:', error);
      return [];
    }
  }

  }