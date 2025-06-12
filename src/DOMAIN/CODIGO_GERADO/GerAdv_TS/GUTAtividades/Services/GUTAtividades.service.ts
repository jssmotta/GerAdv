'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { GUTAtividadesApi, GUTAtividadesApiError } from '../Apis/ApiGUTAtividades';
import { FilterGUTAtividades } from '../Filters/GUTAtividades';
import { IGUTAtividades } from '../Interfaces/interface.GUTAtividades';

export class GUTAtividadesValidator {
  static validateGUTAtividades(gutatividades: IGUTAtividades): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IGUTAtividadesService {
  fetchGUTAtividadesById: (id: number) => Promise<IGUTAtividades>;
  saveGUTAtividades: (gutatividades: IGUTAtividades) => Promise<IGUTAtividades>;  
  getList: (filtro?: FilterGUTAtividades) => Promise<IGUTAtividades[]>;
  getAll: (filtro?: FilterGUTAtividades) => Promise<IGUTAtividades[]>;
  deleteGUTAtividades: (id: number) => Promise<void>;
  validateGUTAtividades: (gutatividades: IGUTAtividades) => { isValid: boolean; errors: string[] };
}

export class GUTAtividadesService implements IGUTAtividadesService {
  constructor(private api: GUTAtividadesApi) {}

  async fetchGUTAtividadesById(id: number): Promise<IGUTAtividades> {
    if (id <= 0) {
      throw new GUTAtividadesApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof GUTAtividadesApiError) {
        throw error;
      }
      throw new GUTAtividadesApiError('Erro ao buscar gutatividades', 500, 'FETCH_ERROR', error);
    }
  }

  async saveGUTAtividades(gutatividades: IGUTAtividades): Promise<IGUTAtividades> {    
    const validation = this.validateGUTAtividades(gutatividades);
    if (!validation.isValid) {
      throw new GUTAtividadesApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(gutatividades);
      return response.data;
    } catch (error) {
      if (error instanceof GUTAtividadesApiError) {
        throw error;
      }
      throw new GUTAtividadesApiError('Erro ao salvar gutatividades', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterGUTAtividades): Promise<IGUTAtividades[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching gutatividades list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterGUTAtividades): Promise<IGUTAtividades[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all gutatividades:', error);
      return [];
    }
  }

  async deleteGUTAtividades(id: number): Promise<void> {
    if (id <= 0) {
      throw new GUTAtividadesApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof GUTAtividadesApiError) {
        throw error;
      }
      throw new GUTAtividadesApiError('Erro ao excluir gutatividades', 500, 'DELETE_ERROR', error);
    }
  }

  validateGUTAtividades(gutatividades: IGUTAtividades): { isValid: boolean; errors: string[] } {
    return GUTAtividadesValidator.validateGUTAtividades(gutatividades);
  }
}