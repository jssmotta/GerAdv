'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { TipoProDespositoApi, TipoProDespositoApiError } from '../Apis/ApiTipoProDesposito';
import { FilterTipoProDesposito } from '../Filters/TipoProDesposito';
import { ITipoProDesposito } from '../Interfaces/interface.TipoProDesposito';

export class TipoProDespositoValidator {
  static validateTipoProDesposito(tipoprodesposito: ITipoProDesposito): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface ITipoProDespositoService {
  fetchTipoProDespositoById: (id: number) => Promise<ITipoProDesposito>;
  saveTipoProDesposito: (tipoprodesposito: ITipoProDesposito) => Promise<ITipoProDesposito>;  
  getList: (filtro?: FilterTipoProDesposito) => Promise<ITipoProDesposito[]>;
  getAll: (filtro?: FilterTipoProDesposito) => Promise<ITipoProDesposito[]>;
  deleteTipoProDesposito: (id: number) => Promise<void>;
  validateTipoProDesposito: (tipoprodesposito: ITipoProDesposito) => { isValid: boolean; errors: string[] };
}

export class TipoProDespositoService implements ITipoProDespositoService {
  constructor(private api: TipoProDespositoApi) {}

  async fetchTipoProDespositoById(id: number): Promise<ITipoProDesposito> {
    if (id <= 0) {
      throw new TipoProDespositoApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof TipoProDespositoApiError) {
        throw error;
      }
      throw new TipoProDespositoApiError('Erro ao buscar tipoprodesposito', 500, 'FETCH_ERROR', error);
    }
  }

  async saveTipoProDesposito(tipoprodesposito: ITipoProDesposito): Promise<ITipoProDesposito> {    
    const validation = this.validateTipoProDesposito(tipoprodesposito);
    if (!validation.isValid) {
      throw new TipoProDespositoApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(tipoprodesposito);
      return response.data;
    } catch (error) {
      if (error instanceof TipoProDespositoApiError) {
        throw error;
      }
      throw new TipoProDespositoApiError('Erro ao salvar tipoprodesposito', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterTipoProDesposito): Promise<ITipoProDesposito[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching tipoprodesposito list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterTipoProDesposito): Promise<ITipoProDesposito[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all tipoprodesposito:', error);
      return [];
    }
  }

  async deleteTipoProDesposito(id: number): Promise<void> {
    if (id <= 0) {
      throw new TipoProDespositoApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof TipoProDespositoApiError) {
        throw error;
      }
      throw new TipoProDespositoApiError('Erro ao excluir tipoprodesposito', 500, 'DELETE_ERROR', error);
    }
  }

  validateTipoProDesposito(tipoprodesposito: ITipoProDesposito): { isValid: boolean; errors: string[] } {
    return TipoProDespositoValidator.validateTipoProDesposito(tipoprodesposito);
  }
}