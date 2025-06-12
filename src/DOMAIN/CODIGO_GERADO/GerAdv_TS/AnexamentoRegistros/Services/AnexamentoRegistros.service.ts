'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { AnexamentoRegistrosApi, AnexamentoRegistrosApiError } from '../Apis/ApiAnexamentoRegistros';
import { FilterAnexamentoRegistros } from '../Filters/AnexamentoRegistros';
import { IAnexamentoRegistros } from '../Interfaces/interface.AnexamentoRegistros';

export class AnexamentoRegistrosValidator {
  static validateAnexamentoRegistros(anexamentoregistros: IAnexamentoRegistros): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IAnexamentoRegistrosService {
  fetchAnexamentoRegistrosById: (id: number) => Promise<IAnexamentoRegistros>;
  saveAnexamentoRegistros: (anexamentoregistros: IAnexamentoRegistros) => Promise<IAnexamentoRegistros>;  
  
  getAll: (filtro?: FilterAnexamentoRegistros) => Promise<IAnexamentoRegistros[]>;
  deleteAnexamentoRegistros: (id: number) => Promise<void>;
  validateAnexamentoRegistros: (anexamentoregistros: IAnexamentoRegistros) => { isValid: boolean; errors: string[] };
}

export class AnexamentoRegistrosService implements IAnexamentoRegistrosService {
  constructor(private api: AnexamentoRegistrosApi) {}

  async fetchAnexamentoRegistrosById(id: number): Promise<IAnexamentoRegistros> {
    if (id <= 0) {
      throw new AnexamentoRegistrosApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof AnexamentoRegistrosApiError) {
        throw error;
      }
      throw new AnexamentoRegistrosApiError('Erro ao buscar anexamentoregistros', 500, 'FETCH_ERROR', error);
    }
  }

  async saveAnexamentoRegistros(anexamentoregistros: IAnexamentoRegistros): Promise<IAnexamentoRegistros> {    
    const validation = this.validateAnexamentoRegistros(anexamentoregistros);
    if (!validation.isValid) {
      throw new AnexamentoRegistrosApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(anexamentoregistros);
      return response.data;
    } catch (error) {
      if (error instanceof AnexamentoRegistrosApiError) {
        throw error;
      }
      throw new AnexamentoRegistrosApiError('Erro ao salvar anexamentoregistros', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterAnexamentoRegistros): Promise<IAnexamentoRegistros[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all anexamentoregistros:', error);
      return [];
    }
  }

  async deleteAnexamentoRegistros(id: number): Promise<void> {
    if (id <= 0) {
      throw new AnexamentoRegistrosApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof AnexamentoRegistrosApiError) {
        throw error;
      }
      throw new AnexamentoRegistrosApiError('Erro ao excluir anexamentoregistros', 500, 'DELETE_ERROR', error);
    }
  }

  validateAnexamentoRegistros(anexamentoregistros: IAnexamentoRegistros): { isValid: boolean; errors: string[] } {
    return AnexamentoRegistrosValidator.validateAnexamentoRegistros(anexamentoregistros);
  }
}