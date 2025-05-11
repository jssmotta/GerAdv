"use client";
import { ModelosDocumentosApi } from "../Apis/ApiModelosDocumentos";
import { IModelosDocumentos } from "../Interfaces/interface.ModelosDocumentos";
import { FilterModelosDocumentos } from "../Filters/ModelosDocumentos";

  export interface IModelosDocumentosService {
    fetchModelosDocumentosById: (id: number) => Promise<IModelosDocumentos>;
    saveModelosDocumentos: (modelosdocumentos: IModelosDocumentos) => Promise<IModelosDocumentos>;
    getList: (filtro?: FilterModelosDocumentos) => Promise<IModelosDocumentos[]>;
  }
  
  export class ModelosDocumentosService implements IModelosDocumentosService {
    constructor(private api: ModelosDocumentosApi) {}
  
    async fetchModelosDocumentosById(id: number): Promise<IModelosDocumentos> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveModelosDocumentos(modelosdocumentos: IModelosDocumentos): Promise<IModelosDocumentos> {
      const response = await this.api.addAndUpdate(modelosdocumentos as IModelosDocumentos);
      return response.data;
    }
 
   async getList(filtro?: FilterModelosDocumentos): Promise<IModelosDocumentos[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching modelosdocumentos:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterModelosDocumentos): Promise<IModelosDocumentos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching modelosdocumentos:', error);
      return [];
    }
  }

  }