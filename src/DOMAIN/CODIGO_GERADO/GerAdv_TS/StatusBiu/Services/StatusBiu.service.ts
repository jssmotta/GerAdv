'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { StatusBiuApi, StatusBiuApiError } from '../Apis/ApiStatusBiu';
import { FilterStatusBiu } from '../Filters/StatusBiu';
import { IStatusBiu } from '../Interfaces/interface.StatusBiu';

export class StatusBiuValidator {
  static validateStatusBiu(statusbiu: IStatusBiu): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IStatusBiuService {
  fetchStatusBiuById: (id: number) => Promise<IStatusBiu>;
  saveStatusBiu: (statusbiu: IStatusBiu) => Promise<IStatusBiu>;  
  getList: (filtro?: FilterStatusBiu) => Promise<IStatusBiu[]>;
  getAll: (filtro?: FilterStatusBiu) => Promise<IStatusBiu[]>;
  deleteStatusBiu: (id: number) => Promise<void>;
  validateStatusBiu: (statusbiu: IStatusBiu) => { isValid: boolean; errors: string[] };
}

export class StatusBiuService implements IStatusBiuService {
  constructor(private api: StatusBiuApi) {}

  async fetchStatusBiuById(id: number): Promise<IStatusBiu> {
    if (id <= 0) {
      throw new StatusBiuApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof StatusBiuApiError) {
        throw error;
      }
      throw new StatusBiuApiError('Erro ao buscar statusbiu', 500, 'FETCH_ERROR', error);
    }
  }

  async saveStatusBiu(statusbiu: IStatusBiu): Promise<IStatusBiu> {    
    const validation = this.validateStatusBiu(statusbiu);
    if (!validation.isValid) {
      throw new StatusBiuApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(statusbiu);
      return response.data;
    } catch (error) {
      if (error instanceof StatusBiuApiError) {
        throw error;
      }
      throw new StatusBiuApiError('Erro ao salvar statusbiu', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterStatusBiu): Promise<IStatusBiu[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching statusbiu list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterStatusBiu): Promise<IStatusBiu[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all statusbiu:', error);
      return [];
    }
  }

  async deleteStatusBiu(id: number): Promise<void> {
    if (id <= 0) {
      throw new StatusBiuApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof StatusBiuApiError) {
        throw error;
      }
      throw new StatusBiuApiError('Erro ao excluir statusbiu', 500, 'DELETE_ERROR', error);
    }
  }

  validateStatusBiu(statusbiu: IStatusBiu): { isValid: boolean; errors: string[] } {
    return StatusBiuValidator.validateStatusBiu(statusbiu);
  }
}