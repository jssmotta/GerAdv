'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { DadosProcuracaoApi, DadosProcuracaoApiError } from '../Apis/ApiDadosProcuracao';
import { FilterDadosProcuracao } from '../Filters/DadosProcuracao';
import { IDadosProcuracao } from '../Interfaces/interface.DadosProcuracao';
import { DadosProcuracaoEmpty } from '../../Models/DadosProcuracao';

export class DadosProcuracaoValidator {
  static validateDadosProcuracao(dadosprocuracao: IDadosProcuracao): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IDadosProcuracaoService {
  fetchDadosProcuracaoById: (id: number) => Promise<IDadosProcuracao>;
  saveDadosProcuracao: (dadosprocuracao: IDadosProcuracao) => Promise<IDadosProcuracao>;  
  
  getAll: (filtro?: FilterDadosProcuracao) => Promise<IDadosProcuracao[]>;
  deleteDadosProcuracao: (id: number) => Promise<void>;
  validateDadosProcuracao: (dadosprocuracao: IDadosProcuracao) => { isValid: boolean; errors: string[] };
}

export class DadosProcuracaoService implements IDadosProcuracaoService {
  constructor(private api: DadosProcuracaoApi) {}

  async fetchDadosProcuracaoById(id: number): Promise<IDadosProcuracao> {
    if (id <= 0) {
      throw new DadosProcuracaoApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof DadosProcuracaoApiError) {
        throw error;
      }
      throw new DadosProcuracaoApiError('Erro ao buscar dadosprocuracao', 500, 'FETCH_ERROR', error);
    }
  }

  async saveDadosProcuracao(dadosprocuracao: IDadosProcuracao): Promise<IDadosProcuracao> {    
    const validation = this.validateDadosProcuracao(dadosprocuracao);
    if (!validation.isValid) {
      throw new DadosProcuracaoApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(dadosprocuracao);
      return response.data;
    } catch (error) {
      if (error instanceof DadosProcuracaoApiError) {
        throw error;
      }
      throw new DadosProcuracaoApiError('Erro ao salvar dadosprocuracao', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterDadosProcuracao): Promise<IDadosProcuracao[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all dadosprocuracao:', error);
      return [];
    }
  }

  async deleteDadosProcuracao(id: number): Promise<void> {
    if (id <= 0) {
      throw new DadosProcuracaoApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof DadosProcuracaoApiError) {
        throw error;
      }
      throw new DadosProcuracaoApiError('Erro ao excluir dadosprocuracao', 500, 'DELETE_ERROR', error);
    }
  }

  validateDadosProcuracao(dadosprocuracao: IDadosProcuracao): { isValid: boolean; errors: string[] } {
    return DadosProcuracaoValidator.validateDadosProcuracao(dadosprocuracao);
  }
}