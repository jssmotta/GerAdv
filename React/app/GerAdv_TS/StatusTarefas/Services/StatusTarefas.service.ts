'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { StatusTarefasApi, StatusTarefasApiError } from '../Apis/ApiStatusTarefas';
import { FilterStatusTarefas } from '../Filters/StatusTarefas';
import { IStatusTarefas } from '../Interfaces/interface.StatusTarefas';
import { StatusTarefasEmpty } from '../../Models/StatusTarefas';

export class StatusTarefasValidator {
  static validateStatusTarefas(statustarefas: IStatusTarefas): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IStatusTarefasService {
  fetchStatusTarefasById: (id: number) => Promise<IStatusTarefas>;
  saveStatusTarefas: (statustarefas: IStatusTarefas) => Promise<IStatusTarefas>;  
  getList: (filtro?: FilterStatusTarefas) => Promise<IStatusTarefas[]>;
  getAll: (filtro?: FilterStatusTarefas) => Promise<IStatusTarefas[]>;
  deleteStatusTarefas: (id: number) => Promise<void>;
  validateStatusTarefas: (statustarefas: IStatusTarefas) => { isValid: boolean; errors: string[] };
}

export class StatusTarefasService implements IStatusTarefasService {
  constructor(private api: StatusTarefasApi) {}

  async fetchStatusTarefasById(id: number): Promise<IStatusTarefas> {
    if (id <= 0) {
      throw new StatusTarefasApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof StatusTarefasApiError) {
        throw error;
      }
      throw new StatusTarefasApiError('Erro ao buscar statustarefas', 500, 'FETCH_ERROR', error);
    }
  }

  async saveStatusTarefas(statustarefas: IStatusTarefas): Promise<IStatusTarefas> {    
    const validation = this.validateStatusTarefas(statustarefas);
    if (!validation.isValid) {
      throw new StatusTarefasApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(statustarefas);
      return response.data;
    } catch (error) {
      if (error instanceof StatusTarefasApiError) {
        throw error;
      }
      throw new StatusTarefasApiError('Erro ao salvar statustarefas', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterStatusTarefas): Promise<IStatusTarefas[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching statustarefas list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterStatusTarefas): Promise<IStatusTarefas[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all statustarefas:', error);
      return [];
    }
  }

  async deleteStatusTarefas(id: number): Promise<void> {
    if (id <= 0) {
      throw new StatusTarefasApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof StatusTarefasApiError) {
        throw error;
      }
      throw new StatusTarefasApiError('Erro ao excluir statustarefas', 500, 'DELETE_ERROR', error);
    }
  }

  validateStatusTarefas(statustarefas: IStatusTarefas): { isValid: boolean; errors: string[] } {
    return StatusTarefasValidator.validateStatusTarefas(statustarefas);
  }
}