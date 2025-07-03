'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { NENotasApi, NENotasApiError } from '../Apis/ApiNENotas';
import { FilterNENotas } from '../Filters/NENotas';
import { INENotas } from '../Interfaces/interface.NENotas';
import { NENotasEmpty } from '../../Models/NENotas';

export class NENotasValidator {
  static validateNENotas(nenotas: INENotas): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface INENotasService {
  fetchNENotasById: (id: number) => Promise<INENotas>;
  saveNENotas: (nenotas: INENotas) => Promise<INENotas>;  
  getList: (filtro?: FilterNENotas) => Promise<INENotas[]>;
  getAll: (filtro?: FilterNENotas) => Promise<INENotas[]>;
  deleteNENotas: (id: number) => Promise<void>;
  validateNENotas: (nenotas: INENotas) => { isValid: boolean; errors: string[] };
}

export class NENotasService implements INENotasService {
  constructor(private api: NENotasApi) {}

  async fetchNENotasById(id: number): Promise<INENotas> {
    if (id <= 0) {
      throw new NENotasApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof NENotasApiError) {
        throw error;
      }
      throw new NENotasApiError('Erro ao buscar nenotas', 500, 'FETCH_ERROR', error);
    }
  }

  async saveNENotas(nenotas: INENotas): Promise<INENotas> {    
    const validation = this.validateNENotas(nenotas);
    if (!validation.isValid) {
      throw new NENotasApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(nenotas);
      return response.data;
    } catch (error) {
      if (error instanceof NENotasApiError) {
        throw error;
      }
      throw new NENotasApiError('Erro ao salvar nenotas', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterNENotas): Promise<INENotas[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching nenotas list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterNENotas): Promise<INENotas[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all nenotas:', error);
      return [];
    }
  }

  async deleteNENotas(id: number): Promise<void> {
    if (id <= 0) {
      throw new NENotasApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof NENotasApiError) {
        throw error;
      }
      throw new NENotasApiError('Erro ao excluir nenotas', 500, 'DELETE_ERROR', error);
    }
  }

  validateNENotas(nenotas: INENotas): { isValid: boolean; errors: string[] } {
    return NENotasValidator.validateNENotas(nenotas);
  }
}