'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ProValoresApi, ProValoresApiError } from '../Apis/ApiProValores';
import { FilterProValores } from '../Filters/ProValores';
import { IProValores } from '../Interfaces/interface.ProValores';

export class ProValoresValidator {
  static validateProValores(provalores: IProValores): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IProValoresService {
  fetchProValoresById: (id: number) => Promise<IProValores>;
  saveProValores: (provalores: IProValores) => Promise<IProValores>;  
  
  getAll: (filtro?: FilterProValores) => Promise<IProValores[]>;
  deleteProValores: (id: number) => Promise<void>;
  validateProValores: (provalores: IProValores) => { isValid: boolean; errors: string[] };
}

export class ProValoresService implements IProValoresService {
  constructor(private api: ProValoresApi) {}

  async fetchProValoresById(id: number): Promise<IProValores> {
    if (id <= 0) {
      throw new ProValoresApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof ProValoresApiError) {
        throw error;
      }
      throw new ProValoresApiError('Erro ao buscar provalores', 500, 'FETCH_ERROR', error);
    }
  }

  async saveProValores(provalores: IProValores): Promise<IProValores> {    
    const validation = this.validateProValores(provalores);
    if (!validation.isValid) {
      throw new ProValoresApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(provalores);
      return response.data;
    } catch (error) {
      if (error instanceof ProValoresApiError) {
        throw error;
      }
      throw new ProValoresApiError('Erro ao salvar provalores', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterProValores): Promise<IProValores[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all provalores:', error);
      return [];
    }
  }

  async deleteProValores(id: number): Promise<void> {
    if (id <= 0) {
      throw new ProValoresApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ProValoresApiError) {
        throw error;
      }
      throw new ProValoresApiError('Erro ao excluir provalores', 500, 'DELETE_ERROR', error);
    }
  }

  validateProValores(provalores: IProValores): { isValid: boolean; errors: string[] } {
    return ProValoresValidator.validateProValores(provalores);
  }
}