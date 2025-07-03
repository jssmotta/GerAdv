'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { EndTitApi, EndTitApiError } from '../Apis/ApiEndTit';
import { FilterEndTit } from '../Filters/EndTit';
import { IEndTit } from '../Interfaces/interface.EndTit';
import { EndTitEmpty } from '../../Models/EndTit';

export class EndTitValidator {
  static validateEndTit(endtit: IEndTit): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IEndTitService {
  fetchEndTitById: (id: number) => Promise<IEndTit>;
  saveEndTit: (endtit: IEndTit) => Promise<IEndTit>;  
  
  getAll: (filtro?: FilterEndTit) => Promise<IEndTit[]>;
  deleteEndTit: (id: number) => Promise<void>;
  validateEndTit: (endtit: IEndTit) => { isValid: boolean; errors: string[] };
}

export class EndTitService implements IEndTitService {
  constructor(private api: EndTitApi) {}

  async fetchEndTitById(id: number): Promise<IEndTit> {
    if (id <= 0) {
      throw new EndTitApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof EndTitApiError) {
        throw error;
      }
      throw new EndTitApiError('Erro ao buscar endtit', 500, 'FETCH_ERROR', error);
    }
  }

  async saveEndTit(endtit: IEndTit): Promise<IEndTit> {    
    const validation = this.validateEndTit(endtit);
    if (!validation.isValid) {
      throw new EndTitApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(endtit);
      return response.data;
    } catch (error) {
      if (error instanceof EndTitApiError) {
        throw error;
      }
      throw new EndTitApiError('Erro ao salvar endtit', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterEndTit): Promise<IEndTit[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all endtit:', error);
      return [];
    }
  }

  async deleteEndTit(id: number): Promise<void> {
    if (id <= 0) {
      throw new EndTitApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof EndTitApiError) {
        throw error;
      }
      throw new EndTitApiError('Erro ao excluir endtit', 500, 'DELETE_ERROR', error);
    }
  }

  validateEndTit(endtit: IEndTit): { isValid: boolean; errors: string[] } {
    return EndTitValidator.validateEndTit(endtit);
  }
}