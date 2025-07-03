'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { RitoApi, RitoApiError } from '../Apis/ApiRito';
import { FilterRito } from '../Filters/Rito';
import { IRito } from '../Interfaces/interface.Rito';
import { RitoEmpty } from '../../Models/Rito';

export class RitoValidator {
  static validateRito(rito: IRito): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IRitoService {
  fetchRitoById: (id: number) => Promise<IRito>;
  saveRito: (rito: IRito) => Promise<IRito>;  
  getList: (filtro?: FilterRito) => Promise<IRito[]>;
  getAll: (filtro?: FilterRito) => Promise<IRito[]>;
  deleteRito: (id: number) => Promise<void>;
  validateRito: (rito: IRito) => { isValid: boolean; errors: string[] };
}

export class RitoService implements IRitoService {
  constructor(private api: RitoApi) {}

  async fetchRitoById(id: number): Promise<IRito> {
    if (id <= 0) {
      throw new RitoApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof RitoApiError) {
        throw error;
      }
      throw new RitoApiError('Erro ao buscar rito', 500, 'FETCH_ERROR', error);
    }
  }

  async saveRito(rito: IRito): Promise<IRito> {    
    const validation = this.validateRito(rito);
    if (!validation.isValid) {
      throw new RitoApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(rito);
      return response.data;
    } catch (error) {
      if (error instanceof RitoApiError) {
        throw error;
      }
      throw new RitoApiError('Erro ao salvar rito', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterRito): Promise<IRito[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching rito list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterRito): Promise<IRito[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all rito:', error);
      return [];
    }
  }

  async deleteRito(id: number): Promise<void> {
    if (id <= 0) {
      throw new RitoApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof RitoApiError) {
        throw error;
      }
      throw new RitoApiError('Erro ao excluir rito', 500, 'DELETE_ERROR', error);
    }
  }

  validateRito(rito: IRito): { isValid: boolean; errors: string[] } {
    return RitoValidator.validateRito(rito);
  }
}