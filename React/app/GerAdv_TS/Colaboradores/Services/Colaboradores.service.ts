'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ColaboradoresApi, ColaboradoresApiError } from '../Apis/ApiColaboradores';
import { FilterColaboradores } from '../Filters/Colaboradores';
import { IColaboradores } from '../Interfaces/interface.Colaboradores';

export class ColaboradoresValidator {
  static validateColaboradores(colaboradores: IColaboradores): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IColaboradoresService {
  fetchColaboradoresById: (id: number) => Promise<IColaboradores>;
  saveColaboradores: (colaboradores: IColaboradores) => Promise<IColaboradores>;  
  getList: (filtro?: FilterColaboradores) => Promise<IColaboradores[]>;
  getAll: (filtro?: FilterColaboradores) => Promise<IColaboradores[]>;
  deleteColaboradores: (id: number) => Promise<void>;
  validateColaboradores: (colaboradores: IColaboradores) => { isValid: boolean; errors: string[] };
}

export class ColaboradoresService implements IColaboradoresService {
  constructor(private api: ColaboradoresApi) {}

  async fetchColaboradoresById(id: number): Promise<IColaboradores> {
    if (id <= 0) {
      throw new ColaboradoresApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof ColaboradoresApiError) {
        throw error;
      }
      throw new ColaboradoresApiError('Erro ao buscar colaboradores', 500, 'FETCH_ERROR', error);
    }
  }

  async saveColaboradores(colaboradores: IColaboradores): Promise<IColaboradores> {    
    const validation = this.validateColaboradores(colaboradores);
    if (!validation.isValid) {
      throw new ColaboradoresApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(colaboradores);
      return response.data;
    } catch (error) {
      if (error instanceof ColaboradoresApiError) {
        throw error;
      }
      throw new ColaboradoresApiError('Erro ao salvar colaboradores', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterColaboradores): Promise<IColaboradores[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching colaboradores list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterColaboradores): Promise<IColaboradores[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all colaboradores:', error);
      return [];
    }
  }

  async deleteColaboradores(id: number): Promise<void> {
    if (id <= 0) {
      throw new ColaboradoresApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ColaboradoresApiError) {
        throw error;
      }
      throw new ColaboradoresApiError('Erro ao excluir colaboradores', 500, 'DELETE_ERROR', error);
    }
  }

  validateColaboradores(colaboradores: IColaboradores): { isValid: boolean; errors: string[] } {
    return ColaboradoresValidator.validateColaboradores(colaboradores);
  }
}