'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { OperadoresApi, OperadoresApiError } from '../Apis/ApiOperadores';
import { FilterOperadores } from '../Filters/Operadores';
import { IOperadores } from '../Interfaces/interface.Operadores';

export class OperadoresValidator {
  static validateOperadores(operadores: IOperadores): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IOperadoresService {
  fetchOperadoresById: (id: number) => Promise<IOperadores>;
  saveOperadores: (operadores: IOperadores) => Promise<IOperadores>;  
  getList: (filtro?: FilterOperadores) => Promise<IOperadores[]>;
  getAll: (filtro?: FilterOperadores) => Promise<IOperadores[]>;
  deleteOperadores: (id: number) => Promise<void>;
  validateOperadores: (operadores: IOperadores) => { isValid: boolean; errors: string[] };
}

export class OperadoresService implements IOperadoresService {
  constructor(private api: OperadoresApi) {}

  async fetchOperadoresById(id: number): Promise<IOperadores> {
    if (id <= 0) {
      throw new OperadoresApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof OperadoresApiError) {
        throw error;
      }
      throw new OperadoresApiError('Erro ao buscar operadores', 500, 'FETCH_ERROR', error);
    }
  }

  async saveOperadores(operadores: IOperadores): Promise<IOperadores> {    
    const validation = this.validateOperadores(operadores);
    if (!validation.isValid) {
      throw new OperadoresApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(operadores);
      return response.data;
    } catch (error) {
      if (error instanceof OperadoresApiError) {
        throw error;
      }
      throw new OperadoresApiError('Erro ao salvar operadores', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterOperadores): Promise<IOperadores[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching operadores list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterOperadores): Promise<IOperadores[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all operadores:', error);
      return [];
    }
  }

  async deleteOperadores(id: number): Promise<void> {
    if (id <= 0) {
      throw new OperadoresApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof OperadoresApiError) {
        throw error;
      }
      throw new OperadoresApiError('Erro ao excluir operadores', 500, 'DELETE_ERROR', error);
    }
  }

  validateOperadores(operadores: IOperadores): { isValid: boolean; errors: string[] } {
    return OperadoresValidator.validateOperadores(operadores);
  }
}