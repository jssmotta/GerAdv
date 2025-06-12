'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ProcessOutputSourcesApi, ProcessOutputSourcesApiError } from '../Apis/ApiProcessOutputSources';
import { FilterProcessOutputSources } from '../Filters/ProcessOutputSources';
import { IProcessOutputSources } from '../Interfaces/interface.ProcessOutputSources';

export class ProcessOutputSourcesValidator {
  static validateProcessOutputSources(processoutputsources: IProcessOutputSources): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IProcessOutputSourcesService {
  fetchProcessOutputSourcesById: (id: number) => Promise<IProcessOutputSources>;
  saveProcessOutputSources: (processoutputsources: IProcessOutputSources) => Promise<IProcessOutputSources>;  
  getList: (filtro?: FilterProcessOutputSources) => Promise<IProcessOutputSources[]>;
  getAll: (filtro?: FilterProcessOutputSources) => Promise<IProcessOutputSources[]>;
  deleteProcessOutputSources: (id: number) => Promise<void>;
  validateProcessOutputSources: (processoutputsources: IProcessOutputSources) => { isValid: boolean; errors: string[] };
}

export class ProcessOutputSourcesService implements IProcessOutputSourcesService {
  constructor(private api: ProcessOutputSourcesApi) {}

  async fetchProcessOutputSourcesById(id: number): Promise<IProcessOutputSources> {
    if (id <= 0) {
      throw new ProcessOutputSourcesApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof ProcessOutputSourcesApiError) {
        throw error;
      }
      throw new ProcessOutputSourcesApiError('Erro ao buscar processoutputsources', 500, 'FETCH_ERROR', error);
    }
  }

  async saveProcessOutputSources(processoutputsources: IProcessOutputSources): Promise<IProcessOutputSources> {    
    const validation = this.validateProcessOutputSources(processoutputsources);
    if (!validation.isValid) {
      throw new ProcessOutputSourcesApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(processoutputsources);
      return response.data;
    } catch (error) {
      if (error instanceof ProcessOutputSourcesApiError) {
        throw error;
      }
      throw new ProcessOutputSourcesApiError('Erro ao salvar processoutputsources', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterProcessOutputSources): Promise<IProcessOutputSources[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching processoutputsources list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterProcessOutputSources): Promise<IProcessOutputSources[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all processoutputsources:', error);
      return [];
    }
  }

  async deleteProcessOutputSources(id: number): Promise<void> {
    if (id <= 0) {
      throw new ProcessOutputSourcesApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ProcessOutputSourcesApiError) {
        throw error;
      }
      throw new ProcessOutputSourcesApiError('Erro ao excluir processoutputsources', 500, 'DELETE_ERROR', error);
    }
  }

  validateProcessOutputSources(processoutputsources: IProcessOutputSources): { isValid: boolean; errors: string[] } {
    return ProcessOutputSourcesValidator.validateProcessOutputSources(processoutputsources);
  }
}