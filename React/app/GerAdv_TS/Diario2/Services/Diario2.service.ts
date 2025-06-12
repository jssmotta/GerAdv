'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { Diario2Api, Diario2ApiError } from '../Apis/ApiDiario2';
import { FilterDiario2 } from '../Filters/Diario2';
import { IDiario2 } from '../Interfaces/interface.Diario2';

export class Diario2Validator {
  static validateDiario2(diario2: IDiario2): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IDiario2Service {
  fetchDiario2ById: (id: number) => Promise<IDiario2>;
  saveDiario2: (diario2: IDiario2) => Promise<IDiario2>;  
  getList: (filtro?: FilterDiario2) => Promise<IDiario2[]>;
  getAll: (filtro?: FilterDiario2) => Promise<IDiario2[]>;
  deleteDiario2: (id: number) => Promise<void>;
  validateDiario2: (diario2: IDiario2) => { isValid: boolean; errors: string[] };
}

export class Diario2Service implements IDiario2Service {
  constructor(private api: Diario2Api) {}

  async fetchDiario2ById(id: number): Promise<IDiario2> {
    if (id <= 0) {
      throw new Diario2ApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof Diario2ApiError) {
        throw error;
      }
      throw new Diario2ApiError('Erro ao buscar diario2', 500, 'FETCH_ERROR', error);
    }
  }

  async saveDiario2(diario2: IDiario2): Promise<IDiario2> {    
    const validation = this.validateDiario2(diario2);
    if (!validation.isValid) {
      throw new Diario2ApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(diario2);
      return response.data;
    } catch (error) {
      if (error instanceof Diario2ApiError) {
        throw error;
      }
      throw new Diario2ApiError('Erro ao salvar diario2', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterDiario2): Promise<IDiario2[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching diario2 list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterDiario2): Promise<IDiario2[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all diario2:', error);
      return [];
    }
  }

  async deleteDiario2(id: number): Promise<void> {
    if (id <= 0) {
      throw new Diario2ApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof Diario2ApiError) {
        throw error;
      }
      throw new Diario2ApiError('Erro ao excluir diario2', 500, 'DELETE_ERROR', error);
    }
  }

  validateDiario2(diario2: IDiario2): { isValid: boolean; errors: string[] } {
    return Diario2Validator.validateDiario2(diario2);
  }
}