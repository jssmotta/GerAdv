'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { NEPalavrasChavesApi, NEPalavrasChavesApiError } from '../Apis/ApiNEPalavrasChaves';
import { FilterNEPalavrasChaves } from '../Filters/NEPalavrasChaves';
import { INEPalavrasChaves } from '../Interfaces/interface.NEPalavrasChaves';

export class NEPalavrasChavesValidator {
  static validateNEPalavrasChaves(nepalavraschaves: INEPalavrasChaves): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface INEPalavrasChavesService {
  fetchNEPalavrasChavesById: (id: number) => Promise<INEPalavrasChaves>;
  saveNEPalavrasChaves: (nepalavraschaves: INEPalavrasChaves) => Promise<INEPalavrasChaves>;  
  getList: (filtro?: FilterNEPalavrasChaves) => Promise<INEPalavrasChaves[]>;
  getAll: (filtro?: FilterNEPalavrasChaves) => Promise<INEPalavrasChaves[]>;
  deleteNEPalavrasChaves: (id: number) => Promise<void>;
  validateNEPalavrasChaves: (nepalavraschaves: INEPalavrasChaves) => { isValid: boolean; errors: string[] };
}

export class NEPalavrasChavesService implements INEPalavrasChavesService {
  constructor(private api: NEPalavrasChavesApi) {}

  async fetchNEPalavrasChavesById(id: number): Promise<INEPalavrasChaves> {
    if (id <= 0) {
      throw new NEPalavrasChavesApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof NEPalavrasChavesApiError) {
        throw error;
      }
      throw new NEPalavrasChavesApiError('Erro ao buscar nepalavraschaves', 500, 'FETCH_ERROR', error);
    }
  }

  async saveNEPalavrasChaves(nepalavraschaves: INEPalavrasChaves): Promise<INEPalavrasChaves> {    
    const validation = this.validateNEPalavrasChaves(nepalavraschaves);
    if (!validation.isValid) {
      throw new NEPalavrasChavesApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(nepalavraschaves);
      return response.data;
    } catch (error) {
      if (error instanceof NEPalavrasChavesApiError) {
        throw error;
      }
      throw new NEPalavrasChavesApiError('Erro ao salvar nepalavraschaves', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterNEPalavrasChaves): Promise<INEPalavrasChaves[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching nepalavraschaves list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterNEPalavrasChaves): Promise<INEPalavrasChaves[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all nepalavraschaves:', error);
      return [];
    }
  }

  async deleteNEPalavrasChaves(id: number): Promise<void> {
    if (id <= 0) {
      throw new NEPalavrasChavesApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof NEPalavrasChavesApiError) {
        throw error;
      }
      throw new NEPalavrasChavesApiError('Erro ao excluir nepalavraschaves', 500, 'DELETE_ERROR', error);
    }
  }

  validateNEPalavrasChaves(nepalavraschaves: INEPalavrasChaves): { isValid: boolean; errors: string[] } {
    return NEPalavrasChavesValidator.validateNEPalavrasChaves(nepalavraschaves);
  }
}