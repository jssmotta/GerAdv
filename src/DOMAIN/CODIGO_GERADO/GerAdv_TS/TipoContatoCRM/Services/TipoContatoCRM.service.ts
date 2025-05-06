"use client";
import { TipoContatoCRMApi } from "../Apis/ApiTipoContatoCRM";
import { ITipoContatoCRM } from "../Interfaces/interface.TipoContatoCRM";
import { FilterTipoContatoCRM } from "../Filters/TipoContatoCRM";

  export interface ITipoContatoCRMService {
    fetchTipoContatoCRMById: (id: number) => Promise<ITipoContatoCRM>;
    saveTipoContatoCRM: (tipocontatocrm: ITipoContatoCRM) => Promise<ITipoContatoCRM>;
    getList: (filtro?: FilterTipoContatoCRM) => Promise<ITipoContatoCRM[]>;
  }
  
  export class TipoContatoCRMService implements ITipoContatoCRMService {
    constructor(private api: TipoContatoCRMApi) {}
  
    async fetchTipoContatoCRMById(id: number): Promise<ITipoContatoCRM> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveTipoContatoCRM(tipocontatocrm: ITipoContatoCRM): Promise<ITipoContatoCRM> {
      const response = await this.api.addAndUpdate(tipocontatocrm as ITipoContatoCRM);
      return response.data;
    }
 
   async getList(filtro?: FilterTipoContatoCRM): Promise<ITipoContatoCRM[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching tipocontatocrm:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterTipoContatoCRM): Promise<ITipoContatoCRM[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching tipocontatocrm:', error);
      return [];
    }
  }

  }