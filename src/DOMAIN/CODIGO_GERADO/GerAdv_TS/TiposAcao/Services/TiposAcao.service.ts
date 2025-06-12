'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { TiposAcaoApi, TiposAcaoApiError } from '../Apis/ApiTiposAcao';
import { FilterTiposAcao } from '../Filters/TiposAcao';
import { ITiposAcao } from '../Interfaces/interface.TiposAcao';

export class TiposAcaoValidator {
  static validateTiposAcao(tiposacao: ITiposAcao): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface ITiposAcaoService {
  fetchTiposAcaoById: (id: number) => Promise<ITiposAcao>;
  saveTiposAcao: (tiposacao: ITiposAcao) => Promise<ITiposAcao>;  
  getList: (filtro?: FilterTiposAcao) => Promise<ITiposAcao[]>;
  getAll: (filtro?: FilterTiposAcao) => Promise<ITiposAcao[]>;
  deleteTiposAcao: (id: number) => Promise<void>;
  validateTiposAcao: (tiposacao: ITiposAcao) => { isValid: boolean; errors: string[] };
}

export class TiposAcaoService implements ITiposAcaoService {
  constructor(private api: TiposAcaoApi) {}

  async fetchTiposAcaoById(id: number): Promise<ITiposAcao> {
    if (id <= 0) {
      throw new TiposAcaoApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof TiposAcaoApiError) {
        throw error;
      }
      throw new TiposAcaoApiError('Erro ao buscar tiposacao', 500, 'FETCH_ERROR', error);
    }
  }

  async saveTiposAcao(tiposacao: ITiposAcao): Promise<ITiposAcao> {    
    const validation = this.validateTiposAcao(tiposacao);
    if (!validation.isValid) {
      throw new TiposAcaoApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(tiposacao);
      return response.data;
    } catch (error) {
      if (error instanceof TiposAcaoApiError) {
        throw error;
      }
      throw new TiposAcaoApiError('Erro ao salvar tiposacao', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterTiposAcao): Promise<ITiposAcao[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching tiposacao list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterTiposAcao): Promise<ITiposAcao[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all tiposacao:', error);
      return [];
    }
  }

  async deleteTiposAcao(id: number): Promise<void> {
    if (id <= 0) {
      throw new TiposAcaoApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof TiposAcaoApiError) {
        throw error;
      }
      throw new TiposAcaoApiError('Erro ao excluir tiposacao', 500, 'DELETE_ERROR', error);
    }
  }

  validateTiposAcao(tiposacao: ITiposAcao): { isValid: boolean; errors: string[] } {
    return TiposAcaoValidator.validateTiposAcao(tiposacao);
  }
}