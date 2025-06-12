'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { TribEnderecosApi, TribEnderecosApiError } from '../Apis/ApiTribEnderecos';
import { FilterTribEnderecos } from '../Filters/TribEnderecos';
import { ITribEnderecos } from '../Interfaces/interface.TribEnderecos';

export class TribEnderecosValidator {
  static validateTribEnderecos(tribenderecos: ITribEnderecos): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface ITribEnderecosService {
  fetchTribEnderecosById: (id: number) => Promise<ITribEnderecos>;
  saveTribEnderecos: (tribenderecos: ITribEnderecos) => Promise<ITribEnderecos>;  
  
  getAll: (filtro?: FilterTribEnderecos) => Promise<ITribEnderecos[]>;
  deleteTribEnderecos: (id: number) => Promise<void>;
  validateTribEnderecos: (tribenderecos: ITribEnderecos) => { isValid: boolean; errors: string[] };
}

export class TribEnderecosService implements ITribEnderecosService {
  constructor(private api: TribEnderecosApi) {}

  async fetchTribEnderecosById(id: number): Promise<ITribEnderecos> {
    if (id <= 0) {
      throw new TribEnderecosApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof TribEnderecosApiError) {
        throw error;
      }
      throw new TribEnderecosApiError('Erro ao buscar tribenderecos', 500, 'FETCH_ERROR', error);
    }
  }

  async saveTribEnderecos(tribenderecos: ITribEnderecos): Promise<ITribEnderecos> {    
    const validation = this.validateTribEnderecos(tribenderecos);
    if (!validation.isValid) {
      throw new TribEnderecosApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(tribenderecos);
      return response.data;
    } catch (error) {
      if (error instanceof TribEnderecosApiError) {
        throw error;
      }
      throw new TribEnderecosApiError('Erro ao salvar tribenderecos', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterTribEnderecos): Promise<ITribEnderecos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all tribenderecos:', error);
      return [];
    }
  }

  async deleteTribEnderecos(id: number): Promise<void> {
    if (id <= 0) {
      throw new TribEnderecosApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof TribEnderecosApiError) {
        throw error;
      }
      throw new TribEnderecosApiError('Erro ao excluir tribenderecos', 500, 'DELETE_ERROR', error);
    }
  }

  validateTribEnderecos(tribenderecos: ITribEnderecos): { isValid: boolean; errors: string[] } {
    return TribEnderecosValidator.validateTribEnderecos(tribenderecos);
  }
}