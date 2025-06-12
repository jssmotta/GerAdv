'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { PaisesApi, PaisesApiError } from '../Apis/ApiPaises';
import { FilterPaises } from '../Filters/Paises';
import { IPaises } from '../Interfaces/interface.Paises';

export class PaisesValidator {
  static validatePaises(paises: IPaises): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IPaisesService {
  fetchPaisesById: (id: number) => Promise<IPaises>;
  savePaises: (paises: IPaises) => Promise<IPaises>;  
  getList: (filtro?: FilterPaises) => Promise<IPaises[]>;
  getAll: (filtro?: FilterPaises) => Promise<IPaises[]>;
  deletePaises: (id: number) => Promise<void>;
  validatePaises: (paises: IPaises) => { isValid: boolean; errors: string[] };
}

export class PaisesService implements IPaisesService {
  constructor(private api: PaisesApi) {}

  async fetchPaisesById(id: number): Promise<IPaises> {
    if (id <= 0) {
      throw new PaisesApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof PaisesApiError) {
        throw error;
      }
      throw new PaisesApiError('Erro ao buscar paises', 500, 'FETCH_ERROR', error);
    }
  }

  async savePaises(paises: IPaises): Promise<IPaises> {    
    const validation = this.validatePaises(paises);
    if (!validation.isValid) {
      throw new PaisesApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(paises);
      return response.data;
    } catch (error) {
      if (error instanceof PaisesApiError) {
        throw error;
      }
      throw new PaisesApiError('Erro ao salvar paises', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterPaises): Promise<IPaises[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching paises list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterPaises): Promise<IPaises[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all paises:', error);
      return [];
    }
  }

  async deletePaises(id: number): Promise<void> {
    if (id <= 0) {
      throw new PaisesApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof PaisesApiError) {
        throw error;
      }
      throw new PaisesApiError('Erro ao excluir paises', 500, 'DELETE_ERROR', error);
    }
  }

  validatePaises(paises: IPaises): { isValid: boolean; errors: string[] } {
    return PaisesValidator.validatePaises(paises);
  }
}