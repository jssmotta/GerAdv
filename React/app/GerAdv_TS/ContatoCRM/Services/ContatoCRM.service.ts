'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ContatoCRMApi, ContatoCRMApiError } from '../Apis/ApiContatoCRM';
import { FilterContatoCRM } from '../Filters/ContatoCRM';
import { IContatoCRM } from '../Interfaces/interface.ContatoCRM';

export class ContatoCRMValidator {
  static validateContatoCRM(contatocrm: IContatoCRM): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IContatoCRMService {
  fetchContatoCRMById: (id: number) => Promise<IContatoCRM>;
  saveContatoCRM: (contatocrm: IContatoCRM) => Promise<IContatoCRM>;  
  
  getAll: (filtro?: FilterContatoCRM) => Promise<IContatoCRM[]>;
  deleteContatoCRM: (id: number) => Promise<void>;
  validateContatoCRM: (contatocrm: IContatoCRM) => { isValid: boolean; errors: string[] };
}

export class ContatoCRMService implements IContatoCRMService {
  constructor(private api: ContatoCRMApi) {}

  async fetchContatoCRMById(id: number): Promise<IContatoCRM> {
    if (id <= 0) {
      throw new ContatoCRMApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof ContatoCRMApiError) {
        throw error;
      }
      throw new ContatoCRMApiError('Erro ao buscar contatocrm', 500, 'FETCH_ERROR', error);
    }
  }

  async saveContatoCRM(contatocrm: IContatoCRM): Promise<IContatoCRM> {    
    const validation = this.validateContatoCRM(contatocrm);
    if (!validation.isValid) {
      throw new ContatoCRMApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(contatocrm);
      return response.data;
    } catch (error) {
      if (error instanceof ContatoCRMApiError) {
        throw error;
      }
      throw new ContatoCRMApiError('Erro ao salvar contatocrm', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterContatoCRM): Promise<IContatoCRM[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all contatocrm:', error);
      return [];
    }
  }

  async deleteContatoCRM(id: number): Promise<void> {
    if (id <= 0) {
      throw new ContatoCRMApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ContatoCRMApiError) {
        throw error;
      }
      throw new ContatoCRMApiError('Erro ao excluir contatocrm', 500, 'DELETE_ERROR', error);
    }
  }

  validateContatoCRM(contatocrm: IContatoCRM): { isValid: boolean; errors: string[] } {
    return ContatoCRMValidator.validateContatoCRM(contatocrm);
  }
}