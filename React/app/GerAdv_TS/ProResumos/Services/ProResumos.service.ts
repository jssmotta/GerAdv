'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ProResumosApi, ProResumosApiError } from '../Apis/ApiProResumos';
import { FilterProResumos } from '../Filters/ProResumos';
import { IProResumos } from '../Interfaces/interface.ProResumos';
import { ProResumosEmpty } from '../../Models/ProResumos';

export class ProResumosValidator {
  static validateProResumos(proresumos: IProResumos): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IProResumosService {
  fetchProResumosById: (id: number) => Promise<IProResumos>;
  saveProResumos: (proresumos: IProResumos) => Promise<IProResumos>;  
  
  getAll: (filtro?: FilterProResumos) => Promise<IProResumos[]>;
  deleteProResumos: (id: number) => Promise<void>;
  validateProResumos: (proresumos: IProResumos) => { isValid: boolean; errors: string[] };
}

export class ProResumosService implements IProResumosService {
  constructor(private api: ProResumosApi) {}

  async fetchProResumosById(id: number): Promise<IProResumos> {
    if (id <= 0) {
      throw new ProResumosApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof ProResumosApiError) {
        throw error;
      }
      throw new ProResumosApiError('Erro ao buscar proresumos', 500, 'FETCH_ERROR', error);
    }
  }

  async saveProResumos(proresumos: IProResumos): Promise<IProResumos> {    
    const validation = this.validateProResumos(proresumos);
    if (!validation.isValid) {
      throw new ProResumosApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(proresumos);
      return response.data;
    } catch (error) {
      if (error instanceof ProResumosApiError) {
        throw error;
      }
      throw new ProResumosApiError('Erro ao salvar proresumos', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterProResumos): Promise<IProResumos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all proresumos:', error);
      return [];
    }
  }

  async deleteProResumos(id: number): Promise<void> {
    if (id <= 0) {
      throw new ProResumosApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ProResumosApiError) {
        throw error;
      }
      throw new ProResumosApiError('Erro ao excluir proresumos', 500, 'DELETE_ERROR', error);
    }
  }

  validateProResumos(proresumos: IProResumos): { isValid: boolean; errors: string[] } {
    return ProResumosValidator.validateProResumos(proresumos);
  }
}