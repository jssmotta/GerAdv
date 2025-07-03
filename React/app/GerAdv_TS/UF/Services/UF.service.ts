'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { UFApi, UFApiError } from '../Apis/ApiUF';
import { FilterUF } from '../Filters/UF';
import { IUF } from '../Interfaces/interface.UF';
import { UFEmpty } from '../../Models/UF';

export class UFValidator {
  static validateUF(uf: IUF): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IUFService {
  fetchUFById: (id: number) => Promise<IUF>;
  saveUF: (uf: IUF) => Promise<IUF>;  
  getList: (filtro?: FilterUF) => Promise<IUF[]>;
  getAll: (filtro?: FilterUF) => Promise<IUF[]>;
  deleteUF: (id: number) => Promise<void>;
  validateUF: (uf: IUF) => { isValid: boolean; errors: string[] };
}

export class UFService implements IUFService {
  constructor(private api: UFApi) {}

  async fetchUFById(id: number): Promise<IUF> {
    if (id <= 0) {
      throw new UFApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof UFApiError) {
        throw error;
      }
      throw new UFApiError('Erro ao buscar uf', 500, 'FETCH_ERROR', error);
    }
  }

  async saveUF(uf: IUF): Promise<IUF> {    
    const validation = this.validateUF(uf);
    if (!validation.isValid) {
      throw new UFApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(uf);
      return response.data;
    } catch (error) {
      if (error instanceof UFApiError) {
        throw error;
      }
      throw new UFApiError('Erro ao salvar uf', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterUF): Promise<IUF[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching uf list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterUF): Promise<IUF[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all uf:', error);
      return [];
    }
  }

  async deleteUF(id: number): Promise<void> {
    if (id <= 0) {
      throw new UFApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof UFApiError) {
        throw error;
      }
      throw new UFApiError('Erro ao excluir uf', 500, 'DELETE_ERROR', error);
    }
  }

  validateUF(uf: IUF): { isValid: boolean; errors: string[] } {
    return UFValidator.validateUF(uf);
  }
}