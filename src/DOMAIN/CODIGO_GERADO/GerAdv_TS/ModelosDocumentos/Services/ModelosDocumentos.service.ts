'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ModelosDocumentosApi, ModelosDocumentosApiError } from '../Apis/ApiModelosDocumentos';
import { FilterModelosDocumentos } from '../Filters/ModelosDocumentos';
import { IModelosDocumentos } from '../Interfaces/interface.ModelosDocumentos';
import { ModelosDocumentosEmpty } from '../../Models/ModelosDocumentos';

export class ModelosDocumentosValidator {
  static validateModelosDocumentos(modelosdocumentos: IModelosDocumentos): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IModelosDocumentosService {
  fetchModelosDocumentosById: (id: number) => Promise<IModelosDocumentos>;
  saveModelosDocumentos: (modelosdocumentos: IModelosDocumentos) => Promise<IModelosDocumentos>;  
  getList: (filtro?: FilterModelosDocumentos) => Promise<IModelosDocumentos[]>;
  getAll: (filtro?: FilterModelosDocumentos) => Promise<IModelosDocumentos[]>;
  deleteModelosDocumentos: (id: number) => Promise<void>;
  validateModelosDocumentos: (modelosdocumentos: IModelosDocumentos) => { isValid: boolean; errors: string[] };
}

export class ModelosDocumentosService implements IModelosDocumentosService {
  constructor(private api: ModelosDocumentosApi) {}

  async fetchModelosDocumentosById(id: number): Promise<IModelosDocumentos> {
    if (id <= 0) {
      throw new ModelosDocumentosApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof ModelosDocumentosApiError) {
        throw error;
      }
      throw new ModelosDocumentosApiError('Erro ao buscar modelosdocumentos', 500, 'FETCH_ERROR', error);
    }
  }

  async saveModelosDocumentos(modelosdocumentos: IModelosDocumentos): Promise<IModelosDocumentos> {    
    const validation = this.validateModelosDocumentos(modelosdocumentos);
    if (!validation.isValid) {
      throw new ModelosDocumentosApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(modelosdocumentos);
      return response.data;
    } catch (error) {
      if (error instanceof ModelosDocumentosApiError) {
        throw error;
      }
      throw new ModelosDocumentosApiError('Erro ao salvar modelosdocumentos', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterModelosDocumentos): Promise<IModelosDocumentos[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching modelosdocumentos list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterModelosDocumentos): Promise<IModelosDocumentos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all modelosdocumentos:', error);
      return [];
    }
  }

  async deleteModelosDocumentos(id: number): Promise<void> {
    if (id <= 0) {
      throw new ModelosDocumentosApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ModelosDocumentosApiError) {
        throw error;
      }
      throw new ModelosDocumentosApiError('Erro ao excluir modelosdocumentos', 500, 'DELETE_ERROR', error);
    }
  }

  validateModelosDocumentos(modelosdocumentos: IModelosDocumentos): { isValid: boolean; errors: string[] } {
    return ModelosDocumentosValidator.validateModelosDocumentos(modelosdocumentos);
  }
}