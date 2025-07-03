'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { GUTTipoApi, GUTTipoApiError } from '../Apis/ApiGUTTipo';
import { FilterGUTTipo } from '../Filters/GUTTipo';
import { IGUTTipo } from '../Interfaces/interface.GUTTipo';
import { GUTTipoEmpty } from '../../Models/GUTTipo';

export class GUTTipoValidator {
  static validateGUTTipo(guttipo: IGUTTipo): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IGUTTipoService {
  fetchGUTTipoById: (id: number) => Promise<IGUTTipo>;
  saveGUTTipo: (guttipo: IGUTTipo) => Promise<IGUTTipo>;  
  getList: (filtro?: FilterGUTTipo) => Promise<IGUTTipo[]>;
  getAll: (filtro?: FilterGUTTipo) => Promise<IGUTTipo[]>;
  deleteGUTTipo: (id: number) => Promise<void>;
  validateGUTTipo: (guttipo: IGUTTipo) => { isValid: boolean; errors: string[] };
}

export class GUTTipoService implements IGUTTipoService {
  constructor(private api: GUTTipoApi) {}

  async fetchGUTTipoById(id: number): Promise<IGUTTipo> {
    if (id <= 0) {
      throw new GUTTipoApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof GUTTipoApiError) {
        throw error;
      }
      throw new GUTTipoApiError('Erro ao buscar guttipo', 500, 'FETCH_ERROR', error);
    }
  }

  async saveGUTTipo(guttipo: IGUTTipo): Promise<IGUTTipo> {    
    const validation = this.validateGUTTipo(guttipo);
    if (!validation.isValid) {
      throw new GUTTipoApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(guttipo);
      return response.data;
    } catch (error) {
      if (error instanceof GUTTipoApiError) {
        throw error;
      }
      throw new GUTTipoApiError('Erro ao salvar guttipo', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterGUTTipo): Promise<IGUTTipo[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching guttipo list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterGUTTipo): Promise<IGUTTipo[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all guttipo:', error);
      return [];
    }
  }

  async deleteGUTTipo(id: number): Promise<void> {
    if (id <= 0) {
      throw new GUTTipoApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof GUTTipoApiError) {
        throw error;
      }
      throw new GUTTipoApiError('Erro ao excluir guttipo', 500, 'DELETE_ERROR', error);
    }
  }

  validateGUTTipo(guttipo: IGUTTipo): { isValid: boolean; errors: string[] } {
    return GUTTipoValidator.validateGUTTipo(guttipo);
  }
}