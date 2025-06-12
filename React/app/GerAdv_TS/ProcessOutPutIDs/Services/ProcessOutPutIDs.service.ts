'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ProcessOutPutIDsApi, ProcessOutPutIDsApiError } from '../Apis/ApiProcessOutPutIDs';
import { FilterProcessOutPutIDs } from '../Filters/ProcessOutPutIDs';
import { IProcessOutPutIDs } from '../Interfaces/interface.ProcessOutPutIDs';

export class ProcessOutPutIDsValidator {
  static validateProcessOutPutIDs(processoutputids: IProcessOutPutIDs): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IProcessOutPutIDsService {
  fetchProcessOutPutIDsById: (id: number) => Promise<IProcessOutPutIDs>;
  saveProcessOutPutIDs: (processoutputids: IProcessOutPutIDs) => Promise<IProcessOutPutIDs>;  
  getList: (filtro?: FilterProcessOutPutIDs) => Promise<IProcessOutPutIDs[]>;
  getAll: (filtro?: FilterProcessOutPutIDs) => Promise<IProcessOutPutIDs[]>;
  deleteProcessOutPutIDs: (id: number) => Promise<void>;
  validateProcessOutPutIDs: (processoutputids: IProcessOutPutIDs) => { isValid: boolean; errors: string[] };
}

export class ProcessOutPutIDsService implements IProcessOutPutIDsService {
  constructor(private api: ProcessOutPutIDsApi) {}

  async fetchProcessOutPutIDsById(id: number): Promise<IProcessOutPutIDs> {
    if (id <= 0) {
      throw new ProcessOutPutIDsApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof ProcessOutPutIDsApiError) {
        throw error;
      }
      throw new ProcessOutPutIDsApiError('Erro ao buscar processoutputids', 500, 'FETCH_ERROR', error);
    }
  }

  async saveProcessOutPutIDs(processoutputids: IProcessOutPutIDs): Promise<IProcessOutPutIDs> {    
    const validation = this.validateProcessOutPutIDs(processoutputids);
    if (!validation.isValid) {
      throw new ProcessOutPutIDsApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(processoutputids);
      return response.data;
    } catch (error) {
      if (error instanceof ProcessOutPutIDsApiError) {
        throw error;
      }
      throw new ProcessOutPutIDsApiError('Erro ao salvar processoutputids', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterProcessOutPutIDs): Promise<IProcessOutPutIDs[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching processoutputids list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterProcessOutPutIDs): Promise<IProcessOutPutIDs[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all processoutputids:', error);
      return [];
    }
  }

  async deleteProcessOutPutIDs(id: number): Promise<void> {
    if (id <= 0) {
      throw new ProcessOutPutIDsApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ProcessOutPutIDsApiError) {
        throw error;
      }
      throw new ProcessOutPutIDsApiError('Erro ao excluir processoutputids', 500, 'DELETE_ERROR', error);
    }
  }

  validateProcessOutPutIDs(processoutputids: IProcessOutPutIDs): { isValid: boolean; errors: string[] } {
    return ProcessOutPutIDsValidator.validateProcessOutPutIDs(processoutputids);
  }
}