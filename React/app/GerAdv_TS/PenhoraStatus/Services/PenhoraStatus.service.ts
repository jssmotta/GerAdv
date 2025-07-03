'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { PenhoraStatusApi, PenhoraStatusApiError } from '../Apis/ApiPenhoraStatus';
import { FilterPenhoraStatus } from '../Filters/PenhoraStatus';
import { IPenhoraStatus } from '../Interfaces/interface.PenhoraStatus';
import { PenhoraStatusEmpty } from '../../Models/PenhoraStatus';

export class PenhoraStatusValidator {
  static validatePenhoraStatus(penhorastatus: IPenhoraStatus): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IPenhoraStatusService {
  fetchPenhoraStatusById: (id: number) => Promise<IPenhoraStatus>;
  savePenhoraStatus: (penhorastatus: IPenhoraStatus) => Promise<IPenhoraStatus>;  
  getList: (filtro?: FilterPenhoraStatus) => Promise<IPenhoraStatus[]>;
  getAll: (filtro?: FilterPenhoraStatus) => Promise<IPenhoraStatus[]>;
  deletePenhoraStatus: (id: number) => Promise<void>;
  validatePenhoraStatus: (penhorastatus: IPenhoraStatus) => { isValid: boolean; errors: string[] };
}

export class PenhoraStatusService implements IPenhoraStatusService {
  constructor(private api: PenhoraStatusApi) {}

  async fetchPenhoraStatusById(id: number): Promise<IPenhoraStatus> {
    if (id <= 0) {
      throw new PenhoraStatusApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof PenhoraStatusApiError) {
        throw error;
      }
      throw new PenhoraStatusApiError('Erro ao buscar penhorastatus', 500, 'FETCH_ERROR', error);
    }
  }

  async savePenhoraStatus(penhorastatus: IPenhoraStatus): Promise<IPenhoraStatus> {    
    const validation = this.validatePenhoraStatus(penhorastatus);
    if (!validation.isValid) {
      throw new PenhoraStatusApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(penhorastatus);
      return response.data;
    } catch (error) {
      if (error instanceof PenhoraStatusApiError) {
        throw error;
      }
      throw new PenhoraStatusApiError('Erro ao salvar penhorastatus', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterPenhoraStatus): Promise<IPenhoraStatus[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching penhorastatus list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterPenhoraStatus): Promise<IPenhoraStatus[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all penhorastatus:', error);
      return [];
    }
  }

  async deletePenhoraStatus(id: number): Promise<void> {
    if (id <= 0) {
      throw new PenhoraStatusApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof PenhoraStatusApiError) {
        throw error;
      }
      throw new PenhoraStatusApiError('Erro ao excluir penhorastatus', 500, 'DELETE_ERROR', error);
    }
  }

  validatePenhoraStatus(penhorastatus: IPenhoraStatus): { isValid: boolean; errors: string[] } {
    return PenhoraStatusValidator.validatePenhoraStatus(penhorastatus);
  }
}