'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ViaRecebimentoApi, ViaRecebimentoApiError } from '../Apis/ApiViaRecebimento';
import { FilterViaRecebimento } from '../Filters/ViaRecebimento';
import { IViaRecebimento } from '../Interfaces/interface.ViaRecebimento';
import { ViaRecebimentoEmpty } from '../../Models/ViaRecebimento';

export class ViaRecebimentoValidator {
  static validateViaRecebimento(viarecebimento: IViaRecebimento): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IViaRecebimentoService {
  fetchViaRecebimentoById: (id: number) => Promise<IViaRecebimento>;
  saveViaRecebimento: (viarecebimento: IViaRecebimento) => Promise<IViaRecebimento>;  
  getList: (filtro?: FilterViaRecebimento) => Promise<IViaRecebimento[]>;
  getAll: (filtro?: FilterViaRecebimento) => Promise<IViaRecebimento[]>;
  deleteViaRecebimento: (id: number) => Promise<void>;
  validateViaRecebimento: (viarecebimento: IViaRecebimento) => { isValid: boolean; errors: string[] };
}

export class ViaRecebimentoService implements IViaRecebimentoService {
  constructor(private api: ViaRecebimentoApi) {}

  async fetchViaRecebimentoById(id: number): Promise<IViaRecebimento> {
    if (id <= 0) {
      throw new ViaRecebimentoApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof ViaRecebimentoApiError) {
        throw error;
      }
      throw new ViaRecebimentoApiError('Erro ao buscar viarecebimento', 500, 'FETCH_ERROR', error);
    }
  }

  async saveViaRecebimento(viarecebimento: IViaRecebimento): Promise<IViaRecebimento> {    
    const validation = this.validateViaRecebimento(viarecebimento);
    if (!validation.isValid) {
      throw new ViaRecebimentoApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(viarecebimento);
      return response.data;
    } catch (error) {
      if (error instanceof ViaRecebimentoApiError) {
        throw error;
      }
      throw new ViaRecebimentoApiError('Erro ao salvar viarecebimento', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterViaRecebimento): Promise<IViaRecebimento[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching viarecebimento list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterViaRecebimento): Promise<IViaRecebimento[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all viarecebimento:', error);
      return [];
    }
  }

  async deleteViaRecebimento(id: number): Promise<void> {
    if (id <= 0) {
      throw new ViaRecebimentoApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ViaRecebimentoApiError) {
        throw error;
      }
      throw new ViaRecebimentoApiError('Erro ao excluir viarecebimento', 500, 'DELETE_ERROR', error);
    }
  }

  validateViaRecebimento(viarecebimento: IViaRecebimento): { isValid: boolean; errors: string[] } {
    return ViaRecebimentoValidator.validateViaRecebimento(viarecebimento);
  }
}