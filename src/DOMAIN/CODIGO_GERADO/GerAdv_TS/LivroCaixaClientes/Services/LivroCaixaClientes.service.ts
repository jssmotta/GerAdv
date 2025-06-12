'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { LivroCaixaClientesApi, LivroCaixaClientesApiError } from '../Apis/ApiLivroCaixaClientes';
import { FilterLivroCaixaClientes } from '../Filters/LivroCaixaClientes';
import { ILivroCaixaClientes } from '../Interfaces/interface.LivroCaixaClientes';

export class LivroCaixaClientesValidator {
  static validateLivroCaixaClientes(livrocaixaclientes: ILivroCaixaClientes): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface ILivroCaixaClientesService {
  fetchLivroCaixaClientesById: (id: number) => Promise<ILivroCaixaClientes>;
  saveLivroCaixaClientes: (livrocaixaclientes: ILivroCaixaClientes) => Promise<ILivroCaixaClientes>;  
  
  getAll: (filtro?: FilterLivroCaixaClientes) => Promise<ILivroCaixaClientes[]>;
  deleteLivroCaixaClientes: (id: number) => Promise<void>;
  validateLivroCaixaClientes: (livrocaixaclientes: ILivroCaixaClientes) => { isValid: boolean; errors: string[] };
}

export class LivroCaixaClientesService implements ILivroCaixaClientesService {
  constructor(private api: LivroCaixaClientesApi) {}

  async fetchLivroCaixaClientesById(id: number): Promise<ILivroCaixaClientes> {
    if (id <= 0) {
      throw new LivroCaixaClientesApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof LivroCaixaClientesApiError) {
        throw error;
      }
      throw new LivroCaixaClientesApiError('Erro ao buscar livrocaixaclientes', 500, 'FETCH_ERROR', error);
    }
  }

  async saveLivroCaixaClientes(livrocaixaclientes: ILivroCaixaClientes): Promise<ILivroCaixaClientes> {    
    const validation = this.validateLivroCaixaClientes(livrocaixaclientes);
    if (!validation.isValid) {
      throw new LivroCaixaClientesApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(livrocaixaclientes);
      return response.data;
    } catch (error) {
      if (error instanceof LivroCaixaClientesApiError) {
        throw error;
      }
      throw new LivroCaixaClientesApiError('Erro ao salvar livrocaixaclientes', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterLivroCaixaClientes): Promise<ILivroCaixaClientes[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all livrocaixaclientes:', error);
      return [];
    }
  }

  async deleteLivroCaixaClientes(id: number): Promise<void> {
    if (id <= 0) {
      throw new LivroCaixaClientesApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof LivroCaixaClientesApiError) {
        throw error;
      }
      throw new LivroCaixaClientesApiError('Erro ao excluir livrocaixaclientes', 500, 'DELETE_ERROR', error);
    }
  }

  validateLivroCaixaClientes(livrocaixaclientes: ILivroCaixaClientes): { isValid: boolean; errors: string[] } {
    return LivroCaixaClientesValidator.validateLivroCaixaClientes(livrocaixaclientes);
  }
}