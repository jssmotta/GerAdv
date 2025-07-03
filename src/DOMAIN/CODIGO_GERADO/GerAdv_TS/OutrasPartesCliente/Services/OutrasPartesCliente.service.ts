'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { OutrasPartesClienteApi, OutrasPartesClienteApiError } from '../Apis/ApiOutrasPartesCliente';
import { FilterOutrasPartesCliente } from '../Filters/OutrasPartesCliente';
import { IOutrasPartesCliente } from '../Interfaces/interface.OutrasPartesCliente';
import { OutrasPartesClienteEmpty } from '../../Models/OutrasPartesCliente';

export class OutrasPartesClienteValidator {
  static validateOutrasPartesCliente(outraspartescliente: IOutrasPartesCliente): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IOutrasPartesClienteService {
  fetchOutrasPartesClienteById: (id: number) => Promise<IOutrasPartesCliente>;
  saveOutrasPartesCliente: (outraspartescliente: IOutrasPartesCliente) => Promise<IOutrasPartesCliente>;  
  getList: (filtro?: FilterOutrasPartesCliente) => Promise<IOutrasPartesCliente[]>;
  getAll: (filtro?: FilterOutrasPartesCliente) => Promise<IOutrasPartesCliente[]>;
  deleteOutrasPartesCliente: (id: number) => Promise<void>;
  validateOutrasPartesCliente: (outraspartescliente: IOutrasPartesCliente) => { isValid: boolean; errors: string[] };
}

export class OutrasPartesClienteService implements IOutrasPartesClienteService {
  constructor(private api: OutrasPartesClienteApi) {}

  async fetchOutrasPartesClienteById(id: number): Promise<IOutrasPartesCliente> {
    if (id <= 0) {
      throw new OutrasPartesClienteApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof OutrasPartesClienteApiError) {
        throw error;
      }
      throw new OutrasPartesClienteApiError('Erro ao buscar outraspartescliente', 500, 'FETCH_ERROR', error);
    }
  }

  async saveOutrasPartesCliente(outraspartescliente: IOutrasPartesCliente): Promise<IOutrasPartesCliente> {    
    const validation = this.validateOutrasPartesCliente(outraspartescliente);
    if (!validation.isValid) {
      throw new OutrasPartesClienteApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(outraspartescliente);
      return response.data;
    } catch (error) {
      if (error instanceof OutrasPartesClienteApiError) {
        throw error;
      }
      throw new OutrasPartesClienteApiError('Erro ao salvar outraspartescliente', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterOutrasPartesCliente): Promise<IOutrasPartesCliente[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching outraspartescliente list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterOutrasPartesCliente): Promise<IOutrasPartesCliente[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all outraspartescliente:', error);
      return [];
    }
  }

  async deleteOutrasPartesCliente(id: number): Promise<void> {
    if (id <= 0) {
      throw new OutrasPartesClienteApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof OutrasPartesClienteApiError) {
        throw error;
      }
      throw new OutrasPartesClienteApiError('Erro ao excluir outraspartescliente', 500, 'DELETE_ERROR', error);
    }
  }

  validateOutrasPartesCliente(outraspartescliente: IOutrasPartesCliente): { isValid: boolean; errors: string[] } {
    return OutrasPartesClienteValidator.validateOutrasPartesCliente(outraspartescliente);
  }
}