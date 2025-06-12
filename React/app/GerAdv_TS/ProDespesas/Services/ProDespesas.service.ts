'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ProDespesasApi, ProDespesasApiError } from '../Apis/ApiProDespesas';
import { FilterProDespesas } from '../Filters/ProDespesas';
import { IProDespesas } from '../Interfaces/interface.ProDespesas';

export class ProDespesasValidator {
  static validateProDespesas(prodespesas: IProDespesas): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IProDespesasService {
  fetchProDespesasById: (id: number) => Promise<IProDespesas>;
  saveProDespesas: (prodespesas: IProDespesas) => Promise<IProDespesas>;  
  
  getAll: (filtro?: FilterProDespesas) => Promise<IProDespesas[]>;
  deleteProDespesas: (id: number) => Promise<void>;
  validateProDespesas: (prodespesas: IProDespesas) => { isValid: boolean; errors: string[] };
}

export class ProDespesasService implements IProDespesasService {
  constructor(private api: ProDespesasApi) {}

  async fetchProDespesasById(id: number): Promise<IProDespesas> {
    if (id <= 0) {
      throw new ProDespesasApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof ProDespesasApiError) {
        throw error;
      }
      throw new ProDespesasApiError('Erro ao buscar prodespesas', 500, 'FETCH_ERROR', error);
    }
  }

  async saveProDespesas(prodespesas: IProDespesas): Promise<IProDespesas> {    
    const validation = this.validateProDespesas(prodespesas);
    if (!validation.isValid) {
      throw new ProDespesasApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(prodespesas);
      return response.data;
    } catch (error) {
      if (error instanceof ProDespesasApiError) {
        throw error;
      }
      throw new ProDespesasApiError('Erro ao salvar prodespesas', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterProDespesas): Promise<IProDespesas[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all prodespesas:', error);
      return [];
    }
  }

  async deleteProDespesas(id: number): Promise<void> {
    if (id <= 0) {
      throw new ProDespesasApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ProDespesasApiError) {
        throw error;
      }
      throw new ProDespesasApiError('Erro ao excluir prodespesas', 500, 'DELETE_ERROR', error);
    }
  }

  validateProDespesas(prodespesas: IProDespesas): { isValid: boolean; errors: string[] } {
    return ProDespesasValidator.validateProDespesas(prodespesas);
  }
}