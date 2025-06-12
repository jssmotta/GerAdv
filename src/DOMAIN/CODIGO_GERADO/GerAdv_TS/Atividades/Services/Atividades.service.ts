'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { AtividadesApi, AtividadesApiError } from '../Apis/ApiAtividades';
import { FilterAtividades } from '../Filters/Atividades';
import { IAtividades } from '../Interfaces/interface.Atividades';

export class AtividadesValidator {
  static validateAtividades(atividades: IAtividades): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IAtividadesService {
  fetchAtividadesById: (id: number) => Promise<IAtividades>;
  saveAtividades: (atividades: IAtividades) => Promise<IAtividades>;  
  getList: (filtro?: FilterAtividades) => Promise<IAtividades[]>;
  getAll: (filtro?: FilterAtividades) => Promise<IAtividades[]>;
  deleteAtividades: (id: number) => Promise<void>;
  validateAtividades: (atividades: IAtividades) => { isValid: boolean; errors: string[] };
}

export class AtividadesService implements IAtividadesService {
  constructor(private api: AtividadesApi) {}

  async fetchAtividadesById(id: number): Promise<IAtividades> {
    if (id <= 0) {
      throw new AtividadesApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof AtividadesApiError) {
        throw error;
      }
      throw new AtividadesApiError('Erro ao buscar atividades', 500, 'FETCH_ERROR', error);
    }
  }

  async saveAtividades(atividades: IAtividades): Promise<IAtividades> {    
    const validation = this.validateAtividades(atividades);
    if (!validation.isValid) {
      throw new AtividadesApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(atividades);
      return response.data;
    } catch (error) {
      if (error instanceof AtividadesApiError) {
        throw error;
      }
      throw new AtividadesApiError('Erro ao salvar atividades', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterAtividades): Promise<IAtividades[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching atividades list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterAtividades): Promise<IAtividades[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all atividades:', error);
      return [];
    }
  }

  async deleteAtividades(id: number): Promise<void> {
    if (id <= 0) {
      throw new AtividadesApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof AtividadesApiError) {
        throw error;
      }
      throw new AtividadesApiError('Erro ao excluir atividades', 500, 'DELETE_ERROR', error);
    }
  }

  validateAtividades(atividades: IAtividades): { isValid: boolean; errors: string[] } {
    return AtividadesValidator.validateAtividades(atividades);
  }
}