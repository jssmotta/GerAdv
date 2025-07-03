'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ContaCorrenteApi, ContaCorrenteApiError } from '../Apis/ApiContaCorrente';
import { FilterContaCorrente } from '../Filters/ContaCorrente';
import { IContaCorrente } from '../Interfaces/interface.ContaCorrente';
import { ContaCorrenteEmpty } from '../../Models/ContaCorrente';

export class ContaCorrenteValidator {
  static validateContaCorrente(contacorrente: IContaCorrente): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IContaCorrenteService {
  fetchContaCorrenteById: (id: number) => Promise<IContaCorrente>;
  saveContaCorrente: (contacorrente: IContaCorrente) => Promise<IContaCorrente>;  
  
  getAll: (filtro?: FilterContaCorrente) => Promise<IContaCorrente[]>;
  deleteContaCorrente: (id: number) => Promise<void>;
  validateContaCorrente: (contacorrente: IContaCorrente) => { isValid: boolean; errors: string[] };
}

export class ContaCorrenteService implements IContaCorrenteService {
  constructor(private api: ContaCorrenteApi) {}

  async fetchContaCorrenteById(id: number): Promise<IContaCorrente> {
    if (id <= 0) {
      throw new ContaCorrenteApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof ContaCorrenteApiError) {
        throw error;
      }
      throw new ContaCorrenteApiError('Erro ao buscar contacorrente', 500, 'FETCH_ERROR', error);
    }
  }

  async saveContaCorrente(contacorrente: IContaCorrente): Promise<IContaCorrente> {    
    const validation = this.validateContaCorrente(contacorrente);
    if (!validation.isValid) {
      throw new ContaCorrenteApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(contacorrente);
      return response.data;
    } catch (error) {
      if (error instanceof ContaCorrenteApiError) {
        throw error;
      }
      throw new ContaCorrenteApiError('Erro ao salvar contacorrente', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterContaCorrente): Promise<IContaCorrente[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all contacorrente:', error);
      return [];
    }
  }

  async deleteContaCorrente(id: number): Promise<void> {
    if (id <= 0) {
      throw new ContaCorrenteApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ContaCorrenteApiError) {
        throw error;
      }
      throw new ContaCorrenteApiError('Erro ao excluir contacorrente', 500, 'DELETE_ERROR', error);
    }
  }

  validateContaCorrente(contacorrente: IContaCorrente): { isValid: boolean; errors: string[] } {
    return ContaCorrenteValidator.validateContaCorrente(contacorrente);
  }
}