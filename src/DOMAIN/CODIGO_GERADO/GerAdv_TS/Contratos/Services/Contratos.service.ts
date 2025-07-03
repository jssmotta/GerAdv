'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ContratosApi, ContratosApiError } from '../Apis/ApiContratos';
import { FilterContratos } from '../Filters/Contratos';
import { IContratos } from '../Interfaces/interface.Contratos';
import { ContratosEmpty } from '../../Models/Contratos';

export class ContratosValidator {
  static validateContratos(contratos: IContratos): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IContratosService {
  fetchContratosById: (id: number) => Promise<IContratos>;
  saveContratos: (contratos: IContratos) => Promise<IContratos>;  
  
  getAll: (filtro?: FilterContratos) => Promise<IContratos[]>;
  deleteContratos: (id: number) => Promise<void>;
  validateContratos: (contratos: IContratos) => { isValid: boolean; errors: string[] };
}

export class ContratosService implements IContratosService {
  constructor(private api: ContratosApi) {}

  async fetchContratosById(id: number): Promise<IContratos> {
    if (id <= 0) {
      throw new ContratosApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof ContratosApiError) {
        throw error;
      }
      throw new ContratosApiError('Erro ao buscar contratos', 500, 'FETCH_ERROR', error);
    }
  }

  async saveContratos(contratos: IContratos): Promise<IContratos> {    
    const validation = this.validateContratos(contratos);
    if (!validation.isValid) {
      throw new ContratosApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(contratos);
      return response.data;
    } catch (error) {
      if (error instanceof ContratosApiError) {
        throw error;
      }
      throw new ContratosApiError('Erro ao salvar contratos', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterContratos): Promise<IContratos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all contratos:', error);
      return [];
    }
  }

  async deleteContratos(id: number): Promise<void> {
    if (id <= 0) {
      throw new ContratosApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ContratosApiError) {
        throw error;
      }
      throw new ContratosApiError('Erro ao excluir contratos', 500, 'DELETE_ERROR', error);
    }
  }

  validateContratos(contratos: IContratos): { isValid: boolean; errors: string[] } {
    return ContratosValidator.validateContratos(contratos);
  }
}