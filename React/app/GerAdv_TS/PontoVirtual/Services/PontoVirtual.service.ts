'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { PontoVirtualApi, PontoVirtualApiError } from '../Apis/ApiPontoVirtual';
import { FilterPontoVirtual } from '../Filters/PontoVirtual';
import { IPontoVirtual } from '../Interfaces/interface.PontoVirtual';
import { PontoVirtualEmpty } from '../../Models/PontoVirtual';

export class PontoVirtualValidator {
  static validatePontoVirtual(pontovirtual: IPontoVirtual): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IPontoVirtualService {
  fetchPontoVirtualById: (id: number) => Promise<IPontoVirtual>;
  savePontoVirtual: (pontovirtual: IPontoVirtual) => Promise<IPontoVirtual>;  
  
  getAll: (filtro?: FilterPontoVirtual) => Promise<IPontoVirtual[]>;
  deletePontoVirtual: (id: number) => Promise<void>;
  validatePontoVirtual: (pontovirtual: IPontoVirtual) => { isValid: boolean; errors: string[] };
}

export class PontoVirtualService implements IPontoVirtualService {
  constructor(private api: PontoVirtualApi) {}

  async fetchPontoVirtualById(id: number): Promise<IPontoVirtual> {
    if (id <= 0) {
      throw new PontoVirtualApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof PontoVirtualApiError) {
        throw error;
      }
      throw new PontoVirtualApiError('Erro ao buscar pontovirtual', 500, 'FETCH_ERROR', error);
    }
  }

  async savePontoVirtual(pontovirtual: IPontoVirtual): Promise<IPontoVirtual> {    
    const validation = this.validatePontoVirtual(pontovirtual);
    if (!validation.isValid) {
      throw new PontoVirtualApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(pontovirtual);
      return response.data;
    } catch (error) {
      if (error instanceof PontoVirtualApiError) {
        throw error;
      }
      throw new PontoVirtualApiError('Erro ao salvar pontovirtual', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterPontoVirtual): Promise<IPontoVirtual[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all pontovirtual:', error);
      return [];
    }
  }

  async deletePontoVirtual(id: number): Promise<void> {
    if (id <= 0) {
      throw new PontoVirtualApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof PontoVirtualApiError) {
        throw error;
      }
      throw new PontoVirtualApiError('Erro ao excluir pontovirtual', 500, 'DELETE_ERROR', error);
    }
  }

  validatePontoVirtual(pontovirtual: IPontoVirtual): { isValid: boolean; errors: string[] } {
    return PontoVirtualValidator.validatePontoVirtual(pontovirtual);
  }
}