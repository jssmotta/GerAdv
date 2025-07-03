'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { DivisaoTribunalApi, DivisaoTribunalApiError } from '../Apis/ApiDivisaoTribunal';
import { FilterDivisaoTribunal } from '../Filters/DivisaoTribunal';
import { IDivisaoTribunal } from '../Interfaces/interface.DivisaoTribunal';
import { DivisaoTribunalEmpty } from '../../Models/DivisaoTribunal';

export class DivisaoTribunalValidator {
  static validateDivisaoTribunal(divisaotribunal: IDivisaoTribunal): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IDivisaoTribunalService {
  fetchDivisaoTribunalById: (id: number) => Promise<IDivisaoTribunal>;
  saveDivisaoTribunal: (divisaotribunal: IDivisaoTribunal) => Promise<IDivisaoTribunal>;  
  
  getAll: (filtro?: FilterDivisaoTribunal) => Promise<IDivisaoTribunal[]>;
  deleteDivisaoTribunal: (id: number) => Promise<void>;
  validateDivisaoTribunal: (divisaotribunal: IDivisaoTribunal) => { isValid: boolean; errors: string[] };
}

export class DivisaoTribunalService implements IDivisaoTribunalService {
  constructor(private api: DivisaoTribunalApi) {}

  async fetchDivisaoTribunalById(id: number): Promise<IDivisaoTribunal> {
    if (id <= 0) {
      throw new DivisaoTribunalApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof DivisaoTribunalApiError) {
        throw error;
      }
      throw new DivisaoTribunalApiError('Erro ao buscar divisaotribunal', 500, 'FETCH_ERROR', error);
    }
  }

  async saveDivisaoTribunal(divisaotribunal: IDivisaoTribunal): Promise<IDivisaoTribunal> {    
    const validation = this.validateDivisaoTribunal(divisaotribunal);
    if (!validation.isValid) {
      throw new DivisaoTribunalApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(divisaotribunal);
      return response.data;
    } catch (error) {
      if (error instanceof DivisaoTribunalApiError) {
        throw error;
      }
      throw new DivisaoTribunalApiError('Erro ao salvar divisaotribunal', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterDivisaoTribunal): Promise<IDivisaoTribunal[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all divisaotribunal:', error);
      return [];
    }
  }

  async deleteDivisaoTribunal(id: number): Promise<void> {
    if (id <= 0) {
      throw new DivisaoTribunalApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof DivisaoTribunalApiError) {
        throw error;
      }
      throw new DivisaoTribunalApiError('Erro ao excluir divisaotribunal', 500, 'DELETE_ERROR', error);
    }
  }

  validateDivisaoTribunal(divisaotribunal: IDivisaoTribunal): { isValid: boolean; errors: string[] } {
    return DivisaoTribunalValidator.validateDivisaoTribunal(divisaotribunal);
  }
}