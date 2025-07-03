'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ForoApi, ForoApiError } from '../Apis/ApiForo';
import { FilterForo } from '../Filters/Foro';
import { IForo } from '../Interfaces/interface.Foro';
import { ForoEmpty } from '../../Models/Foro';

export class ForoValidator {
  static validateForo(foro: IForo): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IForoService {
  fetchForoById: (id: number) => Promise<IForo>;
  saveForo: (foro: IForo) => Promise<IForo>;  
  getList: (filtro?: FilterForo) => Promise<IForo[]>;
  getAll: (filtro?: FilterForo) => Promise<IForo[]>;
  deleteForo: (id: number) => Promise<void>;
  validateForo: (foro: IForo) => { isValid: boolean; errors: string[] };
}

export class ForoService implements IForoService {
  constructor(private api: ForoApi) {}

  async fetchForoById(id: number): Promise<IForo> {
    if (id <= 0) {
      throw new ForoApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof ForoApiError) {
        throw error;
      }
      throw new ForoApiError('Erro ao buscar foro', 500, 'FETCH_ERROR', error);
    }
  }

  async saveForo(foro: IForo): Promise<IForo> {    
    const validation = this.validateForo(foro);
    if (!validation.isValid) {
      throw new ForoApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(foro);
      return response.data;
    } catch (error) {
      if (error instanceof ForoApiError) {
        throw error;
      }
      throw new ForoApiError('Erro ao salvar foro', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterForo): Promise<IForo[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching foro list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterForo): Promise<IForo[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all foro:', error);
      return [];
    }
  }

  async deleteForo(id: number): Promise<void> {
    if (id <= 0) {
      throw new ForoApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ForoApiError) {
        throw error;
      }
      throw new ForoApiError('Erro ao excluir foro', 500, 'DELETE_ERROR', error);
    }
  }

  validateForo(foro: IForo): { isValid: boolean; errors: string[] } {
    return ForoValidator.validateForo(foro);
  }
}