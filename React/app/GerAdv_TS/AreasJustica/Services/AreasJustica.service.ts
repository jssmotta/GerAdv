'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { AreasJusticaApi, AreasJusticaApiError } from '../Apis/ApiAreasJustica';
import { FilterAreasJustica } from '../Filters/AreasJustica';
import { IAreasJustica } from '../Interfaces/interface.AreasJustica';
import { AreasJusticaEmpty } from '../../Models/AreasJustica';

export class AreasJusticaValidator {
  static validateAreasJustica(areasjustica: IAreasJustica): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IAreasJusticaService {
  fetchAreasJusticaById: (id: number) => Promise<IAreasJustica>;
  saveAreasJustica: (areasjustica: IAreasJustica) => Promise<IAreasJustica>;  
  
  getAll: (filtro?: FilterAreasJustica) => Promise<IAreasJustica[]>;
  deleteAreasJustica: (id: number) => Promise<void>;
  validateAreasJustica: (areasjustica: IAreasJustica) => { isValid: boolean; errors: string[] };
}

export class AreasJusticaService implements IAreasJusticaService {
  constructor(private api: AreasJusticaApi) {}

  async fetchAreasJusticaById(id: number): Promise<IAreasJustica> {
    if (id <= 0) {
      throw new AreasJusticaApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof AreasJusticaApiError) {
        throw error;
      }
      throw new AreasJusticaApiError('Erro ao buscar areasjustica', 500, 'FETCH_ERROR', error);
    }
  }

  async saveAreasJustica(areasjustica: IAreasJustica): Promise<IAreasJustica> {    
    const validation = this.validateAreasJustica(areasjustica);
    if (!validation.isValid) {
      throw new AreasJusticaApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(areasjustica);
      return response.data;
    } catch (error) {
      if (error instanceof AreasJusticaApiError) {
        throw error;
      }
      throw new AreasJusticaApiError('Erro ao salvar areasjustica', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterAreasJustica): Promise<IAreasJustica[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all areasjustica:', error);
      return [];
    }
  }

  async deleteAreasJustica(id: number): Promise<void> {
    if (id <= 0) {
      throw new AreasJusticaApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof AreasJusticaApiError) {
        throw error;
      }
      throw new AreasJusticaApiError('Erro ao excluir areasjustica', 500, 'DELETE_ERROR', error);
    }
  }

  validateAreasJustica(areasjustica: IAreasJustica): { isValid: boolean; errors: string[] } {
    return AreasJusticaValidator.validateAreasJustica(areasjustica);
  }
}