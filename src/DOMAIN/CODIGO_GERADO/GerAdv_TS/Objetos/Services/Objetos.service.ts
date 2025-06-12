'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ObjetosApi, ObjetosApiError } from '../Apis/ApiObjetos';
import { FilterObjetos } from '../Filters/Objetos';
import { IObjetos } from '../Interfaces/interface.Objetos';

export class ObjetosValidator {
  static validateObjetos(objetos: IObjetos): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IObjetosService {
  fetchObjetosById: (id: number) => Promise<IObjetos>;
  saveObjetos: (objetos: IObjetos) => Promise<IObjetos>;  
  getList: (filtro?: FilterObjetos) => Promise<IObjetos[]>;
  getAll: (filtro?: FilterObjetos) => Promise<IObjetos[]>;
  deleteObjetos: (id: number) => Promise<void>;
  validateObjetos: (objetos: IObjetos) => { isValid: boolean; errors: string[] };
}

export class ObjetosService implements IObjetosService {
  constructor(private api: ObjetosApi) {}

  async fetchObjetosById(id: number): Promise<IObjetos> {
    if (id <= 0) {
      throw new ObjetosApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof ObjetosApiError) {
        throw error;
      }
      throw new ObjetosApiError('Erro ao buscar objetos', 500, 'FETCH_ERROR', error);
    }
  }

  async saveObjetos(objetos: IObjetos): Promise<IObjetos> {    
    const validation = this.validateObjetos(objetos);
    if (!validation.isValid) {
      throw new ObjetosApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(objetos);
      return response.data;
    } catch (error) {
      if (error instanceof ObjetosApiError) {
        throw error;
      }
      throw new ObjetosApiError('Erro ao salvar objetos', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterObjetos): Promise<IObjetos[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching objetos list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterObjetos): Promise<IObjetos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all objetos:', error);
      return [];
    }
  }

  async deleteObjetos(id: number): Promise<void> {
    if (id <= 0) {
      throw new ObjetosApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ObjetosApiError) {
        throw error;
      }
      throw new ObjetosApiError('Erro ao excluir objetos', 500, 'DELETE_ERROR', error);
    }
  }

  validateObjetos(objetos: IObjetos): { isValid: boolean; errors: string[] } {
    return ObjetosValidator.validateObjetos(objetos);
  }
}