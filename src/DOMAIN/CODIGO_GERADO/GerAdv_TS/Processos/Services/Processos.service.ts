'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ProcessosApi, ProcessosApiError } from '../Apis/ApiProcessos';
import { FilterProcessos } from '../Filters/Processos';
import { IProcessos } from '../Interfaces/interface.Processos';
import { ProcessosEmpty } from '../../Models/Processos';

export class ProcessosValidator {
  static validateProcessos(processos: IProcessos): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IProcessosService {
  fetchProcessosById: (id: number) => Promise<IProcessos>;
  saveProcessos: (processos: IProcessos) => Promise<IProcessos>;  
  getList: (filtro?: FilterProcessos) => Promise<IProcessos[]>;
  getAll: (filtro?: FilterProcessos) => Promise<IProcessos[]>;
  deleteProcessos: (id: number) => Promise<void>;
  validateProcessos: (processos: IProcessos) => { isValid: boolean; errors: string[] };
}

export class ProcessosService implements IProcessosService {
  constructor(private api: ProcessosApi) {}

  async fetchProcessosById(id: number): Promise<IProcessos> {
    if (id <= 0) {
      throw new ProcessosApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof ProcessosApiError) {
        throw error;
      }
      throw new ProcessosApiError('Erro ao buscar processos', 500, 'FETCH_ERROR', error);
    }
  }

  async saveProcessos(processos: IProcessos): Promise<IProcessos> {    
    const validation = this.validateProcessos(processos);
    if (!validation.isValid) {
      throw new ProcessosApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(processos);
      return response.data;
    } catch (error) {
      if (error instanceof ProcessosApiError) {
        throw error;
      }
      throw new ProcessosApiError('Erro ao salvar processos', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterProcessos): Promise<IProcessos[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching processos list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterProcessos): Promise<IProcessos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all processos:', error);
      return [];
    }
  }

  async deleteProcessos(id: number): Promise<void> {
    if (id <= 0) {
      throw new ProcessosApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ProcessosApiError) {
        throw error;
      }
      throw new ProcessosApiError('Erro ao excluir processos', 500, 'DELETE_ERROR', error);
    }
  }

  validateProcessos(processos: IProcessos): { isValid: boolean; errors: string[] } {
    return ProcessosValidator.validateProcessos(processos);
  }
}