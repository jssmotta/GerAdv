'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { GUTPeriodicidadeStatusApi, GUTPeriodicidadeStatusApiError } from '../Apis/ApiGUTPeriodicidadeStatus';
import { FilterGUTPeriodicidadeStatus } from '../Filters/GUTPeriodicidadeStatus';
import { IGUTPeriodicidadeStatus } from '../Interfaces/interface.GUTPeriodicidadeStatus';

export class GUTPeriodicidadeStatusValidator {
  static validateGUTPeriodicidadeStatus(gutperiodicidadestatus: IGUTPeriodicidadeStatus): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IGUTPeriodicidadeStatusService {
  fetchGUTPeriodicidadeStatusById: (id: number) => Promise<IGUTPeriodicidadeStatus>;
  saveGUTPeriodicidadeStatus: (gutperiodicidadestatus: IGUTPeriodicidadeStatus) => Promise<IGUTPeriodicidadeStatus>;  
  
  getAll: (filtro?: FilterGUTPeriodicidadeStatus) => Promise<IGUTPeriodicidadeStatus[]>;
  deleteGUTPeriodicidadeStatus: (id: number) => Promise<void>;
  validateGUTPeriodicidadeStatus: (gutperiodicidadestatus: IGUTPeriodicidadeStatus) => { isValid: boolean; errors: string[] };
}

export class GUTPeriodicidadeStatusService implements IGUTPeriodicidadeStatusService {
  constructor(private api: GUTPeriodicidadeStatusApi) {}

  async fetchGUTPeriodicidadeStatusById(id: number): Promise<IGUTPeriodicidadeStatus> {
    if (id <= 0) {
      throw new GUTPeriodicidadeStatusApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof GUTPeriodicidadeStatusApiError) {
        throw error;
      }
      throw new GUTPeriodicidadeStatusApiError('Erro ao buscar gutperiodicidadestatus', 500, 'FETCH_ERROR', error);
    }
  }

  async saveGUTPeriodicidadeStatus(gutperiodicidadestatus: IGUTPeriodicidadeStatus): Promise<IGUTPeriodicidadeStatus> {    
    const validation = this.validateGUTPeriodicidadeStatus(gutperiodicidadestatus);
    if (!validation.isValid) {
      throw new GUTPeriodicidadeStatusApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(gutperiodicidadestatus);
      return response.data;
    } catch (error) {
      if (error instanceof GUTPeriodicidadeStatusApiError) {
        throw error;
      }
      throw new GUTPeriodicidadeStatusApiError('Erro ao salvar gutperiodicidadestatus', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterGUTPeriodicidadeStatus): Promise<IGUTPeriodicidadeStatus[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all gutperiodicidadestatus:', error);
      return [];
    }
  }

  async deleteGUTPeriodicidadeStatus(id: number): Promise<void> {
    if (id <= 0) {
      throw new GUTPeriodicidadeStatusApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof GUTPeriodicidadeStatusApiError) {
        throw error;
      }
      throw new GUTPeriodicidadeStatusApiError('Erro ao excluir gutperiodicidadestatus', 500, 'DELETE_ERROR', error);
    }
  }

  validateGUTPeriodicidadeStatus(gutperiodicidadestatus: IGUTPeriodicidadeStatus): { isValid: boolean; errors: string[] } {
    return GUTPeriodicidadeStatusValidator.validateGUTPeriodicidadeStatus(gutperiodicidadestatus);
  }
}