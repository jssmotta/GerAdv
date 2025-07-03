'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { TipoCompromissoApi, TipoCompromissoApiError } from '../Apis/ApiTipoCompromisso';
import { FilterTipoCompromisso } from '../Filters/TipoCompromisso';
import { ITipoCompromisso } from '../Interfaces/interface.TipoCompromisso';
import { TipoCompromissoEmpty } from '../../Models/TipoCompromisso';

export class TipoCompromissoValidator {
  static validateTipoCompromisso(tipocompromisso: ITipoCompromisso): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface ITipoCompromissoService {
  fetchTipoCompromissoById: (id: number) => Promise<ITipoCompromisso>;
  saveTipoCompromisso: (tipocompromisso: ITipoCompromisso) => Promise<ITipoCompromisso>;  
  getList: (filtro?: FilterTipoCompromisso) => Promise<ITipoCompromisso[]>;
  getAll: (filtro?: FilterTipoCompromisso) => Promise<ITipoCompromisso[]>;
  deleteTipoCompromisso: (id: number) => Promise<void>;
  validateTipoCompromisso: (tipocompromisso: ITipoCompromisso) => { isValid: boolean; errors: string[] };
}

export class TipoCompromissoService implements ITipoCompromissoService {
  constructor(private api: TipoCompromissoApi) {}

  async fetchTipoCompromissoById(id: number): Promise<ITipoCompromisso> {
    if (id <= 0) {
      throw new TipoCompromissoApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof TipoCompromissoApiError) {
        throw error;
      }
      throw new TipoCompromissoApiError('Erro ao buscar tipocompromisso', 500, 'FETCH_ERROR', error);
    }
  }

  async saveTipoCompromisso(tipocompromisso: ITipoCompromisso): Promise<ITipoCompromisso> {    
    const validation = this.validateTipoCompromisso(tipocompromisso);
    if (!validation.isValid) {
      throw new TipoCompromissoApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(tipocompromisso);
      return response.data;
    } catch (error) {
      if (error instanceof TipoCompromissoApiError) {
        throw error;
      }
      throw new TipoCompromissoApiError('Erro ao salvar tipocompromisso', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterTipoCompromisso): Promise<ITipoCompromisso[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching tipocompromisso list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterTipoCompromisso): Promise<ITipoCompromisso[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all tipocompromisso:', error);
      return [];
    }
  }

  async deleteTipoCompromisso(id: number): Promise<void> {
    if (id <= 0) {
      throw new TipoCompromissoApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof TipoCompromissoApiError) {
        throw error;
      }
      throw new TipoCompromissoApiError('Erro ao excluir tipocompromisso', 500, 'DELETE_ERROR', error);
    }
  }

  validateTipoCompromisso(tipocompromisso: ITipoCompromisso): { isValid: boolean; errors: string[] } {
    return TipoCompromissoValidator.validateTipoCompromisso(tipocompromisso);
  }
}