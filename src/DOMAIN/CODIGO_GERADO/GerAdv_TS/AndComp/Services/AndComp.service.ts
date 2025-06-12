'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { AndCompApi, AndCompApiError } from '../Apis/ApiAndComp';
import { FilterAndComp } from '../Filters/AndComp';
import { IAndComp } from '../Interfaces/interface.AndComp';

export class AndCompValidator {
  static validateAndComp(andcomp: IAndComp): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IAndCompService {
  fetchAndCompById: (id: number) => Promise<IAndComp>;
  saveAndComp: (andcomp: IAndComp) => Promise<IAndComp>;  
  
  getAll: (filtro?: FilterAndComp) => Promise<IAndComp[]>;
  deleteAndComp: (id: number) => Promise<void>;
  validateAndComp: (andcomp: IAndComp) => { isValid: boolean; errors: string[] };
}

export class AndCompService implements IAndCompService {
  constructor(private api: AndCompApi) {}

  async fetchAndCompById(id: number): Promise<IAndComp> {
    if (id <= 0) {
      throw new AndCompApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof AndCompApiError) {
        throw error;
      }
      throw new AndCompApiError('Erro ao buscar andcomp', 500, 'FETCH_ERROR', error);
    }
  }

  async saveAndComp(andcomp: IAndComp): Promise<IAndComp> {    
    const validation = this.validateAndComp(andcomp);
    if (!validation.isValid) {
      throw new AndCompApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(andcomp);
      return response.data;
    } catch (error) {
      if (error instanceof AndCompApiError) {
        throw error;
      }
      throw new AndCompApiError('Erro ao salvar andcomp', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterAndComp): Promise<IAndComp[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all andcomp:', error);
      return [];
    }
  }

  async deleteAndComp(id: number): Promise<void> {
    if (id <= 0) {
      throw new AndCompApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof AndCompApiError) {
        throw error;
      }
      throw new AndCompApiError('Erro ao excluir andcomp', 500, 'DELETE_ERROR', error);
    }
  }

  validateAndComp(andcomp: IAndComp): { isValid: boolean; errors: string[] } {
    return AndCompValidator.validateAndComp(andcomp);
  }
}