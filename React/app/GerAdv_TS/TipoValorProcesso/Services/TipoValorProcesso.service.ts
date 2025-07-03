'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { TipoValorProcessoApi, TipoValorProcessoApiError } from '../Apis/ApiTipoValorProcesso';
import { FilterTipoValorProcesso } from '../Filters/TipoValorProcesso';
import { ITipoValorProcesso } from '../Interfaces/interface.TipoValorProcesso';
import { TipoValorProcessoEmpty } from '../../Models/TipoValorProcesso';

export class TipoValorProcessoValidator {
  static validateTipoValorProcesso(tipovalorprocesso: ITipoValorProcesso): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface ITipoValorProcessoService {
  fetchTipoValorProcessoById: (id: number) => Promise<ITipoValorProcesso>;
  saveTipoValorProcesso: (tipovalorprocesso: ITipoValorProcesso) => Promise<ITipoValorProcesso>;  
  getList: (filtro?: FilterTipoValorProcesso) => Promise<ITipoValorProcesso[]>;
  getAll: (filtro?: FilterTipoValorProcesso) => Promise<ITipoValorProcesso[]>;
  deleteTipoValorProcesso: (id: number) => Promise<void>;
  validateTipoValorProcesso: (tipovalorprocesso: ITipoValorProcesso) => { isValid: boolean; errors: string[] };
}

export class TipoValorProcessoService implements ITipoValorProcessoService {
  constructor(private api: TipoValorProcessoApi) {}

  async fetchTipoValorProcessoById(id: number): Promise<ITipoValorProcesso> {
    if (id <= 0) {
      throw new TipoValorProcessoApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof TipoValorProcessoApiError) {
        throw error;
      }
      throw new TipoValorProcessoApiError('Erro ao buscar tipovalorprocesso', 500, 'FETCH_ERROR', error);
    }
  }

  async saveTipoValorProcesso(tipovalorprocesso: ITipoValorProcesso): Promise<ITipoValorProcesso> {    
    const validation = this.validateTipoValorProcesso(tipovalorprocesso);
    if (!validation.isValid) {
      throw new TipoValorProcessoApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(tipovalorprocesso);
      return response.data;
    } catch (error) {
      if (error instanceof TipoValorProcessoApiError) {
        throw error;
      }
      throw new TipoValorProcessoApiError('Erro ao salvar tipovalorprocesso', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterTipoValorProcesso): Promise<ITipoValorProcesso[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching tipovalorprocesso list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterTipoValorProcesso): Promise<ITipoValorProcesso[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all tipovalorprocesso:', error);
      return [];
    }
  }

  async deleteTipoValorProcesso(id: number): Promise<void> {
    if (id <= 0) {
      throw new TipoValorProcessoApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof TipoValorProcessoApiError) {
        throw error;
      }
      throw new TipoValorProcessoApiError('Erro ao excluir tipovalorprocesso', 500, 'DELETE_ERROR', error);
    }
  }

  validateTipoValorProcesso(tipovalorprocesso: ITipoValorProcesso): { isValid: boolean; errors: string[] } {
    return TipoValorProcessoValidator.validateTipoValorProcesso(tipovalorprocesso);
  }
}