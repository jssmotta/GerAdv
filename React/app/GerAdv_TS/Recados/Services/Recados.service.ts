'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { RecadosApi, RecadosApiError } from '../Apis/ApiRecados';
import { FilterRecados } from '../Filters/Recados';
import { IRecados } from '../Interfaces/interface.Recados';

export class RecadosValidator {
  static validateRecados(recados: IRecados): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IRecadosService {
  fetchRecadosById: (id: number) => Promise<IRecados>;
  saveRecados: (recados: IRecados) => Promise<IRecados>;  
  
  getAll: (filtro?: FilterRecados) => Promise<IRecados[]>;
  deleteRecados: (id: number) => Promise<void>;
  validateRecados: (recados: IRecados) => { isValid: boolean; errors: string[] };
}

export class RecadosService implements IRecadosService {
  constructor(private api: RecadosApi) {}

  async fetchRecadosById(id: number): Promise<IRecados> {
    if (id <= 0) {
      throw new RecadosApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof RecadosApiError) {
        throw error;
      }
      throw new RecadosApiError('Erro ao buscar recados', 500, 'FETCH_ERROR', error);
    }
  }

  async saveRecados(recados: IRecados): Promise<IRecados> {    
    const validation = this.validateRecados(recados);
    if (!validation.isValid) {
      throw new RecadosApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(recados);
      return response.data;
    } catch (error) {
      if (error instanceof RecadosApiError) {
        throw error;
      }
      throw new RecadosApiError('Erro ao salvar recados', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterRecados): Promise<IRecados[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all recados:', error);
      return [];
    }
  }

  async deleteRecados(id: number): Promise<void> {
    if (id <= 0) {
      throw new RecadosApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof RecadosApiError) {
        throw error;
      }
      throw new RecadosApiError('Erro ao excluir recados', 500, 'DELETE_ERROR', error);
    }
  }

  validateRecados(recados: IRecados): { isValid: boolean; errors: string[] } {
    return RecadosValidator.validateRecados(recados);
  }
}