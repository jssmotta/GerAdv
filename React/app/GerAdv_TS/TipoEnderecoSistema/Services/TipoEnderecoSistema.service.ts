'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { TipoEnderecoSistemaApi, TipoEnderecoSistemaApiError } from '../Apis/ApiTipoEnderecoSistema';
import { FilterTipoEnderecoSistema } from '../Filters/TipoEnderecoSistema';
import { ITipoEnderecoSistema } from '../Interfaces/interface.TipoEnderecoSistema';
import { TipoEnderecoSistemaEmpty } from '../../Models/TipoEnderecoSistema';

export class TipoEnderecoSistemaValidator {
  static validateTipoEnderecoSistema(tipoenderecosistema: ITipoEnderecoSistema): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface ITipoEnderecoSistemaService {
  fetchTipoEnderecoSistemaById: (id: number) => Promise<ITipoEnderecoSistema>;
  saveTipoEnderecoSistema: (tipoenderecosistema: ITipoEnderecoSistema) => Promise<ITipoEnderecoSistema>;  
  getList: (filtro?: FilterTipoEnderecoSistema) => Promise<ITipoEnderecoSistema[]>;
  getAll: (filtro?: FilterTipoEnderecoSistema) => Promise<ITipoEnderecoSistema[]>;
  deleteTipoEnderecoSistema: (id: number) => Promise<void>;
  validateTipoEnderecoSistema: (tipoenderecosistema: ITipoEnderecoSistema) => { isValid: boolean; errors: string[] };
}

export class TipoEnderecoSistemaService implements ITipoEnderecoSistemaService {
  constructor(private api: TipoEnderecoSistemaApi) {}

  async fetchTipoEnderecoSistemaById(id: number): Promise<ITipoEnderecoSistema> {
    if (id <= 0) {
      throw new TipoEnderecoSistemaApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof TipoEnderecoSistemaApiError) {
        throw error;
      }
      throw new TipoEnderecoSistemaApiError('Erro ao buscar tipoenderecosistema', 500, 'FETCH_ERROR', error);
    }
  }

  async saveTipoEnderecoSistema(tipoenderecosistema: ITipoEnderecoSistema): Promise<ITipoEnderecoSistema> {    
    const validation = this.validateTipoEnderecoSistema(tipoenderecosistema);
    if (!validation.isValid) {
      throw new TipoEnderecoSistemaApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(tipoenderecosistema);
      return response.data;
    } catch (error) {
      if (error instanceof TipoEnderecoSistemaApiError) {
        throw error;
      }
      throw new TipoEnderecoSistemaApiError('Erro ao salvar tipoenderecosistema', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterTipoEnderecoSistema): Promise<ITipoEnderecoSistema[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching tipoenderecosistema list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterTipoEnderecoSistema): Promise<ITipoEnderecoSistema[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all tipoenderecosistema:', error);
      return [];
    }
  }

  async deleteTipoEnderecoSistema(id: number): Promise<void> {
    if (id <= 0) {
      throw new TipoEnderecoSistemaApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof TipoEnderecoSistemaApiError) {
        throw error;
      }
      throw new TipoEnderecoSistemaApiError('Erro ao excluir tipoenderecosistema', 500, 'DELETE_ERROR', error);
    }
  }

  validateTipoEnderecoSistema(tipoenderecosistema: ITipoEnderecoSistema): { isValid: boolean; errors: string[] } {
    return TipoEnderecoSistemaValidator.validateTipoEnderecoSistema(tipoenderecosistema);
  }
}