'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { FuncionariosApi, FuncionariosApiError } from '../Apis/ApiFuncionarios';
import { FilterFuncionarios } from '../Filters/Funcionarios';
import { IFuncionarios } from '../Interfaces/interface.Funcionarios';

export class FuncionariosValidator {
  static validateFuncionarios(funcionarios: IFuncionarios): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IFuncionariosService {
  fetchFuncionariosById: (id: number) => Promise<IFuncionarios>;
  saveFuncionarios: (funcionarios: IFuncionarios) => Promise<IFuncionarios>;  
  getList: (filtro?: FilterFuncionarios) => Promise<IFuncionarios[]>;
  getAll: (filtro?: FilterFuncionarios) => Promise<IFuncionarios[]>;
  deleteFuncionarios: (id: number) => Promise<void>;
  validateFuncionarios: (funcionarios: IFuncionarios) => { isValid: boolean; errors: string[] };
}

export class FuncionariosService implements IFuncionariosService {
  constructor(private api: FuncionariosApi) {}

  async fetchFuncionariosById(id: number): Promise<IFuncionarios> {
    if (id <= 0) {
      throw new FuncionariosApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof FuncionariosApiError) {
        throw error;
      }
      throw new FuncionariosApiError('Erro ao buscar funcionarios', 500, 'FETCH_ERROR', error);
    }
  }

  async saveFuncionarios(funcionarios: IFuncionarios): Promise<IFuncionarios> {    
    const validation = this.validateFuncionarios(funcionarios);
    if (!validation.isValid) {
      throw new FuncionariosApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(funcionarios);
      return response.data;
    } catch (error) {
      if (error instanceof FuncionariosApiError) {
        throw error;
      }
      throw new FuncionariosApiError('Erro ao salvar funcionarios', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterFuncionarios): Promise<IFuncionarios[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching funcionarios list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterFuncionarios): Promise<IFuncionarios[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all funcionarios:', error);
      return [];
    }
  }

  async deleteFuncionarios(id: number): Promise<void> {
    if (id <= 0) {
      throw new FuncionariosApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof FuncionariosApiError) {
        throw error;
      }
      throw new FuncionariosApiError('Erro ao excluir funcionarios', 500, 'DELETE_ERROR', error);
    }
  }

  validateFuncionarios(funcionarios: IFuncionarios): { isValid: boolean; errors: string[] } {
    return FuncionariosValidator.validateFuncionarios(funcionarios);
  }
}