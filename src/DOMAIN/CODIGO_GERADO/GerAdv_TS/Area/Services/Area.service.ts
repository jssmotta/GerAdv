'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { AreaApi, AreaApiError } from '../Apis/ApiArea';
import { FilterArea } from '../Filters/Area';
import { IArea } from '../Interfaces/interface.Area';

export class AreaValidator {
  static validateArea(area: IArea): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IAreaService {
  fetchAreaById: (id: number) => Promise<IArea>;
  saveArea: (area: IArea) => Promise<IArea>;  
  getList: (filtro?: FilterArea) => Promise<IArea[]>;
  getAll: (filtro?: FilterArea) => Promise<IArea[]>;
  deleteArea: (id: number) => Promise<void>;
  validateArea: (area: IArea) => { isValid: boolean; errors: string[] };
}

export class AreaService implements IAreaService {
  constructor(private api: AreaApi) {}

  async fetchAreaById(id: number): Promise<IArea> {
    if (id <= 0) {
      throw new AreaApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof AreaApiError) {
        throw error;
      }
      throw new AreaApiError('Erro ao buscar area', 500, 'FETCH_ERROR', error);
    }
  }

  async saveArea(area: IArea): Promise<IArea> {    
    const validation = this.validateArea(area);
    if (!validation.isValid) {
      throw new AreaApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(area);
      return response.data;
    } catch (error) {
      if (error instanceof AreaApiError) {
        throw error;
      }
      throw new AreaApiError('Erro ao salvar area', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterArea): Promise<IArea[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching area list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterArea): Promise<IArea[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all area:', error);
      return [];
    }
  }

  async deleteArea(id: number): Promise<void> {
    if (id <= 0) {
      throw new AreaApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof AreaApiError) {
        throw error;
      }
      throw new AreaApiError('Erro ao excluir area', 500, 'DELETE_ERROR', error);
    }
  }

  validateArea(area: IArea): { isValid: boolean; errors: string[] } {
    return AreaValidator.validateArea(area);
  }
}