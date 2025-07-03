'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { TipoContatoCRMApi, TipoContatoCRMApiError } from '../Apis/ApiTipoContatoCRM';
import { FilterTipoContatoCRM } from '../Filters/TipoContatoCRM';
import { ITipoContatoCRM } from '../Interfaces/interface.TipoContatoCRM';
import { TipoContatoCRMEmpty } from '../../Models/TipoContatoCRM';

export class TipoContatoCRMValidator {
  static validateTipoContatoCRM(tipocontatocrm: ITipoContatoCRM): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface ITipoContatoCRMService {
  fetchTipoContatoCRMById: (id: number) => Promise<ITipoContatoCRM>;
  saveTipoContatoCRM: (tipocontatocrm: ITipoContatoCRM) => Promise<ITipoContatoCRM>;  
  getList: (filtro?: FilterTipoContatoCRM) => Promise<ITipoContatoCRM[]>;
  getAll: (filtro?: FilterTipoContatoCRM) => Promise<ITipoContatoCRM[]>;
  deleteTipoContatoCRM: (id: number) => Promise<void>;
  validateTipoContatoCRM: (tipocontatocrm: ITipoContatoCRM) => { isValid: boolean; errors: string[] };
}

export class TipoContatoCRMService implements ITipoContatoCRMService {
  constructor(private api: TipoContatoCRMApi) {}

  async fetchTipoContatoCRMById(id: number): Promise<ITipoContatoCRM> {
    if (id <= 0) {
      throw new TipoContatoCRMApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof TipoContatoCRMApiError) {
        throw error;
      }
      throw new TipoContatoCRMApiError('Erro ao buscar tipocontatocrm', 500, 'FETCH_ERROR', error);
    }
  }

  async saveTipoContatoCRM(tipocontatocrm: ITipoContatoCRM): Promise<ITipoContatoCRM> {    
    const validation = this.validateTipoContatoCRM(tipocontatocrm);
    if (!validation.isValid) {
      throw new TipoContatoCRMApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(tipocontatocrm);
      return response.data;
    } catch (error) {
      if (error instanceof TipoContatoCRMApiError) {
        throw error;
      }
      throw new TipoContatoCRMApiError('Erro ao salvar tipocontatocrm', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterTipoContatoCRM): Promise<ITipoContatoCRM[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching tipocontatocrm list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterTipoContatoCRM): Promise<ITipoContatoCRM[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all tipocontatocrm:', error);
      return [];
    }
  }

  async deleteTipoContatoCRM(id: number): Promise<void> {
    if (id <= 0) {
      throw new TipoContatoCRMApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof TipoContatoCRMApiError) {
        throw error;
      }
      throw new TipoContatoCRMApiError('Erro ao excluir tipocontatocrm', 500, 'DELETE_ERROR', error);
    }
  }

  validateTipoContatoCRM(tipocontatocrm: ITipoContatoCRM): { isValid: boolean; errors: string[] } {
    return TipoContatoCRMValidator.validateTipoContatoCRM(tipocontatocrm);
  }
}