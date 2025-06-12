'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { LigacoesApi, LigacoesApiError } from '../Apis/ApiLigacoes';
import { FilterLigacoes } from '../Filters/Ligacoes';
import { ILigacoes } from '../Interfaces/interface.Ligacoes';

export class LigacoesValidator {
  static validateLigacoes(ligacoes: ILigacoes): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface ILigacoesService {
  fetchLigacoesById: (id: number) => Promise<ILigacoes>;
  saveLigacoes: (ligacoes: ILigacoes) => Promise<ILigacoes>;  
  getList: (filtro?: FilterLigacoes) => Promise<ILigacoes[]>;
  getAll: (filtro?: FilterLigacoes) => Promise<ILigacoes[]>;
  deleteLigacoes: (id: number) => Promise<void>;
  validateLigacoes: (ligacoes: ILigacoes) => { isValid: boolean; errors: string[] };
}

export class LigacoesService implements ILigacoesService {
  constructor(private api: LigacoesApi) {}

  async fetchLigacoesById(id: number): Promise<ILigacoes> {
    if (id <= 0) {
      throw new LigacoesApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof LigacoesApiError) {
        throw error;
      }
      throw new LigacoesApiError('Erro ao buscar ligacoes', 500, 'FETCH_ERROR', error);
    }
  }

  async saveLigacoes(ligacoes: ILigacoes): Promise<ILigacoes> {    
    const validation = this.validateLigacoes(ligacoes);
    if (!validation.isValid) {
      throw new LigacoesApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(ligacoes);
      return response.data;
    } catch (error) {
      if (error instanceof LigacoesApiError) {
        throw error;
      }
      throw new LigacoesApiError('Erro ao salvar ligacoes', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterLigacoes): Promise<ILigacoes[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching ligacoes list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterLigacoes): Promise<ILigacoes[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all ligacoes:', error);
      return [];
    }
  }

  async deleteLigacoes(id: number): Promise<void> {
    if (id <= 0) {
      throw new LigacoesApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof LigacoesApiError) {
        throw error;
      }
      throw new LigacoesApiError('Erro ao excluir ligacoes', 500, 'DELETE_ERROR', error);
    }
  }

  validateLigacoes(ligacoes: ILigacoes): { isValid: boolean; errors: string[] } {
    return LigacoesValidator.validateLigacoes(ligacoes);
  }
}