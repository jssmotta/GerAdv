'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { EscritoriosApi, EscritoriosApiError } from '../Apis/ApiEscritorios';
import { FilterEscritorios } from '../Filters/Escritorios';
import { IEscritorios } from '../Interfaces/interface.Escritorios';
import { EscritoriosEmpty } from '../../Models/Escritorios';

export class EscritoriosValidator {
  static validateEscritorios(escritorios: IEscritorios): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IEscritoriosService {
  fetchEscritoriosById: (id: number) => Promise<IEscritorios>;
  saveEscritorios: (escritorios: IEscritorios) => Promise<IEscritorios>;  
  getList: (filtro?: FilterEscritorios) => Promise<IEscritorios[]>;
  getAll: (filtro?: FilterEscritorios) => Promise<IEscritorios[]>;
  deleteEscritorios: (id: number) => Promise<void>;
  validateEscritorios: (escritorios: IEscritorios) => { isValid: boolean; errors: string[] };
}

export class EscritoriosService implements IEscritoriosService {
  constructor(private api: EscritoriosApi) {}

  async fetchEscritoriosById(id: number): Promise<IEscritorios> {
    if (id <= 0) {
      throw new EscritoriosApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof EscritoriosApiError) {
        throw error;
      }
      throw new EscritoriosApiError('Erro ao buscar escritorios', 500, 'FETCH_ERROR', error);
    }
  }

  async saveEscritorios(escritorios: IEscritorios): Promise<IEscritorios> {    
    const validation = this.validateEscritorios(escritorios);
    if (!validation.isValid) {
      throw new EscritoriosApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(escritorios);
      return response.data;
    } catch (error) {
      if (error instanceof EscritoriosApiError) {
        throw error;
      }
      throw new EscritoriosApiError('Erro ao salvar escritorios', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterEscritorios): Promise<IEscritorios[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching escritorios list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterEscritorios): Promise<IEscritorios[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all escritorios:', error);
      return [];
    }
  }

  async deleteEscritorios(id: number): Promise<void> {
    if (id <= 0) {
      throw new EscritoriosApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof EscritoriosApiError) {
        throw error;
      }
      throw new EscritoriosApiError('Erro ao excluir escritorios', 500, 'DELETE_ERROR', error);
    }
  }

  validateEscritorios(escritorios: IEscritorios): { isValid: boolean; errors: string[] } {
    return EscritoriosValidator.validateEscritorios(escritorios);
  }
}