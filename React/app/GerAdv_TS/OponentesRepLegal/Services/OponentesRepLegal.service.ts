'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { OponentesRepLegalApi, OponentesRepLegalApiError } from '../Apis/ApiOponentesRepLegal';
import { FilterOponentesRepLegal } from '../Filters/OponentesRepLegal';
import { IOponentesRepLegal } from '../Interfaces/interface.OponentesRepLegal';

export class OponentesRepLegalValidator {
  static validateOponentesRepLegal(oponentesreplegal: IOponentesRepLegal): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IOponentesRepLegalService {
  fetchOponentesRepLegalById: (id: number) => Promise<IOponentesRepLegal>;
  saveOponentesRepLegal: (oponentesreplegal: IOponentesRepLegal) => Promise<IOponentesRepLegal>;  
  getList: (filtro?: FilterOponentesRepLegal) => Promise<IOponentesRepLegal[]>;
  getAll: (filtro?: FilterOponentesRepLegal) => Promise<IOponentesRepLegal[]>;
  deleteOponentesRepLegal: (id: number) => Promise<void>;
  validateOponentesRepLegal: (oponentesreplegal: IOponentesRepLegal) => { isValid: boolean; errors: string[] };
}

export class OponentesRepLegalService implements IOponentesRepLegalService {
  constructor(private api: OponentesRepLegalApi) {}

  async fetchOponentesRepLegalById(id: number): Promise<IOponentesRepLegal> {
    if (id <= 0) {
      throw new OponentesRepLegalApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof OponentesRepLegalApiError) {
        throw error;
      }
      throw new OponentesRepLegalApiError('Erro ao buscar oponentesreplegal', 500, 'FETCH_ERROR', error);
    }
  }

  async saveOponentesRepLegal(oponentesreplegal: IOponentesRepLegal): Promise<IOponentesRepLegal> {    
    const validation = this.validateOponentesRepLegal(oponentesreplegal);
    if (!validation.isValid) {
      throw new OponentesRepLegalApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(oponentesreplegal);
      return response.data;
    } catch (error) {
      if (error instanceof OponentesRepLegalApiError) {
        throw error;
      }
      throw new OponentesRepLegalApiError('Erro ao salvar oponentesreplegal', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterOponentesRepLegal): Promise<IOponentesRepLegal[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching oponentesreplegal list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterOponentesRepLegal): Promise<IOponentesRepLegal[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all oponentesreplegal:', error);
      return [];
    }
  }

  async deleteOponentesRepLegal(id: number): Promise<void> {
    if (id <= 0) {
      throw new OponentesRepLegalApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof OponentesRepLegalApiError) {
        throw error;
      }
      throw new OponentesRepLegalApiError('Erro ao excluir oponentesreplegal', 500, 'DELETE_ERROR', error);
    }
  }

  validateOponentesRepLegal(oponentesreplegal: IOponentesRepLegal): { isValid: boolean; errors: string[] } {
    return OponentesRepLegalValidator.validateOponentesRepLegal(oponentesreplegal);
  }
}