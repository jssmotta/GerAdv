'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ProPartesApi, ProPartesApiError } from '../Apis/ApiProPartes';
import { FilterProPartes } from '../Filters/ProPartes';
import { IProPartes } from '../Interfaces/interface.ProPartes';
import { ProPartesEmpty } from '../../Models/ProPartes';

export class ProPartesValidator {
  static validateProPartes(propartes: IProPartes): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IProPartesService {
  fetchProPartesById: (id: number) => Promise<IProPartes>;
  saveProPartes: (propartes: IProPartes) => Promise<IProPartes>;  
  
  getAll: (filtro?: FilterProPartes) => Promise<IProPartes[]>;
  deleteProPartes: (id: number) => Promise<void>;
  validateProPartes: (propartes: IProPartes) => { isValid: boolean; errors: string[] };
}

export class ProPartesService implements IProPartesService {
  constructor(private api: ProPartesApi) {}

  async fetchProPartesById(id: number): Promise<IProPartes> {
    if (id <= 0) {
      throw new ProPartesApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof ProPartesApiError) {
        throw error;
      }
      throw new ProPartesApiError('Erro ao buscar propartes', 500, 'FETCH_ERROR', error);
    }
  }

  async saveProPartes(propartes: IProPartes): Promise<IProPartes> {    
    const validation = this.validateProPartes(propartes);
    if (!validation.isValid) {
      throw new ProPartesApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(propartes);
      return response.data;
    } catch (error) {
      if (error instanceof ProPartesApiError) {
        throw error;
      }
      throw new ProPartesApiError('Erro ao salvar propartes', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterProPartes): Promise<IProPartes[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all propartes:', error);
      return [];
    }
  }

  async deleteProPartes(id: number): Promise<void> {
    if (id <= 0) {
      throw new ProPartesApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ProPartesApiError) {
        throw error;
      }
      throw new ProPartesApiError('Erro ao excluir propartes', 500, 'DELETE_ERROR', error);
    }
  }

  validateProPartes(propartes: IProPartes): { isValid: boolean; errors: string[] } {
    return ProPartesValidator.validateProPartes(propartes);
  }
}