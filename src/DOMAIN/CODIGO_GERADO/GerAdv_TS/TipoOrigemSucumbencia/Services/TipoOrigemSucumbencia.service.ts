'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { TipoOrigemSucumbenciaApi, TipoOrigemSucumbenciaApiError } from '../Apis/ApiTipoOrigemSucumbencia';
import { FilterTipoOrigemSucumbencia } from '../Filters/TipoOrigemSucumbencia';
import { ITipoOrigemSucumbencia } from '../Interfaces/interface.TipoOrigemSucumbencia';
import { TipoOrigemSucumbenciaEmpty } from '../../Models/TipoOrigemSucumbencia';

export class TipoOrigemSucumbenciaValidator {
  static validateTipoOrigemSucumbencia(tipoorigemsucumbencia: ITipoOrigemSucumbencia): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface ITipoOrigemSucumbenciaService {
  fetchTipoOrigemSucumbenciaById: (id: number) => Promise<ITipoOrigemSucumbencia>;
  saveTipoOrigemSucumbencia: (tipoorigemsucumbencia: ITipoOrigemSucumbencia) => Promise<ITipoOrigemSucumbencia>;  
  getList: (filtro?: FilterTipoOrigemSucumbencia) => Promise<ITipoOrigemSucumbencia[]>;
  getAll: (filtro?: FilterTipoOrigemSucumbencia) => Promise<ITipoOrigemSucumbencia[]>;
  deleteTipoOrigemSucumbencia: (id: number) => Promise<void>;
  validateTipoOrigemSucumbencia: (tipoorigemsucumbencia: ITipoOrigemSucumbencia) => { isValid: boolean; errors: string[] };
}

export class TipoOrigemSucumbenciaService implements ITipoOrigemSucumbenciaService {
  constructor(private api: TipoOrigemSucumbenciaApi) {}

  async fetchTipoOrigemSucumbenciaById(id: number): Promise<ITipoOrigemSucumbencia> {
    if (id <= 0) {
      throw new TipoOrigemSucumbenciaApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof TipoOrigemSucumbenciaApiError) {
        throw error;
      }
      throw new TipoOrigemSucumbenciaApiError('Erro ao buscar tipoorigemsucumbencia', 500, 'FETCH_ERROR', error);
    }
  }

  async saveTipoOrigemSucumbencia(tipoorigemsucumbencia: ITipoOrigemSucumbencia): Promise<ITipoOrigemSucumbencia> {    
    const validation = this.validateTipoOrigemSucumbencia(tipoorigemsucumbencia);
    if (!validation.isValid) {
      throw new TipoOrigemSucumbenciaApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(tipoorigemsucumbencia);
      return response.data;
    } catch (error) {
      if (error instanceof TipoOrigemSucumbenciaApiError) {
        throw error;
      }
      throw new TipoOrigemSucumbenciaApiError('Erro ao salvar tipoorigemsucumbencia', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterTipoOrigemSucumbencia): Promise<ITipoOrigemSucumbencia[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching tipoorigemsucumbencia list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterTipoOrigemSucumbencia): Promise<ITipoOrigemSucumbencia[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all tipoorigemsucumbencia:', error);
      return [];
    }
  }

  async deleteTipoOrigemSucumbencia(id: number): Promise<void> {
    if (id <= 0) {
      throw new TipoOrigemSucumbenciaApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof TipoOrigemSucumbenciaApiError) {
        throw error;
      }
      throw new TipoOrigemSucumbenciaApiError('Erro ao excluir tipoorigemsucumbencia', 500, 'DELETE_ERROR', error);
    }
  }

  validateTipoOrigemSucumbencia(tipoorigemsucumbencia: ITipoOrigemSucumbencia): { isValid: boolean; errors: string[] } {
    return TipoOrigemSucumbenciaValidator.validateTipoOrigemSucumbencia(tipoorigemsucumbencia);
  }
}