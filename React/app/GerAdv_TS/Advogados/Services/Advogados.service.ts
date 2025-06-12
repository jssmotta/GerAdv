'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { AdvogadosApi, AdvogadosApiError } from '../Apis/ApiAdvogados';
import { FilterAdvogados } from '../Filters/Advogados';
import { IAdvogados } from '../Interfaces/interface.Advogados';

export class AdvogadosValidator {
  static validateAdvogados(advogados: IAdvogados): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IAdvogadosService {
  fetchAdvogadosById: (id: number) => Promise<IAdvogados>;
  saveAdvogados: (advogados: IAdvogados) => Promise<IAdvogados>;  
  getList: (filtro?: FilterAdvogados) => Promise<IAdvogados[]>;
  getAll: (filtro?: FilterAdvogados) => Promise<IAdvogados[]>;
  deleteAdvogados: (id: number) => Promise<void>;
  validateAdvogados: (advogados: IAdvogados) => { isValid: boolean; errors: string[] };
}

export class AdvogadosService implements IAdvogadosService {
  constructor(private api: AdvogadosApi) {}

  async fetchAdvogadosById(id: number): Promise<IAdvogados> {
    if (id <= 0) {
      throw new AdvogadosApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof AdvogadosApiError) {
        throw error;
      }
      throw new AdvogadosApiError('Erro ao buscar advogados', 500, 'FETCH_ERROR', error);
    }
  }

  async saveAdvogados(advogados: IAdvogados): Promise<IAdvogados> {    
    const validation = this.validateAdvogados(advogados);
    if (!validation.isValid) {
      throw new AdvogadosApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(advogados);
      return response.data;
    } catch (error) {
      if (error instanceof AdvogadosApiError) {
        throw error;
      }
      throw new AdvogadosApiError('Erro ao salvar advogados', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterAdvogados): Promise<IAdvogados[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching advogados list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterAdvogados): Promise<IAdvogados[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all advogados:', error);
      return [];
    }
  }

  async deleteAdvogados(id: number): Promise<void> {
    if (id <= 0) {
      throw new AdvogadosApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof AdvogadosApiError) {
        throw error;
      }
      throw new AdvogadosApiError('Erro ao excluir advogados', 500, 'DELETE_ERROR', error);
    }
  }

  validateAdvogados(advogados: IAdvogados): { isValid: boolean; errors: string[] } {
    return AdvogadosValidator.validateAdvogados(advogados);
  }
}