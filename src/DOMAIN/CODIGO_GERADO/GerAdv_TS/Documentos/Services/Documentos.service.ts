"use client";
import { DocumentosApi } from "../Apis/ApiDocumentos";
import { IDocumentos } from "../Interfaces/interface.Documentos";
import { FilterDocumentos } from "../Filters/Documentos";

  export interface IDocumentosService {
    fetchDocumentosById: (id: number) => Promise<IDocumentos>;
    saveDocumentos: (documentos: IDocumentos) => Promise<IDocumentos>;
    
  }
  
  export class DocumentosService implements IDocumentosService {
    constructor(private api: DocumentosApi) {}
  
    async fetchDocumentosById(id: number): Promise<IDocumentos> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveDocumentos(documentos: IDocumentos): Promise<IDocumentos> {
      const response = await this.api.addAndUpdate(documentos as IDocumentos);
      return response.data;
    }
 
   async getAll(filtro?: FilterDocumentos): Promise<IDocumentos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching documentos:', error);
      return [];
    }
  }

  }