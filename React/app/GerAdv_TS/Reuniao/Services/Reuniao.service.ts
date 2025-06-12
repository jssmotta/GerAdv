'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ReuniaoApi, ReuniaoApiError } from '../Apis/ApiReuniao';
import { FilterReuniao } from '../Filters/Reuniao';
import { IReuniao } from '../Interfaces/interface.Reuniao';

export class ReuniaoValidator {
  static validateReuniao(reuniao: IReuniao): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IReuniaoService {
  fetchReuniaoById: (id: number) => Promise<IReuniao>;
  saveReuniao: (reuniao: IReuniao) => Promise<IReuniao>;  
  
  getAll: (filtro?: FilterReuniao) => Promise<IReuniao[]>;
  deleteReuniao: (id: number) => Promise<void>;
  validateReuniao: (reuniao: IReuniao) => { isValid: boolean; errors: string[] };
}

export class ReuniaoService implements IReuniaoService {
  constructor(private api: ReuniaoApi) {}

  async fetchReuniaoById(id: number): Promise<IReuniao> {
    if (id <= 0) {
      throw new ReuniaoApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof ReuniaoApiError) {
        throw error;
      }
      throw new ReuniaoApiError('Erro ao buscar reuniao', 500, 'FETCH_ERROR', error);
    }
  }

  async saveReuniao(reuniao: IReuniao): Promise<IReuniao> {    
    const validation = this.validateReuniao(reuniao);
    if (!validation.isValid) {
      throw new ReuniaoApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(reuniao);
      return response.data;
    } catch (error) {
      if (error instanceof ReuniaoApiError) {
        throw error;
      }
      throw new ReuniaoApiError('Erro ao salvar reuniao', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterReuniao): Promise<IReuniao[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all reuniao:', error);
      return [];
    }
  }

  async deleteReuniao(id: number): Promise<void> {
    if (id <= 0) {
      throw new ReuniaoApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ReuniaoApiError) {
        throw error;
      }
      throw new ReuniaoApiError('Erro ao excluir reuniao', 500, 'DELETE_ERROR', error);
    }
  }

  validateReuniao(reuniao: IReuniao): { isValid: boolean; errors: string[] } {
    return ReuniaoValidator.validateReuniao(reuniao);
  }
}