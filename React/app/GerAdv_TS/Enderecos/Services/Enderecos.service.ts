'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { EnderecosApi, EnderecosApiError } from '../Apis/ApiEnderecos';
import { FilterEnderecos } from '../Filters/Enderecos';
import { IEnderecos } from '../Interfaces/interface.Enderecos';
import { EnderecosEmpty } from '../../Models/Enderecos';

export class EnderecosValidator {
  static validateEnderecos(enderecos: IEnderecos): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IEnderecosService {
  fetchEnderecosById: (id: number) => Promise<IEnderecos>;
  saveEnderecos: (enderecos: IEnderecos) => Promise<IEnderecos>;  
  getList: (filtro?: FilterEnderecos) => Promise<IEnderecos[]>;
  getAll: (filtro?: FilterEnderecos) => Promise<IEnderecos[]>;
  deleteEnderecos: (id: number) => Promise<void>;
  validateEnderecos: (enderecos: IEnderecos) => { isValid: boolean; errors: string[] };
}

export class EnderecosService implements IEnderecosService {
  constructor(private api: EnderecosApi) {}

  async fetchEnderecosById(id: number): Promise<IEnderecos> {
    if (id <= 0) {
      throw new EnderecosApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof EnderecosApiError) {
        throw error;
      }
      throw new EnderecosApiError('Erro ao buscar enderecos', 500, 'FETCH_ERROR', error);
    }
  }

  async saveEnderecos(enderecos: IEnderecos): Promise<IEnderecos> {    
    const validation = this.validateEnderecos(enderecos);
    if (!validation.isValid) {
      throw new EnderecosApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(enderecos);
      return response.data;
    } catch (error) {
      if (error instanceof EnderecosApiError) {
        throw error;
      }
      throw new EnderecosApiError('Erro ao salvar enderecos', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterEnderecos): Promise<IEnderecos[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching enderecos list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterEnderecos): Promise<IEnderecos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all enderecos:', error);
      return [];
    }
  }

  async deleteEnderecos(id: number): Promise<void> {
    if (id <= 0) {
      throw new EnderecosApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof EnderecosApiError) {
        throw error;
      }
      throw new EnderecosApiError('Erro ao excluir enderecos', 500, 'DELETE_ERROR', error);
    }
  }

  validateEnderecos(enderecos: IEnderecos): { isValid: boolean; errors: string[] } {
    return EnderecosValidator.validateEnderecos(enderecos);
  }
}