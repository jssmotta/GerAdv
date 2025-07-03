'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { RamalApi, RamalApiError } from '../Apis/ApiRamal';
import { FilterRamal } from '../Filters/Ramal';
import { IRamal } from '../Interfaces/interface.Ramal';
import { RamalEmpty } from '../../Models/Ramal';

export class RamalValidator {
  static validateRamal(ramal: IRamal): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IRamalService {
  fetchRamalById: (id: number) => Promise<IRamal>;
  saveRamal: (ramal: IRamal) => Promise<IRamal>;  
  getList: (filtro?: FilterRamal) => Promise<IRamal[]>;
  getAll: (filtro?: FilterRamal) => Promise<IRamal[]>;
  deleteRamal: (id: number) => Promise<void>;
  validateRamal: (ramal: IRamal) => { isValid: boolean; errors: string[] };
}

export class RamalService implements IRamalService {
  constructor(private api: RamalApi) {}

  async fetchRamalById(id: number): Promise<IRamal> {
    if (id <= 0) {
      throw new RamalApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof RamalApiError) {
        throw error;
      }
      throw new RamalApiError('Erro ao buscar ramal', 500, 'FETCH_ERROR', error);
    }
  }

  async saveRamal(ramal: IRamal): Promise<IRamal> {    
    const validation = this.validateRamal(ramal);
    if (!validation.isValid) {
      throw new RamalApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(ramal);
      return response.data;
    } catch (error) {
      if (error instanceof RamalApiError) {
        throw error;
      }
      throw new RamalApiError('Erro ao salvar ramal', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterRamal): Promise<IRamal[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching ramal list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterRamal): Promise<IRamal[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all ramal:', error);
      return [];
    }
  }

  async deleteRamal(id: number): Promise<void> {
    if (id <= 0) {
      throw new RamalApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof RamalApiError) {
        throw error;
      }
      throw new RamalApiError('Erro ao excluir ramal', 500, 'DELETE_ERROR', error);
    }
  }

  validateRamal(ramal: IRamal): { isValid: boolean; errors: string[] } {
    return RamalValidator.validateRamal(ramal);
  }
}