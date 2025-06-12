'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { PrepostosApi, PrepostosApiError } from '../Apis/ApiPrepostos';
import { FilterPrepostos } from '../Filters/Prepostos';
import { IPrepostos } from '../Interfaces/interface.Prepostos';

export class PrepostosValidator {
  static validatePrepostos(prepostos: IPrepostos): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IPrepostosService {
  fetchPrepostosById: (id: number) => Promise<IPrepostos>;
  savePrepostos: (prepostos: IPrepostos) => Promise<IPrepostos>;  
  getList: (filtro?: FilterPrepostos) => Promise<IPrepostos[]>;
  getAll: (filtro?: FilterPrepostos) => Promise<IPrepostos[]>;
  deletePrepostos: (id: number) => Promise<void>;
  validatePrepostos: (prepostos: IPrepostos) => { isValid: boolean; errors: string[] };
}

export class PrepostosService implements IPrepostosService {
  constructor(private api: PrepostosApi) {}

  async fetchPrepostosById(id: number): Promise<IPrepostos> {
    if (id <= 0) {
      throw new PrepostosApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof PrepostosApiError) {
        throw error;
      }
      throw new PrepostosApiError('Erro ao buscar prepostos', 500, 'FETCH_ERROR', error);
    }
  }

  async savePrepostos(prepostos: IPrepostos): Promise<IPrepostos> {    
    const validation = this.validatePrepostos(prepostos);
    if (!validation.isValid) {
      throw new PrepostosApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(prepostos);
      return response.data;
    } catch (error) {
      if (error instanceof PrepostosApiError) {
        throw error;
      }
      throw new PrepostosApiError('Erro ao salvar prepostos', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterPrepostos): Promise<IPrepostos[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching prepostos list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterPrepostos): Promise<IPrepostos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all prepostos:', error);
      return [];
    }
  }

  async deletePrepostos(id: number): Promise<void> {
    if (id <= 0) {
      throw new PrepostosApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof PrepostosApiError) {
        throw error;
      }
      throw new PrepostosApiError('Erro ao excluir prepostos', 500, 'DELETE_ERROR', error);
    }
  }

  validatePrepostos(prepostos: IPrepostos): { isValid: boolean; errors: string[] } {
    return PrepostosValidator.validatePrepostos(prepostos);
  }
}