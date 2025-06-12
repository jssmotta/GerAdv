'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ContatoCRMOperadorApi, ContatoCRMOperadorApiError } from '../Apis/ApiContatoCRMOperador';
import { FilterContatoCRMOperador } from '../Filters/ContatoCRMOperador';
import { IContatoCRMOperador } from '../Interfaces/interface.ContatoCRMOperador';

export class ContatoCRMOperadorValidator {
  static validateContatoCRMOperador(contatocrmoperador: IContatoCRMOperador): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IContatoCRMOperadorService {
  fetchContatoCRMOperadorById: (id: number) => Promise<IContatoCRMOperador>;
  saveContatoCRMOperador: (contatocrmoperador: IContatoCRMOperador) => Promise<IContatoCRMOperador>;  
  
  getAll: (filtro?: FilterContatoCRMOperador) => Promise<IContatoCRMOperador[]>;
  deleteContatoCRMOperador: (id: number) => Promise<void>;
  validateContatoCRMOperador: (contatocrmoperador: IContatoCRMOperador) => { isValid: boolean; errors: string[] };
}

export class ContatoCRMOperadorService implements IContatoCRMOperadorService {
  constructor(private api: ContatoCRMOperadorApi) {}

  async fetchContatoCRMOperadorById(id: number): Promise<IContatoCRMOperador> {
    if (id <= 0) {
      throw new ContatoCRMOperadorApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof ContatoCRMOperadorApiError) {
        throw error;
      }
      throw new ContatoCRMOperadorApiError('Erro ao buscar contatocrmoperador', 500, 'FETCH_ERROR', error);
    }
  }

  async saveContatoCRMOperador(contatocrmoperador: IContatoCRMOperador): Promise<IContatoCRMOperador> {    
    const validation = this.validateContatoCRMOperador(contatocrmoperador);
    if (!validation.isValid) {
      throw new ContatoCRMOperadorApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(contatocrmoperador);
      return response.data;
    } catch (error) {
      if (error instanceof ContatoCRMOperadorApiError) {
        throw error;
      }
      throw new ContatoCRMOperadorApiError('Erro ao salvar contatocrmoperador', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterContatoCRMOperador): Promise<IContatoCRMOperador[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all contatocrmoperador:', error);
      return [];
    }
  }

  async deleteContatoCRMOperador(id: number): Promise<void> {
    if (id <= 0) {
      throw new ContatoCRMOperadorApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ContatoCRMOperadorApiError) {
        throw error;
      }
      throw new ContatoCRMOperadorApiError('Erro ao excluir contatocrmoperador', 500, 'DELETE_ERROR', error);
    }
  }

  validateContatoCRMOperador(contatocrmoperador: IContatoCRMOperador): { isValid: boolean; errors: string[] } {
    return ContatoCRMOperadorValidator.validateContatoCRMOperador(contatocrmoperador);
  }
}