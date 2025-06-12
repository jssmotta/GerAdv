'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { FaseApi, FaseApiError } from '../Apis/ApiFase';
import { FilterFase } from '../Filters/Fase';
import { IFase } from '../Interfaces/interface.Fase';

export class FaseValidator {
  static validateFase(fase: IFase): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IFaseService {
  fetchFaseById: (id: number) => Promise<IFase>;
  saveFase: (fase: IFase) => Promise<IFase>;  
  getList: (filtro?: FilterFase) => Promise<IFase[]>;
  getAll: (filtro?: FilterFase) => Promise<IFase[]>;
  deleteFase: (id: number) => Promise<void>;
  validateFase: (fase: IFase) => { isValid: boolean; errors: string[] };
}

export class FaseService implements IFaseService {
  constructor(private api: FaseApi) {}

  async fetchFaseById(id: number): Promise<IFase> {
    if (id <= 0) {
      throw new FaseApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof FaseApiError) {
        throw error;
      }
      throw new FaseApiError('Erro ao buscar fase', 500, 'FETCH_ERROR', error);
    }
  }

  async saveFase(fase: IFase): Promise<IFase> {    
    const validation = this.validateFase(fase);
    if (!validation.isValid) {
      throw new FaseApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(fase);
      return response.data;
    } catch (error) {
      if (error instanceof FaseApiError) {
        throw error;
      }
      throw new FaseApiError('Erro ao salvar fase', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterFase): Promise<IFase[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching fase list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterFase): Promise<IFase[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all fase:', error);
      return [];
    }
  }

  async deleteFase(id: number): Promise<void> {
    if (id <= 0) {
      throw new FaseApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof FaseApiError) {
        throw error;
      }
      throw new FaseApiError('Erro ao excluir fase', 500, 'DELETE_ERROR', error);
    }
  }

  validateFase(fase: IFase): { isValid: boolean; errors: string[] } {
    return FaseValidator.validateFase(fase);
  }
}