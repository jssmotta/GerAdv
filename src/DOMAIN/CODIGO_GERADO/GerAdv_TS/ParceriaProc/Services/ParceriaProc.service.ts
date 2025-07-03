'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ParceriaProcApi, ParceriaProcApiError } from '../Apis/ApiParceriaProc';
import { FilterParceriaProc } from '../Filters/ParceriaProc';
import { IParceriaProc } from '../Interfaces/interface.ParceriaProc';
import { ParceriaProcEmpty } from '../../Models/ParceriaProc';

export class ParceriaProcValidator {
  static validateParceriaProc(parceriaproc: IParceriaProc): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IParceriaProcService {
  fetchParceriaProcById: (id: number) => Promise<IParceriaProc>;
  saveParceriaProc: (parceriaproc: IParceriaProc) => Promise<IParceriaProc>;  
  
  getAll: (filtro?: FilterParceriaProc) => Promise<IParceriaProc[]>;
  deleteParceriaProc: (id: number) => Promise<void>;
  validateParceriaProc: (parceriaproc: IParceriaProc) => { isValid: boolean; errors: string[] };
}

export class ParceriaProcService implements IParceriaProcService {
  constructor(private api: ParceriaProcApi) {}

  async fetchParceriaProcById(id: number): Promise<IParceriaProc> {
    if (id <= 0) {
      throw new ParceriaProcApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof ParceriaProcApiError) {
        throw error;
      }
      throw new ParceriaProcApiError('Erro ao buscar parceriaproc', 500, 'FETCH_ERROR', error);
    }
  }

  async saveParceriaProc(parceriaproc: IParceriaProc): Promise<IParceriaProc> {    
    const validation = this.validateParceriaProc(parceriaproc);
    if (!validation.isValid) {
      throw new ParceriaProcApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(parceriaproc);
      return response.data;
    } catch (error) {
      if (error instanceof ParceriaProcApiError) {
        throw error;
      }
      throw new ParceriaProcApiError('Erro ao salvar parceriaproc', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterParceriaProc): Promise<IParceriaProc[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all parceriaproc:', error);
      return [];
    }
  }

  async deleteParceriaProc(id: number): Promise<void> {
    if (id <= 0) {
      throw new ParceriaProcApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ParceriaProcApiError) {
        throw error;
      }
      throw new ParceriaProcApiError('Erro ao excluir parceriaproc', 500, 'DELETE_ERROR', error);
    }
  }

  validateParceriaProc(parceriaproc: IParceriaProc): { isValid: boolean; errors: string[] } {
    return ParceriaProcValidator.validateParceriaProc(parceriaproc);
  }
}