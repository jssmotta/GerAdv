'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ApensoApi, ApensoApiError } from '../Apis/ApiApenso';
import { FilterApenso } from '../Filters/Apenso';
import { IApenso } from '../Interfaces/interface.Apenso';
import { ApensoEmpty } from '../../Models/Apenso';

export class ApensoValidator {
  static validateApenso(apenso: IApenso): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IApensoService {
  fetchApensoById: (id: number) => Promise<IApenso>;
  saveApenso: (apenso: IApenso) => Promise<IApenso>;  
  
  getAll: (filtro?: FilterApenso) => Promise<IApenso[]>;
  deleteApenso: (id: number) => Promise<void>;
  validateApenso: (apenso: IApenso) => { isValid: boolean; errors: string[] };
}

export class ApensoService implements IApensoService {
  constructor(private api: ApensoApi) {}

  async fetchApensoById(id: number): Promise<IApenso> {
    if (id <= 0) {
      throw new ApensoApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof ApensoApiError) {
        throw error;
      }
      throw new ApensoApiError('Erro ao buscar apenso', 500, 'FETCH_ERROR', error);
    }
  }

  async saveApenso(apenso: IApenso): Promise<IApenso> {    
    const validation = this.validateApenso(apenso);
    if (!validation.isValid) {
      throw new ApensoApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(apenso);
      return response.data;
    } catch (error) {
      if (error instanceof ApensoApiError) {
        throw error;
      }
      throw new ApensoApiError('Erro ao salvar apenso', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterApenso): Promise<IApenso[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all apenso:', error);
      return [];
    }
  }

  async deleteApenso(id: number): Promise<void> {
    if (id <= 0) {
      throw new ApensoApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ApensoApiError) {
        throw error;
      }
      throw new ApensoApiError('Erro ao excluir apenso', 500, 'DELETE_ERROR', error);
    }
  }

  validateApenso(apenso: IApenso): { isValid: boolean; errors: string[] } {
    return ApensoValidator.validateApenso(apenso);
  }
}