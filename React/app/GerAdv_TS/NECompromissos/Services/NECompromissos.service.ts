'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { NECompromissosApi, NECompromissosApiError } from '../Apis/ApiNECompromissos';
import { FilterNECompromissos } from '../Filters/NECompromissos';
import { INECompromissos } from '../Interfaces/interface.NECompromissos';

export class NECompromissosValidator {
  static validateNECompromissos(necompromissos: INECompromissos): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface INECompromissosService {
  fetchNECompromissosById: (id: number) => Promise<INECompromissos>;
  saveNECompromissos: (necompromissos: INECompromissos) => Promise<INECompromissos>;  
  
  getAll: (filtro?: FilterNECompromissos) => Promise<INECompromissos[]>;
  deleteNECompromissos: (id: number) => Promise<void>;
  validateNECompromissos: (necompromissos: INECompromissos) => { isValid: boolean; errors: string[] };
}

export class NECompromissosService implements INECompromissosService {
  constructor(private api: NECompromissosApi) {}

  async fetchNECompromissosById(id: number): Promise<INECompromissos> {
    if (id <= 0) {
      throw new NECompromissosApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof NECompromissosApiError) {
        throw error;
      }
      throw new NECompromissosApiError('Erro ao buscar necompromissos', 500, 'FETCH_ERROR', error);
    }
  }

  async saveNECompromissos(necompromissos: INECompromissos): Promise<INECompromissos> {    
    const validation = this.validateNECompromissos(necompromissos);
    if (!validation.isValid) {
      throw new NECompromissosApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(necompromissos);
      return response.data;
    } catch (error) {
      if (error instanceof NECompromissosApiError) {
        throw error;
      }
      throw new NECompromissosApiError('Erro ao salvar necompromissos', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterNECompromissos): Promise<INECompromissos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all necompromissos:', error);
      return [];
    }
  }

  async deleteNECompromissos(id: number): Promise<void> {
    if (id <= 0) {
      throw new NECompromissosApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof NECompromissosApiError) {
        throw error;
      }
      throw new NECompromissosApiError('Erro ao excluir necompromissos', 500, 'DELETE_ERROR', error);
    }
  }

  validateNECompromissos(necompromissos: INECompromissos): { isValid: boolean; errors: string[] } {
    return NECompromissosValidator.validateNECompromissos(necompromissos);
  }
}