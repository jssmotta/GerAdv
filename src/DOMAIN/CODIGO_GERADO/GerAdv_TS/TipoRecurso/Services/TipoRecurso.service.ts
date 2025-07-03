'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { TipoRecursoApi, TipoRecursoApiError } from '../Apis/ApiTipoRecurso';
import { FilterTipoRecurso } from '../Filters/TipoRecurso';
import { ITipoRecurso } from '../Interfaces/interface.TipoRecurso';
import { TipoRecursoEmpty } from '../../Models/TipoRecurso';

export class TipoRecursoValidator {
  static validateTipoRecurso(tiporecurso: ITipoRecurso): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface ITipoRecursoService {
  fetchTipoRecursoById: (id: number) => Promise<ITipoRecurso>;
  saveTipoRecurso: (tiporecurso: ITipoRecurso) => Promise<ITipoRecurso>;  
  getList: (filtro?: FilterTipoRecurso) => Promise<ITipoRecurso[]>;
  getAll: (filtro?: FilterTipoRecurso) => Promise<ITipoRecurso[]>;
  deleteTipoRecurso: (id: number) => Promise<void>;
  validateTipoRecurso: (tiporecurso: ITipoRecurso) => { isValid: boolean; errors: string[] };
}

export class TipoRecursoService implements ITipoRecursoService {
  constructor(private api: TipoRecursoApi) {}

  async fetchTipoRecursoById(id: number): Promise<ITipoRecurso> {
    if (id <= 0) {
      throw new TipoRecursoApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof TipoRecursoApiError) {
        throw error;
      }
      throw new TipoRecursoApiError('Erro ao buscar tiporecurso', 500, 'FETCH_ERROR', error);
    }
  }

  async saveTipoRecurso(tiporecurso: ITipoRecurso): Promise<ITipoRecurso> {    
    const validation = this.validateTipoRecurso(tiporecurso);
    if (!validation.isValid) {
      throw new TipoRecursoApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(tiporecurso);
      return response.data;
    } catch (error) {
      if (error instanceof TipoRecursoApiError) {
        throw error;
      }
      throw new TipoRecursoApiError('Erro ao salvar tiporecurso', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterTipoRecurso): Promise<ITipoRecurso[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching tiporecurso list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterTipoRecurso): Promise<ITipoRecurso[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all tiporecurso:', error);
      return [];
    }
  }

  async deleteTipoRecurso(id: number): Promise<void> {
    if (id <= 0) {
      throw new TipoRecursoApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof TipoRecursoApiError) {
        throw error;
      }
      throw new TipoRecursoApiError('Erro ao excluir tiporecurso', 500, 'DELETE_ERROR', error);
    }
  }

  validateTipoRecurso(tiporecurso: ITipoRecurso): { isValid: boolean; errors: string[] } {
    return TipoRecursoValidator.validateTipoRecurso(tiporecurso);
  }
}