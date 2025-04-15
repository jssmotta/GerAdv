"use client";
import { TipoOrigemSucumbenciaApi } from "../Apis/ApiTipoOrigemSucumbencia";
import { ITipoOrigemSucumbencia } from "../Interfaces/interface.TipoOrigemSucumbencia";
import { FilterTipoOrigemSucumbencia } from "../Filters/TipoOrigemSucumbencia";

  export interface ITipoOrigemSucumbenciaService {
    fetchTipoOrigemSucumbenciaById: (id: number) => Promise<ITipoOrigemSucumbencia>;
    saveTipoOrigemSucumbencia: (tipoorigemsucumbencia: ITipoOrigemSucumbencia) => Promise<ITipoOrigemSucumbencia>;
    getList: (filtro?: FilterTipoOrigemSucumbencia) => Promise<ITipoOrigemSucumbencia[]>;
  }
  
  export class TipoOrigemSucumbenciaService implements ITipoOrigemSucumbenciaService {
    constructor(private api: TipoOrigemSucumbenciaApi) {}
  
    async fetchTipoOrigemSucumbenciaById(id: number): Promise<ITipoOrigemSucumbencia> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveTipoOrigemSucumbencia(tipoorigemsucumbencia: ITipoOrigemSucumbencia): Promise<ITipoOrigemSucumbencia> {
      const response = await this.api.addAndUpdate(tipoorigemsucumbencia as ITipoOrigemSucumbencia);
      return response.data;
    }
 
   async getList(filtro?: FilterTipoOrigemSucumbencia): Promise<ITipoOrigemSucumbencia[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching tipoorigemsucumbencia:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterTipoOrigemSucumbencia): Promise<ITipoOrigemSucumbencia[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching tipoorigemsucumbencia:', error);
      return [];
    }
  }

  }