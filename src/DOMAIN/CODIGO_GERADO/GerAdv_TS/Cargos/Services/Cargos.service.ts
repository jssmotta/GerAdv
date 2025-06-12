'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { CargosApi, CargosApiError } from '../Apis/ApiCargos';
import { FilterCargos } from '../Filters/Cargos';
import { ICargos } from '../Interfaces/interface.Cargos';

export class CargosValidator {
  static validateCargos(cargos: ICargos): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface ICargosService {
  fetchCargosById: (id: number) => Promise<ICargos>;
  saveCargos: (cargos: ICargos) => Promise<ICargos>;  
  getList: (filtro?: FilterCargos) => Promise<ICargos[]>;
  getAll: (filtro?: FilterCargos) => Promise<ICargos[]>;
  deleteCargos: (id: number) => Promise<void>;
  validateCargos: (cargos: ICargos) => { isValid: boolean; errors: string[] };
}

export class CargosService implements ICargosService {
  constructor(private api: CargosApi) {}

  async fetchCargosById(id: number): Promise<ICargos> {
    if (id <= 0) {
      throw new CargosApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof CargosApiError) {
        throw error;
      }
      throw new CargosApiError('Erro ao buscar cargos', 500, 'FETCH_ERROR', error);
    }
  }

  async saveCargos(cargos: ICargos): Promise<ICargos> {    
    const validation = this.validateCargos(cargos);
    if (!validation.isValid) {
      throw new CargosApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(cargos);
      return response.data;
    } catch (error) {
      if (error instanceof CargosApiError) {
        throw error;
      }
      throw new CargosApiError('Erro ao salvar cargos', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterCargos): Promise<ICargos[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching cargos list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterCargos): Promise<ICargos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all cargos:', error);
      return [];
    }
  }

  async deleteCargos(id: number): Promise<void> {
    if (id <= 0) {
      throw new CargosApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof CargosApiError) {
        throw error;
      }
      throw new CargosApiError('Erro ao excluir cargos', 500, 'DELETE_ERROR', error);
    }
  }

  validateCargos(cargos: ICargos): { isValid: boolean; errors: string[] } {
    return CargosValidator.validateCargos(cargos);
  }
}