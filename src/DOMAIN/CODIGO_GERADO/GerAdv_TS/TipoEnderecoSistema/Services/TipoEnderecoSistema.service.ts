"use client";
import { TipoEnderecoSistemaApi } from "../Apis/ApiTipoEnderecoSistema";
import { ITipoEnderecoSistema } from "../Interfaces/interface.TipoEnderecoSistema";
import { FilterTipoEnderecoSistema } from "../Filters/TipoEnderecoSistema";

  export interface ITipoEnderecoSistemaService {
    fetchTipoEnderecoSistemaById: (id: number) => Promise<ITipoEnderecoSistema>;
    saveTipoEnderecoSistema: (tipoenderecosistema: ITipoEnderecoSistema) => Promise<ITipoEnderecoSistema>;
    getList: (filtro?: FilterTipoEnderecoSistema) => Promise<ITipoEnderecoSistema[]>;
  }
  
  export class TipoEnderecoSistemaService implements ITipoEnderecoSistemaService {
    constructor(private api: TipoEnderecoSistemaApi) {}
  
    async fetchTipoEnderecoSistemaById(id: number): Promise<ITipoEnderecoSistema> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveTipoEnderecoSistema(tipoenderecosistema: ITipoEnderecoSistema): Promise<ITipoEnderecoSistema> {
      const response = await this.api.addAndUpdate(tipoenderecosistema as ITipoEnderecoSistema);
      return response.data;
    }
 
   async getList(filtro?: FilterTipoEnderecoSistema): Promise<ITipoEnderecoSistema[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching tipoenderecosistema:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterTipoEnderecoSistema): Promise<ITipoEnderecoSistema[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching tipoenderecosistema:', error);
      return [];
    }
  }

  }