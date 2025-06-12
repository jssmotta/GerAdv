'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { UltimosProcessosApi, UltimosProcessosApiError } from '../Apis/ApiUltimosProcessos';
import { FilterUltimosProcessos } from '../Filters/UltimosProcessos';
import { IUltimosProcessos } from '../Interfaces/interface.UltimosProcessos';

export class UltimosProcessosValidator {
  static validateUltimosProcessos(ultimosprocessos: IUltimosProcessos): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IUltimosProcessosService {
  fetchUltimosProcessosById: (id: number) => Promise<IUltimosProcessos>;
  saveUltimosProcessos: (ultimosprocessos: IUltimosProcessos) => Promise<IUltimosProcessos>;  
  
  getAll: (filtro?: FilterUltimosProcessos) => Promise<IUltimosProcessos[]>;
  deleteUltimosProcessos: (id: number) => Promise<void>;
  validateUltimosProcessos: (ultimosprocessos: IUltimosProcessos) => { isValid: boolean; errors: string[] };
}

export class UltimosProcessosService implements IUltimosProcessosService {
  constructor(private api: UltimosProcessosApi) {}

  async fetchUltimosProcessosById(id: number): Promise<IUltimosProcessos> {
    if (id <= 0) {
      throw new UltimosProcessosApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof UltimosProcessosApiError) {
        throw error;
      }
      throw new UltimosProcessosApiError('Erro ao buscar ultimosprocessos', 500, 'FETCH_ERROR', error);
    }
  }

  async saveUltimosProcessos(ultimosprocessos: IUltimosProcessos): Promise<IUltimosProcessos> {    
    const validation = this.validateUltimosProcessos(ultimosprocessos);
    if (!validation.isValid) {
      throw new UltimosProcessosApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(ultimosprocessos);
      return response.data;
    } catch (error) {
      if (error instanceof UltimosProcessosApiError) {
        throw error;
      }
      throw new UltimosProcessosApiError('Erro ao salvar ultimosprocessos', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterUltimosProcessos): Promise<IUltimosProcessos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all ultimosprocessos:', error);
      return [];
    }
  }

  async deleteUltimosProcessos(id: number): Promise<void> {
    if (id <= 0) {
      throw new UltimosProcessosApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof UltimosProcessosApiError) {
        throw error;
      }
      throw new UltimosProcessosApiError('Erro ao excluir ultimosprocessos', 500, 'DELETE_ERROR', error);
    }
  }

  validateUltimosProcessos(ultimosprocessos: IUltimosProcessos): { isValid: boolean; errors: string[] } {
    return UltimosProcessosValidator.validateUltimosProcessos(ultimosprocessos);
  }
}