'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { OperadorGruposAgendaApi, OperadorGruposAgendaApiError } from '../Apis/ApiOperadorGruposAgenda';
import { FilterOperadorGruposAgenda } from '../Filters/OperadorGruposAgenda';
import { IOperadorGruposAgenda } from '../Interfaces/interface.OperadorGruposAgenda';

export class OperadorGruposAgendaValidator {
  static validateOperadorGruposAgenda(operadorgruposagenda: IOperadorGruposAgenda): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IOperadorGruposAgendaService {
  fetchOperadorGruposAgendaById: (id: number) => Promise<IOperadorGruposAgenda>;
  saveOperadorGruposAgenda: (operadorgruposagenda: IOperadorGruposAgenda) => Promise<IOperadorGruposAgenda>;  
  getList: (filtro?: FilterOperadorGruposAgenda) => Promise<IOperadorGruposAgenda[]>;
  getAll: (filtro?: FilterOperadorGruposAgenda) => Promise<IOperadorGruposAgenda[]>;
  deleteOperadorGruposAgenda: (id: number) => Promise<void>;
  validateOperadorGruposAgenda: (operadorgruposagenda: IOperadorGruposAgenda) => { isValid: boolean; errors: string[] };
}

export class OperadorGruposAgendaService implements IOperadorGruposAgendaService {
  constructor(private api: OperadorGruposAgendaApi) {}

  async fetchOperadorGruposAgendaById(id: number): Promise<IOperadorGruposAgenda> {
    if (id <= 0) {
      throw new OperadorGruposAgendaApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof OperadorGruposAgendaApiError) {
        throw error;
      }
      throw new OperadorGruposAgendaApiError('Erro ao buscar operadorgruposagenda', 500, 'FETCH_ERROR', error);
    }
  }

  async saveOperadorGruposAgenda(operadorgruposagenda: IOperadorGruposAgenda): Promise<IOperadorGruposAgenda> {    
    const validation = this.validateOperadorGruposAgenda(operadorgruposagenda);
    if (!validation.isValid) {
      throw new OperadorGruposAgendaApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(operadorgruposagenda);
      return response.data;
    } catch (error) {
      if (error instanceof OperadorGruposAgendaApiError) {
        throw error;
      }
      throw new OperadorGruposAgendaApiError('Erro ao salvar operadorgruposagenda', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterOperadorGruposAgenda): Promise<IOperadorGruposAgenda[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching operadorgruposagenda list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterOperadorGruposAgenda): Promise<IOperadorGruposAgenda[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all operadorgruposagenda:', error);
      return [];
    }
  }

  async deleteOperadorGruposAgenda(id: number): Promise<void> {
    if (id <= 0) {
      throw new OperadorGruposAgendaApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof OperadorGruposAgendaApiError) {
        throw error;
      }
      throw new OperadorGruposAgendaApiError('Erro ao excluir operadorgruposagenda', 500, 'DELETE_ERROR', error);
    }
  }

  validateOperadorGruposAgenda(operadorgruposagenda: IOperadorGruposAgenda): { isValid: boolean; errors: string[] } {
    return OperadorGruposAgendaValidator.validateOperadorGruposAgenda(operadorgruposagenda);
  }
}