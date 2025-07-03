'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { TerceirosApi, TerceirosApiError } from '../Apis/ApiTerceiros';
import { FilterTerceiros } from '../Filters/Terceiros';
import { ITerceiros } from '../Interfaces/interface.Terceiros';
import { TerceirosEmpty } from '../../Models/Terceiros';

export class TerceirosValidator {
  static validateTerceiros(terceiros: ITerceiros): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface ITerceirosService {
  fetchTerceirosById: (id: number) => Promise<ITerceiros>;
  saveTerceiros: (terceiros: ITerceiros) => Promise<ITerceiros>;  
  getList: (filtro?: FilterTerceiros) => Promise<ITerceiros[]>;
  getAll: (filtro?: FilterTerceiros) => Promise<ITerceiros[]>;
  deleteTerceiros: (id: number) => Promise<void>;
  validateTerceiros: (terceiros: ITerceiros) => { isValid: boolean; errors: string[] };
}

export class TerceirosService implements ITerceirosService {
  constructor(private api: TerceirosApi) {}

  async fetchTerceirosById(id: number): Promise<ITerceiros> {
    if (id <= 0) {
      throw new TerceirosApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof TerceirosApiError) {
        throw error;
      }
      throw new TerceirosApiError('Erro ao buscar terceiros', 500, 'FETCH_ERROR', error);
    }
  }

  async saveTerceiros(terceiros: ITerceiros): Promise<ITerceiros> {    
    const validation = this.validateTerceiros(terceiros);
    if (!validation.isValid) {
      throw new TerceirosApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(terceiros);
      return response.data;
    } catch (error) {
      if (error instanceof TerceirosApiError) {
        throw error;
      }
      throw new TerceirosApiError('Erro ao salvar terceiros', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterTerceiros): Promise<ITerceiros[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching terceiros list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterTerceiros): Promise<ITerceiros[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all terceiros:', error);
      return [];
    }
  }

  async deleteTerceiros(id: number): Promise<void> {
    if (id <= 0) {
      throw new TerceirosApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof TerceirosApiError) {
        throw error;
      }
      throw new TerceirosApiError('Erro ao excluir terceiros', 500, 'DELETE_ERROR', error);
    }
  }

  validateTerceiros(terceiros: ITerceiros): { isValid: boolean; errors: string[] } {
    return TerceirosValidator.validateTerceiros(terceiros);
  }
}