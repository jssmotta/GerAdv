"use client";
import { TipoProDespositoApi } from "../Apis/ApiTipoProDesposito";
import { ITipoProDesposito } from "../Interfaces/interface.TipoProDesposito";
import { FilterTipoProDesposito } from "../Filters/TipoProDesposito";

  export interface ITipoProDespositoService {
    fetchTipoProDespositoById: (id: number) => Promise<ITipoProDesposito>;
    saveTipoProDesposito: (tipoprodesposito: ITipoProDesposito) => Promise<ITipoProDesposito>;
    getList: (filtro?: FilterTipoProDesposito) => Promise<ITipoProDesposito[]>;
  }
  
  export class TipoProDespositoService implements ITipoProDespositoService {
    constructor(private api: TipoProDespositoApi) {}
  
    async fetchTipoProDespositoById(id: number): Promise<ITipoProDesposito> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveTipoProDesposito(tipoprodesposito: ITipoProDesposito): Promise<ITipoProDesposito> {
      const response = await this.api.addAndUpdate(tipoprodesposito as ITipoProDesposito);
      return response.data;
    }
 
   async getList(filtro?: FilterTipoProDesposito): Promise<ITipoProDesposito[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching tipoprodesposito:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterTipoProDesposito): Promise<ITipoProDesposito[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching tipoprodesposito:', error);
      return [];
    }
  }

  }