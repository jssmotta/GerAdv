'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { FornecedoresApi, FornecedoresApiError } from '../Apis/ApiFornecedores';
import { FilterFornecedores } from '../Filters/Fornecedores';
import { IFornecedores } from '../Interfaces/interface.Fornecedores';
import { FornecedoresEmpty } from '../../Models/Fornecedores';

export class FornecedoresValidator {
  static validateFornecedores(fornecedores: IFornecedores): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IFornecedoresService {
  fetchFornecedoresById: (id: number) => Promise<IFornecedores>;
  saveFornecedores: (fornecedores: IFornecedores) => Promise<IFornecedores>;  
  getList: (filtro?: FilterFornecedores) => Promise<IFornecedores[]>;
  getAll: (filtro?: FilterFornecedores) => Promise<IFornecedores[]>;
  deleteFornecedores: (id: number) => Promise<void>;
  validateFornecedores: (fornecedores: IFornecedores) => { isValid: boolean; errors: string[] };
}

export class FornecedoresService implements IFornecedoresService {
  constructor(private api: FornecedoresApi) {}

  async fetchFornecedoresById(id: number): Promise<IFornecedores> {
    if (id <= 0) {
      throw new FornecedoresApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof FornecedoresApiError) {
        throw error;
      }
      throw new FornecedoresApiError('Erro ao buscar fornecedores', 500, 'FETCH_ERROR', error);
    }
  }

  async saveFornecedores(fornecedores: IFornecedores): Promise<IFornecedores> {    
    const validation = this.validateFornecedores(fornecedores);
    if (!validation.isValid) {
      throw new FornecedoresApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(fornecedores);
      return response.data;
    } catch (error) {
      if (error instanceof FornecedoresApiError) {
        throw error;
      }
      throw new FornecedoresApiError('Erro ao salvar fornecedores', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterFornecedores): Promise<IFornecedores[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching fornecedores list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterFornecedores): Promise<IFornecedores[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all fornecedores:', error);
      return [];
    }
  }

  async deleteFornecedores(id: number): Promise<void> {
    if (id <= 0) {
      throw new FornecedoresApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof FornecedoresApiError) {
        throw error;
      }
      throw new FornecedoresApiError('Erro ao excluir fornecedores', 500, 'DELETE_ERROR', error);
    }
  }

  validateFornecedores(fornecedores: IFornecedores): { isValid: boolean; errors: string[] } {
    return FornecedoresValidator.validateFornecedores(fornecedores);
  }
}