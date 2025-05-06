"use client";
import { TipoEnderecoApi } from "../Apis/ApiTipoEndereco";
import { ITipoEndereco } from "../Interfaces/interface.TipoEndereco";
import { FilterTipoEndereco } from "../Filters/TipoEndereco";

  export interface ITipoEnderecoService {
    fetchTipoEnderecoById: (id: number) => Promise<ITipoEndereco>;
    saveTipoEndereco: (tipoendereco: ITipoEndereco) => Promise<ITipoEndereco>;
    getList: (filtro?: FilterTipoEndereco) => Promise<ITipoEndereco[]>;
  }
  
  export class TipoEnderecoService implements ITipoEnderecoService {
    constructor(private api: TipoEnderecoApi) {}
  
    async fetchTipoEnderecoById(id: number): Promise<ITipoEndereco> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveTipoEndereco(tipoendereco: ITipoEndereco): Promise<ITipoEndereco> {
      const response = await this.api.addAndUpdate(tipoendereco as ITipoEndereco);
      return response.data;
    }
 
   async getList(filtro?: FilterTipoEndereco): Promise<ITipoEndereco[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching tipoendereco:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterTipoEndereco): Promise<ITipoEndereco[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching tipoendereco:', error);
      return [];
    }
  }

  }