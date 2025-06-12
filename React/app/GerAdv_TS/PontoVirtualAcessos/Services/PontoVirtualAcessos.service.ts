'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { PontoVirtualAcessosApi, PontoVirtualAcessosApiError } from '../Apis/ApiPontoVirtualAcessos';
import { FilterPontoVirtualAcessos } from '../Filters/PontoVirtualAcessos';
import { IPontoVirtualAcessos } from '../Interfaces/interface.PontoVirtualAcessos';

export class PontoVirtualAcessosValidator {
  static validatePontoVirtualAcessos(pontovirtualacessos: IPontoVirtualAcessos): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IPontoVirtualAcessosService {
  fetchPontoVirtualAcessosById: (id: number) => Promise<IPontoVirtualAcessos>;
  savePontoVirtualAcessos: (pontovirtualacessos: IPontoVirtualAcessos) => Promise<IPontoVirtualAcessos>;  
  
  getAll: (filtro?: FilterPontoVirtualAcessos) => Promise<IPontoVirtualAcessos[]>;
  deletePontoVirtualAcessos: (id: number) => Promise<void>;
  validatePontoVirtualAcessos: (pontovirtualacessos: IPontoVirtualAcessos) => { isValid: boolean; errors: string[] };
}

export class PontoVirtualAcessosService implements IPontoVirtualAcessosService {
  constructor(private api: PontoVirtualAcessosApi) {}

  async fetchPontoVirtualAcessosById(id: number): Promise<IPontoVirtualAcessos> {
    if (id <= 0) {
      throw new PontoVirtualAcessosApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof PontoVirtualAcessosApiError) {
        throw error;
      }
      throw new PontoVirtualAcessosApiError('Erro ao buscar pontovirtualacessos', 500, 'FETCH_ERROR', error);
    }
  }

  async savePontoVirtualAcessos(pontovirtualacessos: IPontoVirtualAcessos): Promise<IPontoVirtualAcessos> {    
    const validation = this.validatePontoVirtualAcessos(pontovirtualacessos);
    if (!validation.isValid) {
      throw new PontoVirtualAcessosApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(pontovirtualacessos);
      return response.data;
    } catch (error) {
      if (error instanceof PontoVirtualAcessosApiError) {
        throw error;
      }
      throw new PontoVirtualAcessosApiError('Erro ao salvar pontovirtualacessos', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterPontoVirtualAcessos): Promise<IPontoVirtualAcessos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all pontovirtualacessos:', error);
      return [];
    }
  }

  async deletePontoVirtualAcessos(id: number): Promise<void> {
    if (id <= 0) {
      throw new PontoVirtualAcessosApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof PontoVirtualAcessosApiError) {
        throw error;
      }
      throw new PontoVirtualAcessosApiError('Erro ao excluir pontovirtualacessos', 500, 'DELETE_ERROR', error);
    }
  }

  validatePontoVirtualAcessos(pontovirtualacessos: IPontoVirtualAcessos): { isValid: boolean; errors: string[] } {
    return PontoVirtualAcessosValidator.validatePontoVirtualAcessos(pontovirtualacessos);
  }
}