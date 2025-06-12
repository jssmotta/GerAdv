'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { StatusHTrabApi, StatusHTrabApiError } from '../Apis/ApiStatusHTrab';
import { FilterStatusHTrab } from '../Filters/StatusHTrab';
import { IStatusHTrab } from '../Interfaces/interface.StatusHTrab';

export class StatusHTrabValidator {
  static validateStatusHTrab(statushtrab: IStatusHTrab): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IStatusHTrabService {
  fetchStatusHTrabById: (id: number) => Promise<IStatusHTrab>;
  saveStatusHTrab: (statushtrab: IStatusHTrab) => Promise<IStatusHTrab>;  
  getList: (filtro?: FilterStatusHTrab) => Promise<IStatusHTrab[]>;
  getAll: (filtro?: FilterStatusHTrab) => Promise<IStatusHTrab[]>;
  deleteStatusHTrab: (id: number) => Promise<void>;
  validateStatusHTrab: (statushtrab: IStatusHTrab) => { isValid: boolean; errors: string[] };
}

export class StatusHTrabService implements IStatusHTrabService {
  constructor(private api: StatusHTrabApi) {}

  async fetchStatusHTrabById(id: number): Promise<IStatusHTrab> {
    if (id <= 0) {
      throw new StatusHTrabApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof StatusHTrabApiError) {
        throw error;
      }
      throw new StatusHTrabApiError('Erro ao buscar statushtrab', 500, 'FETCH_ERROR', error);
    }
  }

  async saveStatusHTrab(statushtrab: IStatusHTrab): Promise<IStatusHTrab> {    
    const validation = this.validateStatusHTrab(statushtrab);
    if (!validation.isValid) {
      throw new StatusHTrabApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(statushtrab);
      return response.data;
    } catch (error) {
      if (error instanceof StatusHTrabApiError) {
        throw error;
      }
      throw new StatusHTrabApiError('Erro ao salvar statushtrab', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterStatusHTrab): Promise<IStatusHTrab[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching statushtrab list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterStatusHTrab): Promise<IStatusHTrab[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all statushtrab:', error);
      return [];
    }
  }

  async deleteStatusHTrab(id: number): Promise<void> {
    if (id <= 0) {
      throw new StatusHTrabApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof StatusHTrabApiError) {
        throw error;
      }
      throw new StatusHTrabApiError('Erro ao excluir statushtrab', 500, 'DELETE_ERROR', error);
    }
  }

  validateStatusHTrab(statushtrab: IStatusHTrab): { isValid: boolean; errors: string[] } {
    return StatusHTrabValidator.validateStatusHTrab(statushtrab);
  }
}