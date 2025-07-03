'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { PrecatoriaApi, PrecatoriaApiError } from '../Apis/ApiPrecatoria';
import { FilterPrecatoria } from '../Filters/Precatoria';
import { IPrecatoria } from '../Interfaces/interface.Precatoria';
import { PrecatoriaEmpty } from '../../Models/Precatoria';

export class PrecatoriaValidator {
  static validatePrecatoria(precatoria: IPrecatoria): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IPrecatoriaService {
  fetchPrecatoriaById: (id: number) => Promise<IPrecatoria>;
  savePrecatoria: (precatoria: IPrecatoria) => Promise<IPrecatoria>;  
  
  getAll: (filtro?: FilterPrecatoria) => Promise<IPrecatoria[]>;
  deletePrecatoria: (id: number) => Promise<void>;
  validatePrecatoria: (precatoria: IPrecatoria) => { isValid: boolean; errors: string[] };
}

export class PrecatoriaService implements IPrecatoriaService {
  constructor(private api: PrecatoriaApi) {}

  async fetchPrecatoriaById(id: number): Promise<IPrecatoria> {
    if (id <= 0) {
      throw new PrecatoriaApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof PrecatoriaApiError) {
        throw error;
      }
      throw new PrecatoriaApiError('Erro ao buscar precatoria', 500, 'FETCH_ERROR', error);
    }
  }

  async savePrecatoria(precatoria: IPrecatoria): Promise<IPrecatoria> {    
    const validation = this.validatePrecatoria(precatoria);
    if (!validation.isValid) {
      throw new PrecatoriaApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(precatoria);
      return response.data;
    } catch (error) {
      if (error instanceof PrecatoriaApiError) {
        throw error;
      }
      throw new PrecatoriaApiError('Erro ao salvar precatoria', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterPrecatoria): Promise<IPrecatoria[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all precatoria:', error);
      return [];
    }
  }

  async deletePrecatoria(id: number): Promise<void> {
    if (id <= 0) {
      throw new PrecatoriaApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof PrecatoriaApiError) {
        throw error;
      }
      throw new PrecatoriaApiError('Erro ao excluir precatoria', 500, 'DELETE_ERROR', error);
    }
  }

  validatePrecatoria(precatoria: IPrecatoria): { isValid: boolean; errors: string[] } {
    return PrecatoriaValidator.validatePrecatoria(precatoria);
  }
}