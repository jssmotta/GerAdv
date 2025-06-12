'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { TipoEnderecoApi, TipoEnderecoApiError } from '../Apis/ApiTipoEndereco';
import { FilterTipoEndereco } from '../Filters/TipoEndereco';
import { ITipoEndereco } from '../Interfaces/interface.TipoEndereco';

export class TipoEnderecoValidator {
  static validateTipoEndereco(tipoendereco: ITipoEndereco): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface ITipoEnderecoService {
  fetchTipoEnderecoById: (id: number) => Promise<ITipoEndereco>;
  saveTipoEndereco: (tipoendereco: ITipoEndereco) => Promise<ITipoEndereco>;  
  getList: (filtro?: FilterTipoEndereco) => Promise<ITipoEndereco[]>;
  getAll: (filtro?: FilterTipoEndereco) => Promise<ITipoEndereco[]>;
  deleteTipoEndereco: (id: number) => Promise<void>;
  validateTipoEndereco: (tipoendereco: ITipoEndereco) => { isValid: boolean; errors: string[] };
}

export class TipoEnderecoService implements ITipoEnderecoService {
  constructor(private api: TipoEnderecoApi) {}

  async fetchTipoEnderecoById(id: number): Promise<ITipoEndereco> {
    if (id <= 0) {
      throw new TipoEnderecoApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof TipoEnderecoApiError) {
        throw error;
      }
      throw new TipoEnderecoApiError('Erro ao buscar tipoendereco', 500, 'FETCH_ERROR', error);
    }
  }

  async saveTipoEndereco(tipoendereco: ITipoEndereco): Promise<ITipoEndereco> {    
    const validation = this.validateTipoEndereco(tipoendereco);
    if (!validation.isValid) {
      throw new TipoEnderecoApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(tipoendereco);
      return response.data;
    } catch (error) {
      if (error instanceof TipoEnderecoApiError) {
        throw error;
      }
      throw new TipoEnderecoApiError('Erro ao salvar tipoendereco', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterTipoEndereco): Promise<ITipoEndereco[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching tipoendereco list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterTipoEndereco): Promise<ITipoEndereco[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all tipoendereco:', error);
      return [];
    }
  }

  async deleteTipoEndereco(id: number): Promise<void> {
    if (id <= 0) {
      throw new TipoEnderecoApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof TipoEnderecoApiError) {
        throw error;
      }
      throw new TipoEnderecoApiError('Erro ao excluir tipoendereco', 500, 'DELETE_ERROR', error);
    }
  }

  validateTipoEndereco(tipoendereco: ITipoEndereco): { isValid: boolean; errors: string[] } {
    return TipoEnderecoValidator.validateTipoEndereco(tipoendereco);
  }
}