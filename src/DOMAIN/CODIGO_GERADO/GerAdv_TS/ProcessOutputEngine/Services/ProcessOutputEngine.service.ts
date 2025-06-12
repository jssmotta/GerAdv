'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ProcessOutputEngineApi, ProcessOutputEngineApiError } from '../Apis/ApiProcessOutputEngine';
import { FilterProcessOutputEngine } from '../Filters/ProcessOutputEngine';
import { IProcessOutputEngine } from '../Interfaces/interface.ProcessOutputEngine';

export class ProcessOutputEngineValidator {
  static validateProcessOutputEngine(processoutputengine: IProcessOutputEngine): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IProcessOutputEngineService {
  fetchProcessOutputEngineById: (id: number) => Promise<IProcessOutputEngine>;
  saveProcessOutputEngine: (processoutputengine: IProcessOutputEngine) => Promise<IProcessOutputEngine>;  
  getList: (filtro?: FilterProcessOutputEngine) => Promise<IProcessOutputEngine[]>;
  getAll: (filtro?: FilterProcessOutputEngine) => Promise<IProcessOutputEngine[]>;
  deleteProcessOutputEngine: (id: number) => Promise<void>;
  validateProcessOutputEngine: (processoutputengine: IProcessOutputEngine) => { isValid: boolean; errors: string[] };
}

export class ProcessOutputEngineService implements IProcessOutputEngineService {
  constructor(private api: ProcessOutputEngineApi) {}

  async fetchProcessOutputEngineById(id: number): Promise<IProcessOutputEngine> {
    if (id <= 0) {
      throw new ProcessOutputEngineApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof ProcessOutputEngineApiError) {
        throw error;
      }
      throw new ProcessOutputEngineApiError('Erro ao buscar processoutputengine', 500, 'FETCH_ERROR', error);
    }
  }

  async saveProcessOutputEngine(processoutputengine: IProcessOutputEngine): Promise<IProcessOutputEngine> {    
    const validation = this.validateProcessOutputEngine(processoutputengine);
    if (!validation.isValid) {
      throw new ProcessOutputEngineApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(processoutputengine);
      return response.data;
    } catch (error) {
      if (error instanceof ProcessOutputEngineApiError) {
        throw error;
      }
      throw new ProcessOutputEngineApiError('Erro ao salvar processoutputengine', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterProcessOutputEngine): Promise<IProcessOutputEngine[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching processoutputengine list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterProcessOutputEngine): Promise<IProcessOutputEngine[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all processoutputengine:', error);
      return [];
    }
  }

  async deleteProcessOutputEngine(id: number): Promise<void> {
    if (id <= 0) {
      throw new ProcessOutputEngineApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ProcessOutputEngineApiError) {
        throw error;
      }
      throw new ProcessOutputEngineApiError('Erro ao excluir processoutputengine', 500, 'DELETE_ERROR', error);
    }
  }

  validateProcessOutputEngine(processoutputengine: IProcessOutputEngine): { isValid: boolean; errors: string[] } {
    return ProcessOutputEngineValidator.validateProcessOutputEngine(processoutputengine);
  }
}