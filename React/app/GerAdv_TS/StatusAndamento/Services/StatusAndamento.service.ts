'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { StatusAndamentoApi, StatusAndamentoApiError } from '../Apis/ApiStatusAndamento';
import { FilterStatusAndamento } from '../Filters/StatusAndamento';
import { IStatusAndamento } from '../Interfaces/interface.StatusAndamento';

export class StatusAndamentoValidator {
  static validateStatusAndamento(statusandamento: IStatusAndamento): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IStatusAndamentoService {
  fetchStatusAndamentoById: (id: number) => Promise<IStatusAndamento>;
  saveStatusAndamento: (statusandamento: IStatusAndamento) => Promise<IStatusAndamento>;  
  getList: (filtro?: FilterStatusAndamento) => Promise<IStatusAndamento[]>;
  getAll: (filtro?: FilterStatusAndamento) => Promise<IStatusAndamento[]>;
  deleteStatusAndamento: (id: number) => Promise<void>;
  validateStatusAndamento: (statusandamento: IStatusAndamento) => { isValid: boolean; errors: string[] };
}

export class StatusAndamentoService implements IStatusAndamentoService {
  constructor(private api: StatusAndamentoApi) {}

  async fetchStatusAndamentoById(id: number): Promise<IStatusAndamento> {
    if (id <= 0) {
      throw new StatusAndamentoApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof StatusAndamentoApiError) {
        throw error;
      }
      throw new StatusAndamentoApiError('Erro ao buscar statusandamento', 500, 'FETCH_ERROR', error);
    }
  }

  async saveStatusAndamento(statusandamento: IStatusAndamento): Promise<IStatusAndamento> {    
    const validation = this.validateStatusAndamento(statusandamento);
    if (!validation.isValid) {
      throw new StatusAndamentoApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(statusandamento);
      return response.data;
    } catch (error) {
      if (error instanceof StatusAndamentoApiError) {
        throw error;
      }
      throw new StatusAndamentoApiError('Erro ao salvar statusandamento', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterStatusAndamento): Promise<IStatusAndamento[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching statusandamento list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterStatusAndamento): Promise<IStatusAndamento[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all statusandamento:', error);
      return [];
    }
  }

  async deleteStatusAndamento(id: number): Promise<void> {
    if (id <= 0) {
      throw new StatusAndamentoApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof StatusAndamentoApiError) {
        throw error;
      }
      throw new StatusAndamentoApiError('Erro ao excluir statusandamento', 500, 'DELETE_ERROR', error);
    }
  }

  validateStatusAndamento(statusandamento: IStatusAndamento): { isValid: boolean; errors: string[] } {
    return StatusAndamentoValidator.validateStatusAndamento(statusandamento);
  }
}