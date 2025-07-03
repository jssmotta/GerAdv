'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { RegimeTributacaoApi, RegimeTributacaoApiError } from '../Apis/ApiRegimeTributacao';
import { FilterRegimeTributacao } from '../Filters/RegimeTributacao';
import { IRegimeTributacao } from '../Interfaces/interface.RegimeTributacao';
import { RegimeTributacaoEmpty } from '../../Models/RegimeTributacao';

export class RegimeTributacaoValidator {
  static validateRegimeTributacao(regimetributacao: IRegimeTributacao): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IRegimeTributacaoService {
  fetchRegimeTributacaoById: (id: number) => Promise<IRegimeTributacao>;
  saveRegimeTributacao: (regimetributacao: IRegimeTributacao) => Promise<IRegimeTributacao>;  
  getList: (filtro?: FilterRegimeTributacao) => Promise<IRegimeTributacao[]>;
  getAll: (filtro?: FilterRegimeTributacao) => Promise<IRegimeTributacao[]>;
  deleteRegimeTributacao: (id: number) => Promise<void>;
  validateRegimeTributacao: (regimetributacao: IRegimeTributacao) => { isValid: boolean; errors: string[] };
}

export class RegimeTributacaoService implements IRegimeTributacaoService {
  constructor(private api: RegimeTributacaoApi) {}

  async fetchRegimeTributacaoById(id: number): Promise<IRegimeTributacao> {
    if (id <= 0) {
      throw new RegimeTributacaoApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof RegimeTributacaoApiError) {
        throw error;
      }
      throw new RegimeTributacaoApiError('Erro ao buscar regimetributacao', 500, 'FETCH_ERROR', error);
    }
  }

  async saveRegimeTributacao(regimetributacao: IRegimeTributacao): Promise<IRegimeTributacao> {    
    const validation = this.validateRegimeTributacao(regimetributacao);
    if (!validation.isValid) {
      throw new RegimeTributacaoApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(regimetributacao);
      return response.data;
    } catch (error) {
      if (error instanceof RegimeTributacaoApiError) {
        throw error;
      }
      throw new RegimeTributacaoApiError('Erro ao salvar regimetributacao', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterRegimeTributacao): Promise<IRegimeTributacao[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching regimetributacao list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterRegimeTributacao): Promise<IRegimeTributacao[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all regimetributacao:', error);
      return [];
    }
  }

  async deleteRegimeTributacao(id: number): Promise<void> {
    if (id <= 0) {
      throw new RegimeTributacaoApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof RegimeTributacaoApiError) {
        throw error;
      }
      throw new RegimeTributacaoApiError('Erro ao excluir regimetributacao', 500, 'DELETE_ERROR', error);
    }
  }

  validateRegimeTributacao(regimetributacao: IRegimeTributacao): { isValid: boolean; errors: string[] } {
    return RegimeTributacaoValidator.validateRegimeTributacao(regimetributacao);
  }
}