'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { TipoModeloDocumentoApi, TipoModeloDocumentoApiError } from '../Apis/ApiTipoModeloDocumento';
import { FilterTipoModeloDocumento } from '../Filters/TipoModeloDocumento';
import { ITipoModeloDocumento } from '../Interfaces/interface.TipoModeloDocumento';
import { TipoModeloDocumentoEmpty } from '../../Models/TipoModeloDocumento';

export class TipoModeloDocumentoValidator {
  static validateTipoModeloDocumento(tipomodelodocumento: ITipoModeloDocumento): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface ITipoModeloDocumentoService {
  fetchTipoModeloDocumentoById: (id: number) => Promise<ITipoModeloDocumento>;
  saveTipoModeloDocumento: (tipomodelodocumento: ITipoModeloDocumento) => Promise<ITipoModeloDocumento>;  
  getList: (filtro?: FilterTipoModeloDocumento) => Promise<ITipoModeloDocumento[]>;
  getAll: (filtro?: FilterTipoModeloDocumento) => Promise<ITipoModeloDocumento[]>;
  deleteTipoModeloDocumento: (id: number) => Promise<void>;
  validateTipoModeloDocumento: (tipomodelodocumento: ITipoModeloDocumento) => { isValid: boolean; errors: string[] };
}

export class TipoModeloDocumentoService implements ITipoModeloDocumentoService {
  constructor(private api: TipoModeloDocumentoApi) {}

  async fetchTipoModeloDocumentoById(id: number): Promise<ITipoModeloDocumento> {
    if (id <= 0) {
      throw new TipoModeloDocumentoApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof TipoModeloDocumentoApiError) {
        throw error;
      }
      throw new TipoModeloDocumentoApiError('Erro ao buscar tipomodelodocumento', 500, 'FETCH_ERROR', error);
    }
  }

  async saveTipoModeloDocumento(tipomodelodocumento: ITipoModeloDocumento): Promise<ITipoModeloDocumento> {    
    const validation = this.validateTipoModeloDocumento(tipomodelodocumento);
    if (!validation.isValid) {
      throw new TipoModeloDocumentoApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(tipomodelodocumento);
      return response.data;
    } catch (error) {
      if (error instanceof TipoModeloDocumentoApiError) {
        throw error;
      }
      throw new TipoModeloDocumentoApiError('Erro ao salvar tipomodelodocumento', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterTipoModeloDocumento): Promise<ITipoModeloDocumento[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching tipomodelodocumento list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterTipoModeloDocumento): Promise<ITipoModeloDocumento[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all tipomodelodocumento:', error);
      return [];
    }
  }

  async deleteTipoModeloDocumento(id: number): Promise<void> {
    if (id <= 0) {
      throw new TipoModeloDocumentoApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof TipoModeloDocumentoApiError) {
        throw error;
      }
      throw new TipoModeloDocumentoApiError('Erro ao excluir tipomodelodocumento', 500, 'DELETE_ERROR', error);
    }
  }

  validateTipoModeloDocumento(tipomodelodocumento: ITipoModeloDocumento): { isValid: boolean; errors: string[] } {
    return TipoModeloDocumentoValidator.validateTipoModeloDocumento(tipomodelodocumento);
  }
}