'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { OponentesApi, OponentesApiError } from '../Apis/ApiOponentes';
import { FilterOponentes } from '../Filters/Oponentes';
import { IOponentes } from '../Interfaces/interface.Oponentes';

export class OponentesValidator {
  static validateOponentes(oponentes: IOponentes): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IOponentesService {
  fetchOponentesById: (id: number) => Promise<IOponentes>;
  saveOponentes: (oponentes: IOponentes) => Promise<IOponentes>;  
  getList: (filtro?: FilterOponentes) => Promise<IOponentes[]>;
  getAll: (filtro?: FilterOponentes) => Promise<IOponentes[]>;
  deleteOponentes: (id: number) => Promise<void>;
  validateOponentes: (oponentes: IOponentes) => { isValid: boolean; errors: string[] };
}

export class OponentesService implements IOponentesService {
  constructor(private api: OponentesApi) {}

  async fetchOponentesById(id: number): Promise<IOponentes> {
    if (id <= 0) {
      throw new OponentesApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof OponentesApiError) {
        throw error;
      }
      throw new OponentesApiError('Erro ao buscar oponentes', 500, 'FETCH_ERROR', error);
    }
  }

  async saveOponentes(oponentes: IOponentes): Promise<IOponentes> {    
    const validation = this.validateOponentes(oponentes);
    if (!validation.isValid) {
      throw new OponentesApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(oponentes);
      return response.data;
    } catch (error) {
      if (error instanceof OponentesApiError) {
        throw error;
      }
      throw new OponentesApiError('Erro ao salvar oponentes', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterOponentes): Promise<IOponentes[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching oponentes list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterOponentes): Promise<IOponentes[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all oponentes:', error);
      return [];
    }
  }

  async deleteOponentes(id: number): Promise<void> {
    if (id <= 0) {
      throw new OponentesApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof OponentesApiError) {
        throw error;
      }
      throw new OponentesApiError('Erro ao excluir oponentes', 500, 'DELETE_ERROR', error);
    }
  }

  validateOponentes(oponentes: IOponentes): { isValid: boolean; errors: string[] } {
    return OponentesValidator.validateOponentes(oponentes);
  }
}