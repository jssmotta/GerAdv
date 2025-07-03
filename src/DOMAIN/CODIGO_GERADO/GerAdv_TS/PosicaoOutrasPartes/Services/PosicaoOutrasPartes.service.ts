'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { PosicaoOutrasPartesApi, PosicaoOutrasPartesApiError } from '../Apis/ApiPosicaoOutrasPartes';
import { FilterPosicaoOutrasPartes } from '../Filters/PosicaoOutrasPartes';
import { IPosicaoOutrasPartes } from '../Interfaces/interface.PosicaoOutrasPartes';
import { PosicaoOutrasPartesEmpty } from '../../Models/PosicaoOutrasPartes';

export class PosicaoOutrasPartesValidator {
  static validatePosicaoOutrasPartes(posicaooutraspartes: IPosicaoOutrasPartes): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IPosicaoOutrasPartesService {
  fetchPosicaoOutrasPartesById: (id: number) => Promise<IPosicaoOutrasPartes>;
  savePosicaoOutrasPartes: (posicaooutraspartes: IPosicaoOutrasPartes) => Promise<IPosicaoOutrasPartes>;  
  getList: (filtro?: FilterPosicaoOutrasPartes) => Promise<IPosicaoOutrasPartes[]>;
  getAll: (filtro?: FilterPosicaoOutrasPartes) => Promise<IPosicaoOutrasPartes[]>;
  deletePosicaoOutrasPartes: (id: number) => Promise<void>;
  validatePosicaoOutrasPartes: (posicaooutraspartes: IPosicaoOutrasPartes) => { isValid: boolean; errors: string[] };
}

export class PosicaoOutrasPartesService implements IPosicaoOutrasPartesService {
  constructor(private api: PosicaoOutrasPartesApi) {}

  async fetchPosicaoOutrasPartesById(id: number): Promise<IPosicaoOutrasPartes> {
    if (id <= 0) {
      throw new PosicaoOutrasPartesApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof PosicaoOutrasPartesApiError) {
        throw error;
      }
      throw new PosicaoOutrasPartesApiError('Erro ao buscar posicaooutraspartes', 500, 'FETCH_ERROR', error);
    }
  }

  async savePosicaoOutrasPartes(posicaooutraspartes: IPosicaoOutrasPartes): Promise<IPosicaoOutrasPartes> {    
    const validation = this.validatePosicaoOutrasPartes(posicaooutraspartes);
    if (!validation.isValid) {
      throw new PosicaoOutrasPartesApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(posicaooutraspartes);
      return response.data;
    } catch (error) {
      if (error instanceof PosicaoOutrasPartesApiError) {
        throw error;
      }
      throw new PosicaoOutrasPartesApiError('Erro ao salvar posicaooutraspartes', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterPosicaoOutrasPartes): Promise<IPosicaoOutrasPartes[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching posicaooutraspartes list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterPosicaoOutrasPartes): Promise<IPosicaoOutrasPartes[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all posicaooutraspartes:', error);
      return [];
    }
  }

  async deletePosicaoOutrasPartes(id: number): Promise<void> {
    if (id <= 0) {
      throw new PosicaoOutrasPartesApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof PosicaoOutrasPartesApiError) {
        throw error;
      }
      throw new PosicaoOutrasPartesApiError('Erro ao excluir posicaooutraspartes', 500, 'DELETE_ERROR', error);
    }
  }

  validatePosicaoOutrasPartes(posicaooutraspartes: IPosicaoOutrasPartes): { isValid: boolean; errors: string[] } {
    return PosicaoOutrasPartesValidator.validatePosicaoOutrasPartes(posicaooutraspartes);
  }
}