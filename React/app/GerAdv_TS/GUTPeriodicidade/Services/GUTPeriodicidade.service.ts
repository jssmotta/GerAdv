'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { GUTPeriodicidadeApi, GUTPeriodicidadeApiError } from '../Apis/ApiGUTPeriodicidade';
import { FilterGUTPeriodicidade } from '../Filters/GUTPeriodicidade';
import { IGUTPeriodicidade } from '../Interfaces/interface.GUTPeriodicidade';
import { GUTPeriodicidadeEmpty } from '../../Models/GUTPeriodicidade';

export class GUTPeriodicidadeValidator {
  static validateGUTPeriodicidade(gutperiodicidade: IGUTPeriodicidade): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IGUTPeriodicidadeService {
  fetchGUTPeriodicidadeById: (id: number) => Promise<IGUTPeriodicidade>;
  saveGUTPeriodicidade: (gutperiodicidade: IGUTPeriodicidade) => Promise<IGUTPeriodicidade>;  
  getList: (filtro?: FilterGUTPeriodicidade) => Promise<IGUTPeriodicidade[]>;
  getAll: (filtro?: FilterGUTPeriodicidade) => Promise<IGUTPeriodicidade[]>;
  deleteGUTPeriodicidade: (id: number) => Promise<void>;
  validateGUTPeriodicidade: (gutperiodicidade: IGUTPeriodicidade) => { isValid: boolean; errors: string[] };
}

export class GUTPeriodicidadeService implements IGUTPeriodicidadeService {
  constructor(private api: GUTPeriodicidadeApi) {}

  async fetchGUTPeriodicidadeById(id: number): Promise<IGUTPeriodicidade> {
    if (id <= 0) {
      throw new GUTPeriodicidadeApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof GUTPeriodicidadeApiError) {
        throw error;
      }
      throw new GUTPeriodicidadeApiError('Erro ao buscar gutperiodicidade', 500, 'FETCH_ERROR', error);
    }
  }

  async saveGUTPeriodicidade(gutperiodicidade: IGUTPeriodicidade): Promise<IGUTPeriodicidade> {    
    const validation = this.validateGUTPeriodicidade(gutperiodicidade);
    if (!validation.isValid) {
      throw new GUTPeriodicidadeApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(gutperiodicidade);
      return response.data;
    } catch (error) {
      if (error instanceof GUTPeriodicidadeApiError) {
        throw error;
      }
      throw new GUTPeriodicidadeApiError('Erro ao salvar gutperiodicidade', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterGUTPeriodicidade): Promise<IGUTPeriodicidade[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching gutperiodicidade list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterGUTPeriodicidade): Promise<IGUTPeriodicidade[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all gutperiodicidade:', error);
      return [];
    }
  }

  async deleteGUTPeriodicidade(id: number): Promise<void> {
    if (id <= 0) {
      throw new GUTPeriodicidadeApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof GUTPeriodicidadeApiError) {
        throw error;
      }
      throw new GUTPeriodicidadeApiError('Erro ao excluir gutperiodicidade', 500, 'DELETE_ERROR', error);
    }
  }

  validateGUTPeriodicidade(gutperiodicidade: IGUTPeriodicidade): { isValid: boolean; errors: string[] } {
    return GUTPeriodicidadeValidator.validateGUTPeriodicidade(gutperiodicidade);
  }
}