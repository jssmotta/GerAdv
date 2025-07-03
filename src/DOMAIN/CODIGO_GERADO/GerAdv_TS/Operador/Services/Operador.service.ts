'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { OperadorApi, OperadorApiError } from '../Apis/ApiOperador';
import { FilterOperador } from '../Filters/Operador';
import { IOperador } from '../Interfaces/interface.Operador';
import { OperadorEmpty } from '../../Models/Operador';

export class OperadorValidator {
  static validateOperador(operador: IOperador): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IOperadorService {
  fetchOperadorById: (id: number) => Promise<IOperador>;
  saveOperador: (operador: IOperador) => Promise<IOperador>;  
  getList: (filtro?: FilterOperador) => Promise<IOperador[]>;
  getAll: (filtro?: FilterOperador) => Promise<IOperador[]>;
  deleteOperador: (id: number) => Promise<void>;
  validateOperador: (operador: IOperador) => { isValid: boolean; errors: string[] };
}

export class OperadorService implements IOperadorService {
  constructor(private api: OperadorApi) {}

  async fetchOperadorById(id: number): Promise<IOperador> {
    if (id <= 0) {
      throw new OperadorApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof OperadorApiError) {
        throw error;
      }
      throw new OperadorApiError('Erro ao buscar operador', 500, 'FETCH_ERROR', error);
    }
  }

  async saveOperador(operador: IOperador): Promise<IOperador> {    
    const validation = this.validateOperador(operador);
    if (!validation.isValid) {
      throw new OperadorApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(operador);
      return response.data;
    } catch (error) {
      if (error instanceof OperadorApiError) {
        throw error;
      }
      throw new OperadorApiError('Erro ao salvar operador', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterOperador): Promise<IOperador[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching operador list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterOperador): Promise<IOperador[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all operador:', error);
      return [];
    }
  }

  async deleteOperador(id: number): Promise<void> {
    if (id <= 0) {
      throw new OperadorApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof OperadorApiError) {
        throw error;
      }
      throw new OperadorApiError('Erro ao excluir operador', 500, 'DELETE_ERROR', error);
    }
  }

  validateOperador(operador: IOperador): { isValid: boolean; errors: string[] } {
    return OperadorValidator.validateOperador(operador);
  }
}