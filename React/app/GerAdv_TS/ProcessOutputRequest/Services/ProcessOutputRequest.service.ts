'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ProcessOutputRequestApi, ProcessOutputRequestApiError } from '../Apis/ApiProcessOutputRequest';
import { FilterProcessOutputRequest } from '../Filters/ProcessOutputRequest';
import { IProcessOutputRequest } from '../Interfaces/interface.ProcessOutputRequest';
import { ProcessOutputRequestEmpty } from '../../Models/ProcessOutputRequest';

export class ProcessOutputRequestValidator {
  static validateProcessOutputRequest(processoutputrequest: IProcessOutputRequest): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IProcessOutputRequestService {
  fetchProcessOutputRequestById: (id: number) => Promise<IProcessOutputRequest>;
  saveProcessOutputRequest: (processoutputrequest: IProcessOutputRequest) => Promise<IProcessOutputRequest>;  
  
  getAll: (filtro?: FilterProcessOutputRequest) => Promise<IProcessOutputRequest[]>;
  deleteProcessOutputRequest: (id: number) => Promise<void>;
  validateProcessOutputRequest: (processoutputrequest: IProcessOutputRequest) => { isValid: boolean; errors: string[] };
}

export class ProcessOutputRequestService implements IProcessOutputRequestService {
  constructor(private api: ProcessOutputRequestApi) {}

  async fetchProcessOutputRequestById(id: number): Promise<IProcessOutputRequest> {
    if (id <= 0) {
      throw new ProcessOutputRequestApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof ProcessOutputRequestApiError) {
        throw error;
      }
      throw new ProcessOutputRequestApiError('Erro ao buscar processoutputrequest', 500, 'FETCH_ERROR', error);
    }
  }

  async saveProcessOutputRequest(processoutputrequest: IProcessOutputRequest): Promise<IProcessOutputRequest> {    
    const validation = this.validateProcessOutputRequest(processoutputrequest);
    if (!validation.isValid) {
      throw new ProcessOutputRequestApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(processoutputrequest);
      return response.data;
    } catch (error) {
      if (error instanceof ProcessOutputRequestApiError) {
        throw error;
      }
      throw new ProcessOutputRequestApiError('Erro ao salvar processoutputrequest', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterProcessOutputRequest): Promise<IProcessOutputRequest[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all processoutputrequest:', error);
      return [];
    }
  }

  async deleteProcessOutputRequest(id: number): Promise<void> {
    if (id <= 0) {
      throw new ProcessOutputRequestApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ProcessOutputRequestApiError) {
        throw error;
      }
      throw new ProcessOutputRequestApiError('Erro ao excluir processoutputrequest', 500, 'DELETE_ERROR', error);
    }
  }

  validateProcessOutputRequest(processoutputrequest: IProcessOutputRequest): { isValid: boolean; errors: string[] } {
    return ProcessOutputRequestValidator.validateProcessOutputRequest(processoutputrequest);
  }
}