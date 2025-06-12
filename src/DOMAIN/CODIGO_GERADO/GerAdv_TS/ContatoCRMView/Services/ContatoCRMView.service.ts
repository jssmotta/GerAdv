'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ContatoCRMViewApi, ContatoCRMViewApiError } from '../Apis/ApiContatoCRMView';
import { FilterContatoCRMView } from '../Filters/ContatoCRMView';
import { IContatoCRMView } from '../Interfaces/interface.ContatoCRMView';

export class ContatoCRMViewValidator {
  static validateContatoCRMView(contatocrmview: IContatoCRMView): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IContatoCRMViewService {
  fetchContatoCRMViewById: (id: number) => Promise<IContatoCRMView>;
  saveContatoCRMView: (contatocrmview: IContatoCRMView) => Promise<IContatoCRMView>;  
  
  getAll: (filtro?: FilterContatoCRMView) => Promise<IContatoCRMView[]>;
  deleteContatoCRMView: (id: number) => Promise<void>;
  validateContatoCRMView: (contatocrmview: IContatoCRMView) => { isValid: boolean; errors: string[] };
}

export class ContatoCRMViewService implements IContatoCRMViewService {
  constructor(private api: ContatoCRMViewApi) {}

  async fetchContatoCRMViewById(id: number): Promise<IContatoCRMView> {
    if (id <= 0) {
      throw new ContatoCRMViewApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof ContatoCRMViewApiError) {
        throw error;
      }
      throw new ContatoCRMViewApiError('Erro ao buscar contatocrmview', 500, 'FETCH_ERROR', error);
    }
  }

  async saveContatoCRMView(contatocrmview: IContatoCRMView): Promise<IContatoCRMView> {    
    const validation = this.validateContatoCRMView(contatocrmview);
    if (!validation.isValid) {
      throw new ContatoCRMViewApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(contatocrmview);
      return response.data;
    } catch (error) {
      if (error instanceof ContatoCRMViewApiError) {
        throw error;
      }
      throw new ContatoCRMViewApiError('Erro ao salvar contatocrmview', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterContatoCRMView): Promise<IContatoCRMView[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all contatocrmview:', error);
      return [];
    }
  }

  async deleteContatoCRMView(id: number): Promise<void> {
    if (id <= 0) {
      throw new ContatoCRMViewApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ContatoCRMViewApiError) {
        throw error;
      }
      throw new ContatoCRMViewApiError('Erro ao excluir contatocrmview', 500, 'DELETE_ERROR', error);
    }
  }

  validateContatoCRMView(contatocrmview: IContatoCRMView): { isValid: boolean; errors: string[] } {
    return ContatoCRMViewValidator.validateContatoCRMView(contatocrmview);
  }
}