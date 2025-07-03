'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { BensClassificacaoApi, BensClassificacaoApiError } from '../Apis/ApiBensClassificacao';
import { FilterBensClassificacao } from '../Filters/BensClassificacao';
import { IBensClassificacao } from '../Interfaces/interface.BensClassificacao';
import { BensClassificacaoEmpty } from '../../Models/BensClassificacao';

export class BensClassificacaoValidator {
  static validateBensClassificacao(bensclassificacao: IBensClassificacao): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IBensClassificacaoService {
  fetchBensClassificacaoById: (id: number) => Promise<IBensClassificacao>;
  saveBensClassificacao: (bensclassificacao: IBensClassificacao) => Promise<IBensClassificacao>;  
  getList: (filtro?: FilterBensClassificacao) => Promise<IBensClassificacao[]>;
  getAll: (filtro?: FilterBensClassificacao) => Promise<IBensClassificacao[]>;
  deleteBensClassificacao: (id: number) => Promise<void>;
  validateBensClassificacao: (bensclassificacao: IBensClassificacao) => { isValid: boolean; errors: string[] };
}

export class BensClassificacaoService implements IBensClassificacaoService {
  constructor(private api: BensClassificacaoApi) {}

  async fetchBensClassificacaoById(id: number): Promise<IBensClassificacao> {
    if (id <= 0) {
      throw new BensClassificacaoApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof BensClassificacaoApiError) {
        throw error;
      }
      throw new BensClassificacaoApiError('Erro ao buscar bensclassificacao', 500, 'FETCH_ERROR', error);
    }
  }

  async saveBensClassificacao(bensclassificacao: IBensClassificacao): Promise<IBensClassificacao> {    
    const validation = this.validateBensClassificacao(bensclassificacao);
    if (!validation.isValid) {
      throw new BensClassificacaoApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(bensclassificacao);
      return response.data;
    } catch (error) {
      if (error instanceof BensClassificacaoApiError) {
        throw error;
      }
      throw new BensClassificacaoApiError('Erro ao salvar bensclassificacao', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterBensClassificacao): Promise<IBensClassificacao[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching bensclassificacao list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterBensClassificacao): Promise<IBensClassificacao[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all bensclassificacao:', error);
      return [];
    }
  }

  async deleteBensClassificacao(id: number): Promise<void> {
    if (id <= 0) {
      throw new BensClassificacaoApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof BensClassificacaoApiError) {
        throw error;
      }
      throw new BensClassificacaoApiError('Erro ao excluir bensclassificacao', 500, 'DELETE_ERROR', error);
    }
  }

  validateBensClassificacao(bensclassificacao: IBensClassificacao): { isValid: boolean; errors: string[] } {
    return BensClassificacaoValidator.validateBensClassificacao(bensclassificacao);
  }
}