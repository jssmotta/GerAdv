'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ProDepositosApi, ProDepositosApiError } from '../Apis/ApiProDepositos';
import { FilterProDepositos } from '../Filters/ProDepositos';
import { IProDepositos } from '../Interfaces/interface.ProDepositos';

export class ProDepositosValidator {
  static validateProDepositos(prodepositos: IProDepositos): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IProDepositosService {
  fetchProDepositosById: (id: number) => Promise<IProDepositos>;
  saveProDepositos: (prodepositos: IProDepositos) => Promise<IProDepositos>;  
  
  getAll: (filtro?: FilterProDepositos) => Promise<IProDepositos[]>;
  deleteProDepositos: (id: number) => Promise<void>;
  validateProDepositos: (prodepositos: IProDepositos) => { isValid: boolean; errors: string[] };
}

export class ProDepositosService implements IProDepositosService {
  constructor(private api: ProDepositosApi) {}

  async fetchProDepositosById(id: number): Promise<IProDepositos> {
    if (id <= 0) {
      throw new ProDepositosApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof ProDepositosApiError) {
        throw error;
      }
      throw new ProDepositosApiError('Erro ao buscar prodepositos', 500, 'FETCH_ERROR', error);
    }
  }

  async saveProDepositos(prodepositos: IProDepositos): Promise<IProDepositos> {    
    const validation = this.validateProDepositos(prodepositos);
    if (!validation.isValid) {
      throw new ProDepositosApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(prodepositos);
      return response.data;
    } catch (error) {
      if (error instanceof ProDepositosApiError) {
        throw error;
      }
      throw new ProDepositosApiError('Erro ao salvar prodepositos', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterProDepositos): Promise<IProDepositos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all prodepositos:', error);
      return [];
    }
  }

  async deleteProDepositos(id: number): Promise<void> {
    if (id <= 0) {
      throw new ProDepositosApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ProDepositosApiError) {
        throw error;
      }
      throw new ProDepositosApiError('Erro ao excluir prodepositos', 500, 'DELETE_ERROR', error);
    }
  }

  validateProDepositos(prodepositos: IProDepositos): { isValid: boolean; errors: string[] } {
    return ProDepositosValidator.validateProDepositos(prodepositos);
  }
}