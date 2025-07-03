'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { CargosEscApi, CargosEscApiError } from '../Apis/ApiCargosEsc';
import { FilterCargosEsc } from '../Filters/CargosEsc';
import { ICargosEsc } from '../Interfaces/interface.CargosEsc';
import { CargosEscEmpty } from '../../Models/CargosEsc';

export class CargosEscValidator {
  static validateCargosEsc(cargosesc: ICargosEsc): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface ICargosEscService {
  fetchCargosEscById: (id: number) => Promise<ICargosEsc>;
  saveCargosEsc: (cargosesc: ICargosEsc) => Promise<ICargosEsc>;  
  getList: (filtro?: FilterCargosEsc) => Promise<ICargosEsc[]>;
  getAll: (filtro?: FilterCargosEsc) => Promise<ICargosEsc[]>;
  deleteCargosEsc: (id: number) => Promise<void>;
  validateCargosEsc: (cargosesc: ICargosEsc) => { isValid: boolean; errors: string[] };
}

export class CargosEscService implements ICargosEscService {
  constructor(private api: CargosEscApi) {}

  async fetchCargosEscById(id: number): Promise<ICargosEsc> {
    if (id <= 0) {
      throw new CargosEscApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof CargosEscApiError) {
        throw error;
      }
      throw new CargosEscApiError('Erro ao buscar cargosesc', 500, 'FETCH_ERROR', error);
    }
  }

  async saveCargosEsc(cargosesc: ICargosEsc): Promise<ICargosEsc> {    
    const validation = this.validateCargosEsc(cargosesc);
    if (!validation.isValid) {
      throw new CargosEscApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(cargosesc);
      return response.data;
    } catch (error) {
      if (error instanceof CargosEscApiError) {
        throw error;
      }
      throw new CargosEscApiError('Erro ao salvar cargosesc', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterCargosEsc): Promise<ICargosEsc[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching cargosesc list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterCargosEsc): Promise<ICargosEsc[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all cargosesc:', error);
      return [];
    }
  }

  async deleteCargosEsc(id: number): Promise<void> {
    if (id <= 0) {
      throw new CargosEscApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof CargosEscApiError) {
        throw error;
      }
      throw new CargosEscApiError('Erro ao excluir cargosesc', 500, 'DELETE_ERROR', error);
    }
  }

  validateCargosEsc(cargosesc: ICargosEsc): { isValid: boolean; errors: string[] } {
    return CargosEscValidator.validateCargosEsc(cargosesc);
  }
}