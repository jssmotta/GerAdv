'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ServicosApi, ServicosApiError } from '../Apis/ApiServicos';
import { FilterServicos } from '../Filters/Servicos';
import { IServicos } from '../Interfaces/interface.Servicos';
import { ServicosEmpty } from '../../Models/Servicos';

export class ServicosValidator {
  static validateServicos(servicos: IServicos): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IServicosService {
  fetchServicosById: (id: number) => Promise<IServicos>;
  saveServicos: (servicos: IServicos) => Promise<IServicos>;  
  getList: (filtro?: FilterServicos) => Promise<IServicos[]>;
  getAll: (filtro?: FilterServicos) => Promise<IServicos[]>;
  deleteServicos: (id: number) => Promise<void>;
  validateServicos: (servicos: IServicos) => { isValid: boolean; errors: string[] };
}

export class ServicosService implements IServicosService {
  constructor(private api: ServicosApi) {}

  async fetchServicosById(id: number): Promise<IServicos> {
    if (id <= 0) {
      throw new ServicosApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof ServicosApiError) {
        throw error;
      }
      throw new ServicosApiError('Erro ao buscar servicos', 500, 'FETCH_ERROR', error);
    }
  }

  async saveServicos(servicos: IServicos): Promise<IServicos> {    
    const validation = this.validateServicos(servicos);
    if (!validation.isValid) {
      throw new ServicosApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(servicos);
      return response.data;
    } catch (error) {
      if (error instanceof ServicosApiError) {
        throw error;
      }
      throw new ServicosApiError('Erro ao salvar servicos', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterServicos): Promise<IServicos[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching servicos list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterServicos): Promise<IServicos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all servicos:', error);
      return [];
    }
  }

  async deleteServicos(id: number): Promise<void> {
    if (id <= 0) {
      throw new ServicosApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ServicosApiError) {
        throw error;
      }
      throw new ServicosApiError('Erro ao excluir servicos', 500, 'DELETE_ERROR', error);
    }
  }

  validateServicos(servicos: IServicos): { isValid: boolean; errors: string[] } {
    return ServicosValidator.validateServicos(servicos);
  }
}