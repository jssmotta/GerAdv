'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { DocsRecebidosItensApi, DocsRecebidosItensApiError } from '../Apis/ApiDocsRecebidosItens';
import { FilterDocsRecebidosItens } from '../Filters/DocsRecebidosItens';
import { IDocsRecebidosItens } from '../Interfaces/interface.DocsRecebidosItens';

export class DocsRecebidosItensValidator {
  static validateDocsRecebidosItens(docsrecebidositens: IDocsRecebidosItens): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IDocsRecebidosItensService {
  fetchDocsRecebidosItensById: (id: number) => Promise<IDocsRecebidosItens>;
  saveDocsRecebidosItens: (docsrecebidositens: IDocsRecebidosItens) => Promise<IDocsRecebidosItens>;  
  getList: (filtro?: FilterDocsRecebidosItens) => Promise<IDocsRecebidosItens[]>;
  getAll: (filtro?: FilterDocsRecebidosItens) => Promise<IDocsRecebidosItens[]>;
  deleteDocsRecebidosItens: (id: number) => Promise<void>;
  validateDocsRecebidosItens: (docsrecebidositens: IDocsRecebidosItens) => { isValid: boolean; errors: string[] };
}

export class DocsRecebidosItensService implements IDocsRecebidosItensService {
  constructor(private api: DocsRecebidosItensApi) {}

  async fetchDocsRecebidosItensById(id: number): Promise<IDocsRecebidosItens> {
    if (id <= 0) {
      throw new DocsRecebidosItensApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof DocsRecebidosItensApiError) {
        throw error;
      }
      throw new DocsRecebidosItensApiError('Erro ao buscar docsrecebidositens', 500, 'FETCH_ERROR', error);
    }
  }

  async saveDocsRecebidosItens(docsrecebidositens: IDocsRecebidosItens): Promise<IDocsRecebidosItens> {    
    const validation = this.validateDocsRecebidosItens(docsrecebidositens);
    if (!validation.isValid) {
      throw new DocsRecebidosItensApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(docsrecebidositens);
      return response.data;
    } catch (error) {
      if (error instanceof DocsRecebidosItensApiError) {
        throw error;
      }
      throw new DocsRecebidosItensApiError('Erro ao salvar docsrecebidositens', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterDocsRecebidosItens): Promise<IDocsRecebidosItens[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching docsrecebidositens list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterDocsRecebidosItens): Promise<IDocsRecebidosItens[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all docsrecebidositens:', error);
      return [];
    }
  }

  async deleteDocsRecebidosItens(id: number): Promise<void> {
    if (id <= 0) {
      throw new DocsRecebidosItensApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof DocsRecebidosItensApiError) {
        throw error;
      }
      throw new DocsRecebidosItensApiError('Erro ao excluir docsrecebidositens', 500, 'DELETE_ERROR', error);
    }
  }

  validateDocsRecebidosItens(docsrecebidositens: IDocsRecebidosItens): { isValid: boolean; errors: string[] } {
    return DocsRecebidosItensValidator.validateDocsRecebidosItens(docsrecebidositens);
  }
}