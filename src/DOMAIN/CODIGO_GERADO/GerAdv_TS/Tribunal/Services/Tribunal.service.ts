'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { TribunalApi, TribunalApiError } from '../Apis/ApiTribunal';
import { FilterTribunal } from '../Filters/Tribunal';
import { ITribunal } from '../Interfaces/interface.Tribunal';
import { TribunalEmpty } from '../../Models/Tribunal';

export class TribunalValidator {
  static validateTribunal(tribunal: ITribunal): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface ITribunalService {
  fetchTribunalById: (id: number) => Promise<ITribunal>;
  saveTribunal: (tribunal: ITribunal) => Promise<ITribunal>;  
  getList: (filtro?: FilterTribunal) => Promise<ITribunal[]>;
  getAll: (filtro?: FilterTribunal) => Promise<ITribunal[]>;
  deleteTribunal: (id: number) => Promise<void>;
  validateTribunal: (tribunal: ITribunal) => { isValid: boolean; errors: string[] };
}

export class TribunalService implements ITribunalService {
  constructor(private api: TribunalApi) {}

  async fetchTribunalById(id: number): Promise<ITribunal> {
    if (id <= 0) {
      throw new TribunalApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof TribunalApiError) {
        throw error;
      }
      throw new TribunalApiError('Erro ao buscar tribunal', 500, 'FETCH_ERROR', error);
    }
  }

  async saveTribunal(tribunal: ITribunal): Promise<ITribunal> {    
    const validation = this.validateTribunal(tribunal);
    if (!validation.isValid) {
      throw new TribunalApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(tribunal);
      return response.data;
    } catch (error) {
      if (error instanceof TribunalApiError) {
        throw error;
      }
      throw new TribunalApiError('Erro ao salvar tribunal', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterTribunal): Promise<ITribunal[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching tribunal list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterTribunal): Promise<ITribunal[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all tribunal:', error);
      return [];
    }
  }

  async deleteTribunal(id: number): Promise<void> {
    if (id <= 0) {
      throw new TribunalApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof TribunalApiError) {
        throw error;
      }
      throw new TribunalApiError('Erro ao excluir tribunal', 500, 'DELETE_ERROR', error);
    }
  }

  validateTribunal(tribunal: ITribunal): { isValid: boolean; errors: string[] } {
    return TribunalValidator.validateTribunal(tribunal);
  }
}