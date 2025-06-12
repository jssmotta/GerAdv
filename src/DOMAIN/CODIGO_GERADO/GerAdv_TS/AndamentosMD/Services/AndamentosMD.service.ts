'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { AndamentosMDApi, AndamentosMDApiError } from '../Apis/ApiAndamentosMD';
import { FilterAndamentosMD } from '../Filters/AndamentosMD';
import { IAndamentosMD } from '../Interfaces/interface.AndamentosMD';

export class AndamentosMDValidator {
  static validateAndamentosMD(andamentosmd: IAndamentosMD): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IAndamentosMDService {
  fetchAndamentosMDById: (id: number) => Promise<IAndamentosMD>;
  saveAndamentosMD: (andamentosmd: IAndamentosMD) => Promise<IAndamentosMD>;  
  getList: (filtro?: FilterAndamentosMD) => Promise<IAndamentosMD[]>;
  getAll: (filtro?: FilterAndamentosMD) => Promise<IAndamentosMD[]>;
  deleteAndamentosMD: (id: number) => Promise<void>;
  validateAndamentosMD: (andamentosmd: IAndamentosMD) => { isValid: boolean; errors: string[] };
}

export class AndamentosMDService implements IAndamentosMDService {
  constructor(private api: AndamentosMDApi) {}

  async fetchAndamentosMDById(id: number): Promise<IAndamentosMD> {
    if (id <= 0) {
      throw new AndamentosMDApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof AndamentosMDApiError) {
        throw error;
      }
      throw new AndamentosMDApiError('Erro ao buscar andamentosmd', 500, 'FETCH_ERROR', error);
    }
  }

  async saveAndamentosMD(andamentosmd: IAndamentosMD): Promise<IAndamentosMD> {    
    const validation = this.validateAndamentosMD(andamentosmd);
    if (!validation.isValid) {
      throw new AndamentosMDApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(andamentosmd);
      return response.data;
    } catch (error) {
      if (error instanceof AndamentosMDApiError) {
        throw error;
      }
      throw new AndamentosMDApiError('Erro ao salvar andamentosmd', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterAndamentosMD): Promise<IAndamentosMD[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching andamentosmd list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterAndamentosMD): Promise<IAndamentosMD[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all andamentosmd:', error);
      return [];
    }
  }

  async deleteAndamentosMD(id: number): Promise<void> {
    if (id <= 0) {
      throw new AndamentosMDApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof AndamentosMDApiError) {
        throw error;
      }
      throw new AndamentosMDApiError('Erro ao excluir andamentosmd', 500, 'DELETE_ERROR', error);
    }
  }

  validateAndamentosMD(andamentosmd: IAndamentosMD): { isValid: boolean; errors: string[] } {
    return AndamentosMDValidator.validateAndamentosMD(andamentosmd);
  }
}