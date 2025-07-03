'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { BensMateriaisApi, BensMateriaisApiError } from '../Apis/ApiBensMateriais';
import { FilterBensMateriais } from '../Filters/BensMateriais';
import { IBensMateriais } from '../Interfaces/interface.BensMateriais';
import { BensMateriaisEmpty } from '../../Models/BensMateriais';

export class BensMateriaisValidator {
  static validateBensMateriais(bensmateriais: IBensMateriais): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IBensMateriaisService {
  fetchBensMateriaisById: (id: number) => Promise<IBensMateriais>;
  saveBensMateriais: (bensmateriais: IBensMateriais) => Promise<IBensMateriais>;  
  getList: (filtro?: FilterBensMateriais) => Promise<IBensMateriais[]>;
  getAll: (filtro?: FilterBensMateriais) => Promise<IBensMateriais[]>;
  deleteBensMateriais: (id: number) => Promise<void>;
  validateBensMateriais: (bensmateriais: IBensMateriais) => { isValid: boolean; errors: string[] };
}

export class BensMateriaisService implements IBensMateriaisService {
  constructor(private api: BensMateriaisApi) {}

  async fetchBensMateriaisById(id: number): Promise<IBensMateriais> {
    if (id <= 0) {
      throw new BensMateriaisApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof BensMateriaisApiError) {
        throw error;
      }
      throw new BensMateriaisApiError('Erro ao buscar bensmateriais', 500, 'FETCH_ERROR', error);
    }
  }

  async saveBensMateriais(bensmateriais: IBensMateriais): Promise<IBensMateriais> {    
    const validation = this.validateBensMateriais(bensmateriais);
    if (!validation.isValid) {
      throw new BensMateriaisApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(bensmateriais);
      return response.data;
    } catch (error) {
      if (error instanceof BensMateriaisApiError) {
        throw error;
      }
      throw new BensMateriaisApiError('Erro ao salvar bensmateriais', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterBensMateriais): Promise<IBensMateriais[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching bensmateriais list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterBensMateriais): Promise<IBensMateriais[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all bensmateriais:', error);
      return [];
    }
  }

  async deleteBensMateriais(id: number): Promise<void> {
    if (id <= 0) {
      throw new BensMateriaisApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof BensMateriaisApiError) {
        throw error;
      }
      throw new BensMateriaisApiError('Erro ao excluir bensmateriais', 500, 'DELETE_ERROR', error);
    }
  }

  validateBensMateriais(bensmateriais: IBensMateriais): { isValid: boolean; errors: string[] } {
    return BensMateriaisValidator.validateBensMateriais(bensmateriais);
  }
}