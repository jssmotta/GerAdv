'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ReuniaoPessoasApi, ReuniaoPessoasApiError } from '../Apis/ApiReuniaoPessoas';
import { FilterReuniaoPessoas } from '../Filters/ReuniaoPessoas';
import { IReuniaoPessoas } from '../Interfaces/interface.ReuniaoPessoas';
import { ReuniaoPessoasEmpty } from '../../Models/ReuniaoPessoas';

export class ReuniaoPessoasValidator {
  static validateReuniaoPessoas(reuniaopessoas: IReuniaoPessoas): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IReuniaoPessoasService {
  fetchReuniaoPessoasById: (id: number) => Promise<IReuniaoPessoas>;
  saveReuniaoPessoas: (reuniaopessoas: IReuniaoPessoas) => Promise<IReuniaoPessoas>;  
  
  getAll: (filtro?: FilterReuniaoPessoas) => Promise<IReuniaoPessoas[]>;
  deleteReuniaoPessoas: (id: number) => Promise<void>;
  validateReuniaoPessoas: (reuniaopessoas: IReuniaoPessoas) => { isValid: boolean; errors: string[] };
}

export class ReuniaoPessoasService implements IReuniaoPessoasService {
  constructor(private api: ReuniaoPessoasApi) {}

  async fetchReuniaoPessoasById(id: number): Promise<IReuniaoPessoas> {
    if (id <= 0) {
      throw new ReuniaoPessoasApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof ReuniaoPessoasApiError) {
        throw error;
      }
      throw new ReuniaoPessoasApiError('Erro ao buscar reuniaopessoas', 500, 'FETCH_ERROR', error);
    }
  }

  async saveReuniaoPessoas(reuniaopessoas: IReuniaoPessoas): Promise<IReuniaoPessoas> {    
    const validation = this.validateReuniaoPessoas(reuniaopessoas);
    if (!validation.isValid) {
      throw new ReuniaoPessoasApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(reuniaopessoas);
      return response.data;
    } catch (error) {
      if (error instanceof ReuniaoPessoasApiError) {
        throw error;
      }
      throw new ReuniaoPessoasApiError('Erro ao salvar reuniaopessoas', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterReuniaoPessoas): Promise<IReuniaoPessoas[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all reuniaopessoas:', error);
      return [];
    }
  }

  async deleteReuniaoPessoas(id: number): Promise<void> {
    if (id <= 0) {
      throw new ReuniaoPessoasApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ReuniaoPessoasApiError) {
        throw error;
      }
      throw new ReuniaoPessoasApiError('Erro ao excluir reuniaopessoas', 500, 'DELETE_ERROR', error);
    }
  }

  validateReuniaoPessoas(reuniaopessoas: IReuniaoPessoas): { isValid: boolean; errors: string[] } {
    return ReuniaoPessoasValidator.validateReuniaoPessoas(reuniaopessoas);
  }
}