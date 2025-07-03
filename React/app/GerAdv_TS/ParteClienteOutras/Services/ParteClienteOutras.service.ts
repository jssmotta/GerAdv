'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ParteClienteOutrasApi, ParteClienteOutrasApiError } from '../Apis/ApiParteClienteOutras';
import { FilterParteClienteOutras } from '../Filters/ParteClienteOutras';
import { IParteClienteOutras } from '../Interfaces/interface.ParteClienteOutras';
import { ParteClienteOutrasEmpty } from '../../Models/ParteClienteOutras';

export class ParteClienteOutrasValidator {
  static validateParteClienteOutras(parteclienteoutras: IParteClienteOutras): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IParteClienteOutrasService {
  fetchParteClienteOutrasById: (id: number) => Promise<IParteClienteOutras>;
  saveParteClienteOutras: (parteclienteoutras: IParteClienteOutras) => Promise<IParteClienteOutras>;  
  
  getAll: (filtro?: FilterParteClienteOutras) => Promise<IParteClienteOutras[]>;
  deleteParteClienteOutras: (id: number) => Promise<void>;
  validateParteClienteOutras: (parteclienteoutras: IParteClienteOutras) => { isValid: boolean; errors: string[] };
}

export class ParteClienteOutrasService implements IParteClienteOutrasService {
  constructor(private api: ParteClienteOutrasApi) {}

  async fetchParteClienteOutrasById(id: number): Promise<IParteClienteOutras> {
    if (id <= 0) {
      throw new ParteClienteOutrasApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof ParteClienteOutrasApiError) {
        throw error;
      }
      throw new ParteClienteOutrasApiError('Erro ao buscar parteclienteoutras', 500, 'FETCH_ERROR', error);
    }
  }

  async saveParteClienteOutras(parteclienteoutras: IParteClienteOutras): Promise<IParteClienteOutras> {    
    const validation = this.validateParteClienteOutras(parteclienteoutras);
    if (!validation.isValid) {
      throw new ParteClienteOutrasApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(parteclienteoutras);
      return response.data;
    } catch (error) {
      if (error instanceof ParteClienteOutrasApiError) {
        throw error;
      }
      throw new ParteClienteOutrasApiError('Erro ao salvar parteclienteoutras', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterParteClienteOutras): Promise<IParteClienteOutras[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all parteclienteoutras:', error);
      return [];
    }
  }

  async deleteParteClienteOutras(id: number): Promise<void> {
    if (id <= 0) {
      throw new ParteClienteOutrasApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ParteClienteOutrasApiError) {
        throw error;
      }
      throw new ParteClienteOutrasApiError('Erro ao excluir parteclienteoutras', 500, 'DELETE_ERROR', error);
    }
  }

  validateParteClienteOutras(parteclienteoutras: IParteClienteOutras): { isValid: boolean; errors: string[] } {
    return ParteClienteOutrasValidator.validateParteClienteOutras(parteclienteoutras);
  }
}