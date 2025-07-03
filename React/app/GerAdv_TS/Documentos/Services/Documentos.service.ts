'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { DocumentosApi, DocumentosApiError } from '../Apis/ApiDocumentos';
import { FilterDocumentos } from '../Filters/Documentos';
import { IDocumentos } from '../Interfaces/interface.Documentos';
import { DocumentosEmpty } from '../../Models/Documentos';

export class DocumentosValidator {
  static validateDocumentos(documentos: IDocumentos): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IDocumentosService {
  fetchDocumentosById: (id: number) => Promise<IDocumentos>;
  saveDocumentos: (documentos: IDocumentos) => Promise<IDocumentos>;  
  
  getAll: (filtro?: FilterDocumentos) => Promise<IDocumentos[]>;
  deleteDocumentos: (id: number) => Promise<void>;
  validateDocumentos: (documentos: IDocumentos) => { isValid: boolean; errors: string[] };
}

export class DocumentosService implements IDocumentosService {
  constructor(private api: DocumentosApi) {}

  async fetchDocumentosById(id: number): Promise<IDocumentos> {
    if (id <= 0) {
      throw new DocumentosApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof DocumentosApiError) {
        throw error;
      }
      throw new DocumentosApiError('Erro ao buscar documentos', 500, 'FETCH_ERROR', error);
    }
  }

  async saveDocumentos(documentos: IDocumentos): Promise<IDocumentos> {    
    const validation = this.validateDocumentos(documentos);
    if (!validation.isValid) {
      throw new DocumentosApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(documentos);
      return response.data;
    } catch (error) {
      if (error instanceof DocumentosApiError) {
        throw error;
      }
      throw new DocumentosApiError('Erro ao salvar documentos', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterDocumentos): Promise<IDocumentos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all documentos:', error);
      return [];
    }
  }

  async deleteDocumentos(id: number): Promise<void> {
    if (id <= 0) {
      throw new DocumentosApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof DocumentosApiError) {
        throw error;
      }
      throw new DocumentosApiError('Erro ao excluir documentos', 500, 'DELETE_ERROR', error);
    }
  }

  validateDocumentos(documentos: IDocumentos): { isValid: boolean; errors: string[] } {
    return DocumentosValidator.validateDocumentos(documentos);
  }
}