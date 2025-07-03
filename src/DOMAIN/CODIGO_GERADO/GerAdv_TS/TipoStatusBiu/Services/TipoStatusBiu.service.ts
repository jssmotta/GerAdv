'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { TipoStatusBiuApi, TipoStatusBiuApiError } from '../Apis/ApiTipoStatusBiu';
import { FilterTipoStatusBiu } from '../Filters/TipoStatusBiu';
import { ITipoStatusBiu } from '../Interfaces/interface.TipoStatusBiu';
import { TipoStatusBiuEmpty } from '../../Models/TipoStatusBiu';

export class TipoStatusBiuValidator {
  static validateTipoStatusBiu(tipostatusbiu: ITipoStatusBiu): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface ITipoStatusBiuService {
  fetchTipoStatusBiuById: (id: number) => Promise<ITipoStatusBiu>;
  saveTipoStatusBiu: (tipostatusbiu: ITipoStatusBiu) => Promise<ITipoStatusBiu>;  
  getList: (filtro?: FilterTipoStatusBiu) => Promise<ITipoStatusBiu[]>;
  getAll: (filtro?: FilterTipoStatusBiu) => Promise<ITipoStatusBiu[]>;
  deleteTipoStatusBiu: (id: number) => Promise<void>;
  validateTipoStatusBiu: (tipostatusbiu: ITipoStatusBiu) => { isValid: boolean; errors: string[] };
}

export class TipoStatusBiuService implements ITipoStatusBiuService {
  constructor(private api: TipoStatusBiuApi) {}

  async fetchTipoStatusBiuById(id: number): Promise<ITipoStatusBiu> {
    if (id <= 0) {
      throw new TipoStatusBiuApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof TipoStatusBiuApiError) {
        throw error;
      }
      throw new TipoStatusBiuApiError('Erro ao buscar tipostatusbiu', 500, 'FETCH_ERROR', error);
    }
  }

  async saveTipoStatusBiu(tipostatusbiu: ITipoStatusBiu): Promise<ITipoStatusBiu> {    
    const validation = this.validateTipoStatusBiu(tipostatusbiu);
    if (!validation.isValid) {
      throw new TipoStatusBiuApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(tipostatusbiu);
      return response.data;
    } catch (error) {
      if (error instanceof TipoStatusBiuApiError) {
        throw error;
      }
      throw new TipoStatusBiuApiError('Erro ao salvar tipostatusbiu', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterTipoStatusBiu): Promise<ITipoStatusBiu[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching tipostatusbiu list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterTipoStatusBiu): Promise<ITipoStatusBiu[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all tipostatusbiu:', error);
      return [];
    }
  }

  async deleteTipoStatusBiu(id: number): Promise<void> {
    if (id <= 0) {
      throw new TipoStatusBiuApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof TipoStatusBiuApiError) {
        throw error;
      }
      throw new TipoStatusBiuApiError('Erro ao excluir tipostatusbiu', 500, 'DELETE_ERROR', error);
    }
  }

  validateTipoStatusBiu(tipostatusbiu: ITipoStatusBiu): { isValid: boolean; errors: string[] } {
    return TipoStatusBiuValidator.validateTipoStatusBiu(tipostatusbiu);
  }
}