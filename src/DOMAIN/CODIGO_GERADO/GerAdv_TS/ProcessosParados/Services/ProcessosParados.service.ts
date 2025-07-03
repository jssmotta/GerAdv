'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ProcessosParadosApi, ProcessosParadosApiError } from '../Apis/ApiProcessosParados';
import { FilterProcessosParados } from '../Filters/ProcessosParados';
import { IProcessosParados } from '../Interfaces/interface.ProcessosParados';
import { ProcessosParadosEmpty } from '../../Models/ProcessosParados';

export class ProcessosParadosValidator {
  static validateProcessosParados(processosparados: IProcessosParados): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IProcessosParadosService {
  fetchProcessosParadosById: (id: number) => Promise<IProcessosParados>;
  saveProcessosParados: (processosparados: IProcessosParados) => Promise<IProcessosParados>;  
  
  getAll: (filtro?: FilterProcessosParados) => Promise<IProcessosParados[]>;
  deleteProcessosParados: (id: number) => Promise<void>;
  validateProcessosParados: (processosparados: IProcessosParados) => { isValid: boolean; errors: string[] };
}

export class ProcessosParadosService implements IProcessosParadosService {
  constructor(private api: ProcessosParadosApi) {}

  async fetchProcessosParadosById(id: number): Promise<IProcessosParados> {
    if (id <= 0) {
      throw new ProcessosParadosApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof ProcessosParadosApiError) {
        throw error;
      }
      throw new ProcessosParadosApiError('Erro ao buscar processosparados', 500, 'FETCH_ERROR', error);
    }
  }

  async saveProcessosParados(processosparados: IProcessosParados): Promise<IProcessosParados> {    
    const validation = this.validateProcessosParados(processosparados);
    if (!validation.isValid) {
      throw new ProcessosParadosApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(processosparados);
      return response.data;
    } catch (error) {
      if (error instanceof ProcessosParadosApiError) {
        throw error;
      }
      throw new ProcessosParadosApiError('Erro ao salvar processosparados', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterProcessosParados): Promise<IProcessosParados[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all processosparados:', error);
      return [];
    }
  }

  async deleteProcessosParados(id: number): Promise<void> {
    if (id <= 0) {
      throw new ProcessosParadosApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ProcessosParadosApiError) {
        throw error;
      }
      throw new ProcessosParadosApiError('Erro ao excluir processosparados', 500, 'DELETE_ERROR', error);
    }
  }

  validateProcessosParados(processosparados: IProcessosParados): { isValid: boolean; errors: string[] } {
    return ProcessosParadosValidator.validateProcessosParados(processosparados);
  }
}