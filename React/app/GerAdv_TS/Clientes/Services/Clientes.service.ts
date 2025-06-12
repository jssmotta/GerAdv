'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ClientesApi, ClientesApiError } from '../Apis/ApiClientes';
import { FilterClientes } from '../Filters/Clientes';
import { IClientes } from '../Interfaces/interface.Clientes';

export class ClientesValidator {
  static validateClientes(clientes: IClientes): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IClientesService {
  fetchClientesById: (id: number) => Promise<IClientes>;
  saveClientes: (clientes: IClientes) => Promise<IClientes>;  
  getList: (filtro?: FilterClientes) => Promise<IClientes[]>;
  getAll: (filtro?: FilterClientes) => Promise<IClientes[]>;
  deleteClientes: (id: number) => Promise<void>;
  validateClientes: (clientes: IClientes) => { isValid: boolean; errors: string[] };
}

export class ClientesService implements IClientesService {
  constructor(private api: ClientesApi) {}

  async fetchClientesById(id: number): Promise<IClientes> {
    if (id <= 0) {
      throw new ClientesApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof ClientesApiError) {
        throw error;
      }
      throw new ClientesApiError('Erro ao buscar clientes', 500, 'FETCH_ERROR', error);
    }
  }

  async saveClientes(clientes: IClientes): Promise<IClientes> {    
    const validation = this.validateClientes(clientes);
    if (!validation.isValid) {
      throw new ClientesApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(clientes);
      return response.data;
    } catch (error) {
      if (error instanceof ClientesApiError) {
        throw error;
      }
      throw new ClientesApiError('Erro ao salvar clientes', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterClientes): Promise<IClientes[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching clientes list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterClientes): Promise<IClientes[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all clientes:', error);
      return [];
    }
  }

  async deleteClientes(id: number): Promise<void> {
    if (id <= 0) {
      throw new ClientesApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ClientesApiError) {
        throw error;
      }
      throw new ClientesApiError('Erro ao excluir clientes', 500, 'DELETE_ERROR', error);
    }
  }

  validateClientes(clientes: IClientes): { isValid: boolean; errors: string[] } {
    return ClientesValidator.validateClientes(clientes);
  }
}