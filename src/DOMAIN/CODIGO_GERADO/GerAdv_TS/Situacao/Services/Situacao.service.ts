'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { SituacaoApi, SituacaoApiError } from '../Apis/ApiSituacao';
import { FilterSituacao } from '../Filters/Situacao';
import { ISituacao } from '../Interfaces/interface.Situacao';
import { SituacaoEmpty } from '../../Models/Situacao';

export class SituacaoValidator {
  static validateSituacao(situacao: ISituacao): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface ISituacaoService {
  fetchSituacaoById: (id: number) => Promise<ISituacao>;
  saveSituacao: (situacao: ISituacao) => Promise<ISituacao>;  
  
  getAll: (filtro?: FilterSituacao) => Promise<ISituacao[]>;
  deleteSituacao: (id: number) => Promise<void>;
  validateSituacao: (situacao: ISituacao) => { isValid: boolean; errors: string[] };
}

export class SituacaoService implements ISituacaoService {
  constructor(private api: SituacaoApi) {}

  async fetchSituacaoById(id: number): Promise<ISituacao> {
    if (id <= 0) {
      throw new SituacaoApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof SituacaoApiError) {
        throw error;
      }
      throw new SituacaoApiError('Erro ao buscar situacao', 500, 'FETCH_ERROR', error);
    }
  }

  async saveSituacao(situacao: ISituacao): Promise<ISituacao> {    
    const validation = this.validateSituacao(situacao);
    if (!validation.isValid) {
      throw new SituacaoApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(situacao);
      return response.data;
    } catch (error) {
      if (error instanceof SituacaoApiError) {
        throw error;
      }
      throw new SituacaoApiError('Erro ao salvar situacao', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterSituacao): Promise<ISituacao[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all situacao:', error);
      return [];
    }
  }

  async deleteSituacao(id: number): Promise<void> {
    if (id <= 0) {
      throw new SituacaoApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof SituacaoApiError) {
        throw error;
      }
      throw new SituacaoApiError('Erro ao excluir situacao', 500, 'DELETE_ERROR', error);
    }
  }

  validateSituacao(situacao: ISituacao): { isValid: boolean; errors: string[] } {
    return SituacaoValidator.validateSituacao(situacao);
  }
}