'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { GUTMatrizApi, GUTMatrizApiError } from '../Apis/ApiGUTMatriz';
import { FilterGUTMatriz } from '../Filters/GUTMatriz';
import { IGUTMatriz } from '../Interfaces/interface.GUTMatriz';

export class GUTMatrizValidator {
  static validateGUTMatriz(gutmatriz: IGUTMatriz): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IGUTMatrizService {
  fetchGUTMatrizById: (id: number) => Promise<IGUTMatriz>;
  saveGUTMatriz: (gutmatriz: IGUTMatriz) => Promise<IGUTMatriz>;  
  getList: (filtro?: FilterGUTMatriz) => Promise<IGUTMatriz[]>;
  getAll: (filtro?: FilterGUTMatriz) => Promise<IGUTMatriz[]>;
  deleteGUTMatriz: (id: number) => Promise<void>;
  validateGUTMatriz: (gutmatriz: IGUTMatriz) => { isValid: boolean; errors: string[] };
}

export class GUTMatrizService implements IGUTMatrizService {
  constructor(private api: GUTMatrizApi) {}

  async fetchGUTMatrizById(id: number): Promise<IGUTMatriz> {
    if (id <= 0) {
      throw new GUTMatrizApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof GUTMatrizApiError) {
        throw error;
      }
      throw new GUTMatrizApiError('Erro ao buscar gutmatriz', 500, 'FETCH_ERROR', error);
    }
  }

  async saveGUTMatriz(gutmatriz: IGUTMatriz): Promise<IGUTMatriz> {    
    const validation = this.validateGUTMatriz(gutmatriz);
    if (!validation.isValid) {
      throw new GUTMatrizApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(gutmatriz);
      return response.data;
    } catch (error) {
      if (error instanceof GUTMatrizApiError) {
        throw error;
      }
      throw new GUTMatrizApiError('Erro ao salvar gutmatriz', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterGUTMatriz): Promise<IGUTMatriz[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching gutmatriz list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterGUTMatriz): Promise<IGUTMatriz[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all gutmatriz:', error);
      return [];
    }
  }

  async deleteGUTMatriz(id: number): Promise<void> {
    if (id <= 0) {
      throw new GUTMatrizApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof GUTMatrizApiError) {
        throw error;
      }
      throw new GUTMatrizApiError('Erro ao excluir gutmatriz', 500, 'DELETE_ERROR', error);
    }
  }

  validateGUTMatriz(gutmatriz: IGUTMatriz): { isValid: boolean; errors: string[] } {
    return GUTMatrizValidator.validateGUTMatriz(gutmatriz);
  }
}