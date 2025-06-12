'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { InstanciaApi, InstanciaApiError } from '../Apis/ApiInstancia';
import { FilterInstancia } from '../Filters/Instancia';
import { IInstancia } from '../Interfaces/interface.Instancia';

export class InstanciaValidator {
  static validateInstancia(instancia: IInstancia): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IInstanciaService {
  fetchInstanciaById: (id: number) => Promise<IInstancia>;
  saveInstancia: (instancia: IInstancia) => Promise<IInstancia>;  
  getList: (filtro?: FilterInstancia) => Promise<IInstancia[]>;
  getAll: (filtro?: FilterInstancia) => Promise<IInstancia[]>;
  deleteInstancia: (id: number) => Promise<void>;
  validateInstancia: (instancia: IInstancia) => { isValid: boolean; errors: string[] };
}

export class InstanciaService implements IInstanciaService {
  constructor(private api: InstanciaApi) {}

  async fetchInstanciaById(id: number): Promise<IInstancia> {
    if (id <= 0) {
      throw new InstanciaApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof InstanciaApiError) {
        throw error;
      }
      throw new InstanciaApiError('Erro ao buscar instancia', 500, 'FETCH_ERROR', error);
    }
  }

  async saveInstancia(instancia: IInstancia): Promise<IInstancia> {    
    const validation = this.validateInstancia(instancia);
    if (!validation.isValid) {
      throw new InstanciaApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(instancia);
      return response.data;
    } catch (error) {
      if (error instanceof InstanciaApiError) {
        throw error;
      }
      throw new InstanciaApiError('Erro ao salvar instancia', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterInstancia): Promise<IInstancia[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching instancia list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterInstancia): Promise<IInstancia[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all instancia:', error);
      return [];
    }
  }

  async deleteInstancia(id: number): Promise<void> {
    if (id <= 0) {
      throw new InstanciaApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof InstanciaApiError) {
        throw error;
      }
      throw new InstanciaApiError('Erro ao excluir instancia', 500, 'DELETE_ERROR', error);
    }
  }

  validateInstancia(instancia: IInstancia): { isValid: boolean; errors: string[] } {
    return InstanciaValidator.validateInstancia(instancia);
  }
}