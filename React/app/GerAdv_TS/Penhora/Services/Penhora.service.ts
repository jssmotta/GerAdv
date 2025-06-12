'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { PenhoraApi, PenhoraApiError } from '../Apis/ApiPenhora';
import { FilterPenhora } from '../Filters/Penhora';
import { IPenhora } from '../Interfaces/interface.Penhora';

export class PenhoraValidator {
  static validatePenhora(penhora: IPenhora): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IPenhoraService {
  fetchPenhoraById: (id: number) => Promise<IPenhora>;
  savePenhora: (penhora: IPenhora) => Promise<IPenhora>;  
  getList: (filtro?: FilterPenhora) => Promise<IPenhora[]>;
  getAll: (filtro?: FilterPenhora) => Promise<IPenhora[]>;
  deletePenhora: (id: number) => Promise<void>;
  validatePenhora: (penhora: IPenhora) => { isValid: boolean; errors: string[] };
}

export class PenhoraService implements IPenhoraService {
  constructor(private api: PenhoraApi) {}

  async fetchPenhoraById(id: number): Promise<IPenhora> {
    if (id <= 0) {
      throw new PenhoraApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof PenhoraApiError) {
        throw error;
      }
      throw new PenhoraApiError('Erro ao buscar penhora', 500, 'FETCH_ERROR', error);
    }
  }

  async savePenhora(penhora: IPenhora): Promise<IPenhora> {    
    const validation = this.validatePenhora(penhora);
    if (!validation.isValid) {
      throw new PenhoraApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(penhora);
      return response.data;
    } catch (error) {
      if (error instanceof PenhoraApiError) {
        throw error;
      }
      throw new PenhoraApiError('Erro ao salvar penhora', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterPenhora): Promise<IPenhora[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching penhora list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterPenhora): Promise<IPenhora[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all penhora:', error);
      return [];
    }
  }

  async deletePenhora(id: number): Promise<void> {
    if (id <= 0) {
      throw new PenhoraApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof PenhoraApiError) {
        throw error;
      }
      throw new PenhoraApiError('Erro ao excluir penhora', 500, 'DELETE_ERROR', error);
    }
  }

  validatePenhora(penhora: IPenhora): { isValid: boolean; errors: string[] } {
    return PenhoraValidator.validatePenhora(penhora);
  }
}