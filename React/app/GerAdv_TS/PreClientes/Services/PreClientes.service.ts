'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { PreClientesApi, PreClientesApiError } from '../Apis/ApiPreClientes';
import { FilterPreClientes } from '../Filters/PreClientes';
import { IPreClientes } from '../Interfaces/interface.PreClientes';

export class PreClientesValidator {
  static validatePreClientes(preclientes: IPreClientes): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IPreClientesService {
  fetchPreClientesById: (id: number) => Promise<IPreClientes>;
  savePreClientes: (preclientes: IPreClientes) => Promise<IPreClientes>;  
  getList: (filtro?: FilterPreClientes) => Promise<IPreClientes[]>;
  getAll: (filtro?: FilterPreClientes) => Promise<IPreClientes[]>;
  deletePreClientes: (id: number) => Promise<void>;
  validatePreClientes: (preclientes: IPreClientes) => { isValid: boolean; errors: string[] };
}

export class PreClientesService implements IPreClientesService {
  constructor(private api: PreClientesApi) {}

  async fetchPreClientesById(id: number): Promise<IPreClientes> {
    if (id <= 0) {
      throw new PreClientesApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof PreClientesApiError) {
        throw error;
      }
      throw new PreClientesApiError('Erro ao buscar preclientes', 500, 'FETCH_ERROR', error);
    }
  }

  async savePreClientes(preclientes: IPreClientes): Promise<IPreClientes> {    
    const validation = this.validatePreClientes(preclientes);
    if (!validation.isValid) {
      throw new PreClientesApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(preclientes);
      return response.data;
    } catch (error) {
      if (error instanceof PreClientesApiError) {
        throw error;
      }
      throw new PreClientesApiError('Erro ao salvar preclientes', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterPreClientes): Promise<IPreClientes[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching preclientes list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterPreClientes): Promise<IPreClientes[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all preclientes:', error);
      return [];
    }
  }

  async deletePreClientes(id: number): Promise<void> {
    if (id <= 0) {
      throw new PreClientesApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof PreClientesApiError) {
        throw error;
      }
      throw new PreClientesApiError('Erro ao excluir preclientes', 500, 'DELETE_ERROR', error);
    }
  }

  validatePreClientes(preclientes: IPreClientes): { isValid: boolean; errors: string[] } {
    return PreClientesValidator.validatePreClientes(preclientes);
  }
}