'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { GUTAtividadesMatrizApi, GUTAtividadesMatrizApiError } from '../Apis/ApiGUTAtividadesMatriz';
import { FilterGUTAtividadesMatriz } from '../Filters/GUTAtividadesMatriz';
import { IGUTAtividadesMatriz } from '../Interfaces/interface.GUTAtividadesMatriz';

export class GUTAtividadesMatrizValidator {
  static validateGUTAtividadesMatriz(gutatividadesmatriz: IGUTAtividadesMatriz): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IGUTAtividadesMatrizService {
  fetchGUTAtividadesMatrizById: (id: number) => Promise<IGUTAtividadesMatriz>;
  saveGUTAtividadesMatriz: (gutatividadesmatriz: IGUTAtividadesMatriz) => Promise<IGUTAtividadesMatriz>;  
  
  getAll: (filtro?: FilterGUTAtividadesMatriz) => Promise<IGUTAtividadesMatriz[]>;
  deleteGUTAtividadesMatriz: (id: number) => Promise<void>;
  validateGUTAtividadesMatriz: (gutatividadesmatriz: IGUTAtividadesMatriz) => { isValid: boolean; errors: string[] };
}

export class GUTAtividadesMatrizService implements IGUTAtividadesMatrizService {
  constructor(private api: GUTAtividadesMatrizApi) {}

  async fetchGUTAtividadesMatrizById(id: number): Promise<IGUTAtividadesMatriz> {
    if (id <= 0) {
      throw new GUTAtividadesMatrizApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof GUTAtividadesMatrizApiError) {
        throw error;
      }
      throw new GUTAtividadesMatrizApiError('Erro ao buscar gutatividadesmatriz', 500, 'FETCH_ERROR', error);
    }
  }

  async saveGUTAtividadesMatriz(gutatividadesmatriz: IGUTAtividadesMatriz): Promise<IGUTAtividadesMatriz> {    
    const validation = this.validateGUTAtividadesMatriz(gutatividadesmatriz);
    if (!validation.isValid) {
      throw new GUTAtividadesMatrizApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(gutatividadesmatriz);
      return response.data;
    } catch (error) {
      if (error instanceof GUTAtividadesMatrizApiError) {
        throw error;
      }
      throw new GUTAtividadesMatrizApiError('Erro ao salvar gutatividadesmatriz', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterGUTAtividadesMatriz): Promise<IGUTAtividadesMatriz[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all gutatividadesmatriz:', error);
      return [];
    }
  }

  async deleteGUTAtividadesMatriz(id: number): Promise<void> {
    if (id <= 0) {
      throw new GUTAtividadesMatrizApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof GUTAtividadesMatrizApiError) {
        throw error;
      }
      throw new GUTAtividadesMatrizApiError('Erro ao excluir gutatividadesmatriz', 500, 'DELETE_ERROR', error);
    }
  }

  validateGUTAtividadesMatriz(gutatividadesmatriz: IGUTAtividadesMatriz): { isValid: boolean; errors: string[] } {
    return GUTAtividadesMatrizValidator.validateGUTAtividadesMatriz(gutatividadesmatriz);
  }
}