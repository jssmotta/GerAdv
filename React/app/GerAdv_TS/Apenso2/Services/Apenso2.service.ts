'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { Apenso2Api, Apenso2ApiError } from '../Apis/ApiApenso2';
import { FilterApenso2 } from '../Filters/Apenso2';
import { IApenso2 } from '../Interfaces/interface.Apenso2';
import { Apenso2Empty } from '../../Models/Apenso2';

export class Apenso2Validator {
  static validateApenso2(apenso2: IApenso2): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IApenso2Service {
  fetchApenso2ById: (id: number) => Promise<IApenso2>;
  saveApenso2: (apenso2: IApenso2) => Promise<IApenso2>;  
  
  getAll: (filtro?: FilterApenso2) => Promise<IApenso2[]>;
  deleteApenso2: (id: number) => Promise<void>;
  validateApenso2: (apenso2: IApenso2) => { isValid: boolean; errors: string[] };
}

export class Apenso2Service implements IApenso2Service {
  constructor(private api: Apenso2Api) {}

  async fetchApenso2ById(id: number): Promise<IApenso2> {
    if (id <= 0) {
      throw new Apenso2ApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof Apenso2ApiError) {
        throw error;
      }
      throw new Apenso2ApiError('Erro ao buscar apenso2', 500, 'FETCH_ERROR', error);
    }
  }

  async saveApenso2(apenso2: IApenso2): Promise<IApenso2> {    
    const validation = this.validateApenso2(apenso2);
    if (!validation.isValid) {
      throw new Apenso2ApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(apenso2);
      return response.data;
    } catch (error) {
      if (error instanceof Apenso2ApiError) {
        throw error;
      }
      throw new Apenso2ApiError('Erro ao salvar apenso2', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterApenso2): Promise<IApenso2[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all apenso2:', error);
      return [];
    }
  }

  async deleteApenso2(id: number): Promise<void> {
    if (id <= 0) {
      throw new Apenso2ApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof Apenso2ApiError) {
        throw error;
      }
      throw new Apenso2ApiError('Erro ao excluir apenso2', 500, 'DELETE_ERROR', error);
    }
  }

  validateApenso2(apenso2: IApenso2): { isValid: boolean; errors: string[] } {
    return Apenso2Validator.validateApenso2(apenso2);
  }
}