'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ProCDAApi, ProCDAApiError } from '../Apis/ApiProCDA';
import { FilterProCDA } from '../Filters/ProCDA';
import { IProCDA } from '../Interfaces/interface.ProCDA';

export class ProCDAValidator {
  static validateProCDA(procda: IProCDA): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IProCDAService {
  fetchProCDAById: (id: number) => Promise<IProCDA>;
  saveProCDA: (procda: IProCDA) => Promise<IProCDA>;  
  getList: (filtro?: FilterProCDA) => Promise<IProCDA[]>;
  getAll: (filtro?: FilterProCDA) => Promise<IProCDA[]>;
  deleteProCDA: (id: number) => Promise<void>;
  validateProCDA: (procda: IProCDA) => { isValid: boolean; errors: string[] };
}

export class ProCDAService implements IProCDAService {
  constructor(private api: ProCDAApi) {}

  async fetchProCDAById(id: number): Promise<IProCDA> {
    if (id <= 0) {
      throw new ProCDAApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof ProCDAApiError) {
        throw error;
      }
      throw new ProCDAApiError('Erro ao buscar procda', 500, 'FETCH_ERROR', error);
    }
  }

  async saveProCDA(procda: IProCDA): Promise<IProCDA> {    
    const validation = this.validateProCDA(procda);
    if (!validation.isValid) {
      throw new ProCDAApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(procda);
      return response.data;
    } catch (error) {
      if (error instanceof ProCDAApiError) {
        throw error;
      }
      throw new ProCDAApiError('Erro ao salvar procda', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterProCDA): Promise<IProCDA[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching procda list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterProCDA): Promise<IProCDA[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all procda:', error);
      return [];
    }
  }

  async deleteProCDA(id: number): Promise<void> {
    if (id <= 0) {
      throw new ProCDAApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ProCDAApiError) {
        throw error;
      }
      throw new ProCDAApiError('Erro ao excluir procda', 500, 'DELETE_ERROR', error);
    }
  }

  validateProCDA(procda: IProCDA): { isValid: boolean; errors: string[] } {
    return ProCDAValidator.validateProCDA(procda);
  }
}