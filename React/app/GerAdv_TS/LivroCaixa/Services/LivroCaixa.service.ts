'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { LivroCaixaApi, LivroCaixaApiError } from '../Apis/ApiLivroCaixa';
import { FilterLivroCaixa } from '../Filters/LivroCaixa';
import { ILivroCaixa } from '../Interfaces/interface.LivroCaixa';
import { LivroCaixaEmpty } from '../../Models/LivroCaixa';

export class LivroCaixaValidator {
  static validateLivroCaixa(livrocaixa: ILivroCaixa): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface ILivroCaixaService {
  fetchLivroCaixaById: (id: number) => Promise<ILivroCaixa>;
  saveLivroCaixa: (livrocaixa: ILivroCaixa) => Promise<ILivroCaixa>;  
  
  getAll: (filtro?: FilterLivroCaixa) => Promise<ILivroCaixa[]>;
  deleteLivroCaixa: (id: number) => Promise<void>;
  validateLivroCaixa: (livrocaixa: ILivroCaixa) => { isValid: boolean; errors: string[] };
}

export class LivroCaixaService implements ILivroCaixaService {
  constructor(private api: LivroCaixaApi) {}

  async fetchLivroCaixaById(id: number): Promise<ILivroCaixa> {
    if (id <= 0) {
      throw new LivroCaixaApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof LivroCaixaApiError) {
        throw error;
      }
      throw new LivroCaixaApiError('Erro ao buscar livrocaixa', 500, 'FETCH_ERROR', error);
    }
  }

  async saveLivroCaixa(livrocaixa: ILivroCaixa): Promise<ILivroCaixa> {    
    const validation = this.validateLivroCaixa(livrocaixa);
    if (!validation.isValid) {
      throw new LivroCaixaApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(livrocaixa);
      return response.data;
    } catch (error) {
      if (error instanceof LivroCaixaApiError) {
        throw error;
      }
      throw new LivroCaixaApiError('Erro ao salvar livrocaixa', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterLivroCaixa): Promise<ILivroCaixa[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all livrocaixa:', error);
      return [];
    }
  }

  async deleteLivroCaixa(id: number): Promise<void> {
    if (id <= 0) {
      throw new LivroCaixaApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof LivroCaixaApiError) {
        throw error;
      }
      throw new LivroCaixaApiError('Erro ao excluir livrocaixa', 500, 'DELETE_ERROR', error);
    }
  }

  validateLivroCaixa(livrocaixa: ILivroCaixa): { isValid: boolean; errors: string[] } {
    return LivroCaixaValidator.validateLivroCaixa(livrocaixa);
  }
}