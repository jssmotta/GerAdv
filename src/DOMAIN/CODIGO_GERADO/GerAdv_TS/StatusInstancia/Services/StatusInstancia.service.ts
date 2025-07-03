'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { StatusInstanciaApi, StatusInstanciaApiError } from '../Apis/ApiStatusInstancia';
import { FilterStatusInstancia } from '../Filters/StatusInstancia';
import { IStatusInstancia } from '../Interfaces/interface.StatusInstancia';
import { StatusInstanciaEmpty } from '../../Models/StatusInstancia';

export class StatusInstanciaValidator {
  static validateStatusInstancia(statusinstancia: IStatusInstancia): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IStatusInstanciaService {
  fetchStatusInstanciaById: (id: number) => Promise<IStatusInstancia>;
  saveStatusInstancia: (statusinstancia: IStatusInstancia) => Promise<IStatusInstancia>;  
  getList: (filtro?: FilterStatusInstancia) => Promise<IStatusInstancia[]>;
  getAll: (filtro?: FilterStatusInstancia) => Promise<IStatusInstancia[]>;
  deleteStatusInstancia: (id: number) => Promise<void>;
  validateStatusInstancia: (statusinstancia: IStatusInstancia) => { isValid: boolean; errors: string[] };
}

export class StatusInstanciaService implements IStatusInstanciaService {
  constructor(private api: StatusInstanciaApi) {}

  async fetchStatusInstanciaById(id: number): Promise<IStatusInstancia> {
    if (id <= 0) {
      throw new StatusInstanciaApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof StatusInstanciaApiError) {
        throw error;
      }
      throw new StatusInstanciaApiError('Erro ao buscar statusinstancia', 500, 'FETCH_ERROR', error);
    }
  }

  async saveStatusInstancia(statusinstancia: IStatusInstancia): Promise<IStatusInstancia> {    
    const validation = this.validateStatusInstancia(statusinstancia);
    if (!validation.isValid) {
      throw new StatusInstanciaApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(statusinstancia);
      return response.data;
    } catch (error) {
      if (error instanceof StatusInstanciaApiError) {
        throw error;
      }
      throw new StatusInstanciaApiError('Erro ao salvar statusinstancia', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterStatusInstancia): Promise<IStatusInstancia[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching statusinstancia list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterStatusInstancia): Promise<IStatusInstancia[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all statusinstancia:', error);
      return [];
    }
  }

  async deleteStatusInstancia(id: number): Promise<void> {
    if (id <= 0) {
      throw new StatusInstanciaApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof StatusInstanciaApiError) {
        throw error;
      }
      throw new StatusInstanciaApiError('Erro ao excluir statusinstancia', 500, 'DELETE_ERROR', error);
    }
  }

  validateStatusInstancia(statusinstancia: IStatusInstancia): { isValid: boolean; errors: string[] } {
    return StatusInstanciaValidator.validateStatusInstancia(statusinstancia);
  }
}