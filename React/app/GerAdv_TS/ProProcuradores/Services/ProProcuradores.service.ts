'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ProProcuradoresApi, ProProcuradoresApiError } from '../Apis/ApiProProcuradores';
import { FilterProProcuradores } from '../Filters/ProProcuradores';
import { IProProcuradores } from '../Interfaces/interface.ProProcuradores';

export class ProProcuradoresValidator {
  static validateProProcuradores(proprocuradores: IProProcuradores): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IProProcuradoresService {
  fetchProProcuradoresById: (id: number) => Promise<IProProcuradores>;
  saveProProcuradores: (proprocuradores: IProProcuradores) => Promise<IProProcuradores>;  
  getList: (filtro?: FilterProProcuradores) => Promise<IProProcuradores[]>;
  getAll: (filtro?: FilterProProcuradores) => Promise<IProProcuradores[]>;
  deleteProProcuradores: (id: number) => Promise<void>;
  validateProProcuradores: (proprocuradores: IProProcuradores) => { isValid: boolean; errors: string[] };
}

export class ProProcuradoresService implements IProProcuradoresService {
  constructor(private api: ProProcuradoresApi) {}

  async fetchProProcuradoresById(id: number): Promise<IProProcuradores> {
    if (id <= 0) {
      throw new ProProcuradoresApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof ProProcuradoresApiError) {
        throw error;
      }
      throw new ProProcuradoresApiError('Erro ao buscar proprocuradores', 500, 'FETCH_ERROR', error);
    }
  }

  async saveProProcuradores(proprocuradores: IProProcuradores): Promise<IProProcuradores> {    
    const validation = this.validateProProcuradores(proprocuradores);
    if (!validation.isValid) {
      throw new ProProcuradoresApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(proprocuradores);
      return response.data;
    } catch (error) {
      if (error instanceof ProProcuradoresApiError) {
        throw error;
      }
      throw new ProProcuradoresApiError('Erro ao salvar proprocuradores', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterProProcuradores): Promise<IProProcuradores[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching proprocuradores list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterProProcuradores): Promise<IProProcuradores[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all proprocuradores:', error);
      return [];
    }
  }

  async deleteProProcuradores(id: number): Promise<void> {
    if (id <= 0) {
      throw new ProProcuradoresApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ProProcuradoresApiError) {
        throw error;
      }
      throw new ProProcuradoresApiError('Erro ao excluir proprocuradores', 500, 'DELETE_ERROR', error);
    }
  }

  validateProProcuradores(proprocuradores: IProProcuradores): { isValid: boolean; errors: string[] } {
    return ProProcuradoresValidator.validateProProcuradores(proprocuradores);
  }
}