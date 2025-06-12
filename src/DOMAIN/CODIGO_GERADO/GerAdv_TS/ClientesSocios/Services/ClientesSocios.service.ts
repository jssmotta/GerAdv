'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ClientesSociosApi, ClientesSociosApiError } from '../Apis/ApiClientesSocios';
import { FilterClientesSocios } from '../Filters/ClientesSocios';
import { IClientesSocios } from '../Interfaces/interface.ClientesSocios';

export class ClientesSociosValidator {
  static validateClientesSocios(clientessocios: IClientesSocios): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IClientesSociosService {
  fetchClientesSociosById: (id: number) => Promise<IClientesSocios>;
  saveClientesSocios: (clientessocios: IClientesSocios) => Promise<IClientesSocios>;  
  getList: (filtro?: FilterClientesSocios) => Promise<IClientesSocios[]>;
  getAll: (filtro?: FilterClientesSocios) => Promise<IClientesSocios[]>;
  deleteClientesSocios: (id: number) => Promise<void>;
  validateClientesSocios: (clientessocios: IClientesSocios) => { isValid: boolean; errors: string[] };
}

export class ClientesSociosService implements IClientesSociosService {
  constructor(private api: ClientesSociosApi) {}

  async fetchClientesSociosById(id: number): Promise<IClientesSocios> {
    if (id <= 0) {
      throw new ClientesSociosApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof ClientesSociosApiError) {
        throw error;
      }
      throw new ClientesSociosApiError('Erro ao buscar clientessocios', 500, 'FETCH_ERROR', error);
    }
  }

  async saveClientesSocios(clientessocios: IClientesSocios): Promise<IClientesSocios> {    
    const validation = this.validateClientesSocios(clientessocios);
    if (!validation.isValid) {
      throw new ClientesSociosApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(clientessocios);
      return response.data;
    } catch (error) {
      if (error instanceof ClientesSociosApiError) {
        throw error;
      }
      throw new ClientesSociosApiError('Erro ao salvar clientessocios', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterClientesSocios): Promise<IClientesSocios[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching clientessocios list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterClientesSocios): Promise<IClientesSocios[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all clientessocios:', error);
      return [];
    }
  }

  async deleteClientesSocios(id: number): Promise<void> {
    if (id <= 0) {
      throw new ClientesSociosApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ClientesSociosApiError) {
        throw error;
      }
      throw new ClientesSociosApiError('Erro ao excluir clientessocios', 500, 'DELETE_ERROR', error);
    }
  }

  validateClientesSocios(clientessocios: IClientesSocios): { isValid: boolean; errors: string[] } {
    return ClientesSociosValidator.validateClientesSocios(clientessocios);
  }
}