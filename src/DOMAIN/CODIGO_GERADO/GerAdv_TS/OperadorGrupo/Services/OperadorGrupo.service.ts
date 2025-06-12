'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { OperadorGrupoApi, OperadorGrupoApiError } from '../Apis/ApiOperadorGrupo';
import { FilterOperadorGrupo } from '../Filters/OperadorGrupo';
import { IOperadorGrupo } from '../Interfaces/interface.OperadorGrupo';

export class OperadorGrupoValidator {
  static validateOperadorGrupo(operadorgrupo: IOperadorGrupo): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IOperadorGrupoService {
  fetchOperadorGrupoById: (id: number) => Promise<IOperadorGrupo>;
  saveOperadorGrupo: (operadorgrupo: IOperadorGrupo) => Promise<IOperadorGrupo>;  
  
  getAll: (filtro?: FilterOperadorGrupo) => Promise<IOperadorGrupo[]>;
  deleteOperadorGrupo: (id: number) => Promise<void>;
  validateOperadorGrupo: (operadorgrupo: IOperadorGrupo) => { isValid: boolean; errors: string[] };
}

export class OperadorGrupoService implements IOperadorGrupoService {
  constructor(private api: OperadorGrupoApi) {}

  async fetchOperadorGrupoById(id: number): Promise<IOperadorGrupo> {
    if (id <= 0) {
      throw new OperadorGrupoApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof OperadorGrupoApiError) {
        throw error;
      }
      throw new OperadorGrupoApiError('Erro ao buscar operadorgrupo', 500, 'FETCH_ERROR', error);
    }
  }

  async saveOperadorGrupo(operadorgrupo: IOperadorGrupo): Promise<IOperadorGrupo> {    
    const validation = this.validateOperadorGrupo(operadorgrupo);
    if (!validation.isValid) {
      throw new OperadorGrupoApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(operadorgrupo);
      return response.data;
    } catch (error) {
      if (error instanceof OperadorGrupoApiError) {
        throw error;
      }
      throw new OperadorGrupoApiError('Erro ao salvar operadorgrupo', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterOperadorGrupo): Promise<IOperadorGrupo[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all operadorgrupo:', error);
      return [];
    }
  }

  async deleteOperadorGrupo(id: number): Promise<void> {
    if (id <= 0) {
      throw new OperadorGrupoApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof OperadorGrupoApiError) {
        throw error;
      }
      throw new OperadorGrupoApiError('Erro ao excluir operadorgrupo', 500, 'DELETE_ERROR', error);
    }
  }

  validateOperadorGrupo(operadorgrupo: IOperadorGrupo): { isValid: boolean; errors: string[] } {
    return OperadorGrupoValidator.validateOperadorGrupo(operadorgrupo);
  }
}