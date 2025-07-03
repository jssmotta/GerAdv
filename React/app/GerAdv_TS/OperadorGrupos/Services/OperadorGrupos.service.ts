'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { OperadorGruposApi, OperadorGruposApiError } from '../Apis/ApiOperadorGrupos';
import { FilterOperadorGrupos } from '../Filters/OperadorGrupos';
import { IOperadorGrupos } from '../Interfaces/interface.OperadorGrupos';
import { OperadorGruposEmpty } from '../../Models/OperadorGrupos';

export class OperadorGruposValidator {
  static validateOperadorGrupos(operadorgrupos: IOperadorGrupos): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IOperadorGruposService {
  fetchOperadorGruposById: (id: number) => Promise<IOperadorGrupos>;
  saveOperadorGrupos: (operadorgrupos: IOperadorGrupos) => Promise<IOperadorGrupos>;  
  getList: (filtro?: FilterOperadorGrupos) => Promise<IOperadorGrupos[]>;
  getAll: (filtro?: FilterOperadorGrupos) => Promise<IOperadorGrupos[]>;
  deleteOperadorGrupos: (id: number) => Promise<void>;
  validateOperadorGrupos: (operadorgrupos: IOperadorGrupos) => { isValid: boolean; errors: string[] };
}

export class OperadorGruposService implements IOperadorGruposService {
  constructor(private api: OperadorGruposApi) {}

  async fetchOperadorGruposById(id: number): Promise<IOperadorGrupos> {
    if (id <= 0) {
      throw new OperadorGruposApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof OperadorGruposApiError) {
        throw error;
      }
      throw new OperadorGruposApiError('Erro ao buscar operadorgrupos', 500, 'FETCH_ERROR', error);
    }
  }

  async saveOperadorGrupos(operadorgrupos: IOperadorGrupos): Promise<IOperadorGrupos> {    
    const validation = this.validateOperadorGrupos(operadorgrupos);
    if (!validation.isValid) {
      throw new OperadorGruposApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(operadorgrupos);
      return response.data;
    } catch (error) {
      if (error instanceof OperadorGruposApiError) {
        throw error;
      }
      throw new OperadorGruposApiError('Erro ao salvar operadorgrupos', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterOperadorGrupos): Promise<IOperadorGrupos[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching operadorgrupos list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterOperadorGrupos): Promise<IOperadorGrupos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all operadorgrupos:', error);
      return [];
    }
  }

  async deleteOperadorGrupos(id: number): Promise<void> {
    if (id <= 0) {
      throw new OperadorGruposApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof OperadorGruposApiError) {
        throw error;
      }
      throw new OperadorGruposApiError('Erro ao excluir operadorgrupos', 500, 'DELETE_ERROR', error);
    }
  }

  validateOperadorGrupos(operadorgrupos: IOperadorGrupos): { isValid: boolean; errors: string[] } {
    return OperadorGruposValidator.validateOperadorGrupos(operadorgrupos);
  }
}