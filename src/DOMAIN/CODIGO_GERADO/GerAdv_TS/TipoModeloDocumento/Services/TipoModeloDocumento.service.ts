"use client";
import { TipoModeloDocumentoApi } from "../Apis/ApiTipoModeloDocumento";
import { ITipoModeloDocumento } from "../Interfaces/interface.TipoModeloDocumento";
import { FilterTipoModeloDocumento } from "../Filters/TipoModeloDocumento";

  export interface ITipoModeloDocumentoService {
    fetchTipoModeloDocumentoById: (id: number) => Promise<ITipoModeloDocumento>;
    saveTipoModeloDocumento: (tipomodelodocumento: ITipoModeloDocumento) => Promise<ITipoModeloDocumento>;
    getList: (filtro?: FilterTipoModeloDocumento) => Promise<ITipoModeloDocumento[]>;
  }
  
  export class TipoModeloDocumentoService implements ITipoModeloDocumentoService {
    constructor(private api: TipoModeloDocumentoApi) {}
  
    async fetchTipoModeloDocumentoById(id: number): Promise<ITipoModeloDocumento> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveTipoModeloDocumento(tipomodelodocumento: ITipoModeloDocumento): Promise<ITipoModeloDocumento> {
      const response = await this.api.addAndUpdate(tipomodelodocumento as ITipoModeloDocumento);
      return response.data;
    }
 
   async getList(filtro?: FilterTipoModeloDocumento): Promise<ITipoModeloDocumento[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching tipomodelodocumento:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterTipoModeloDocumento): Promise<ITipoModeloDocumento[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching tipomodelodocumento:', error);
      return [];
    }
  }

  }