'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { OperadorGruposAgendaOperadoresApi, OperadorGruposAgendaOperadoresApiError } from '../Apis/ApiOperadorGruposAgendaOperadores';
import { FilterOperadorGruposAgendaOperadores } from '../Filters/OperadorGruposAgendaOperadores';
import { IOperadorGruposAgendaOperadores } from '../Interfaces/interface.OperadorGruposAgendaOperadores';
import { OperadorGruposAgendaOperadoresEmpty } from '../../Models/OperadorGruposAgendaOperadores';

export class OperadorGruposAgendaOperadoresValidator {
  static validateOperadorGruposAgendaOperadores(operadorgruposagendaoperadores: IOperadorGruposAgendaOperadores): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IOperadorGruposAgendaOperadoresService {
  fetchOperadorGruposAgendaOperadoresById: (id: number) => Promise<IOperadorGruposAgendaOperadores>;
  saveOperadorGruposAgendaOperadores: (operadorgruposagendaoperadores: IOperadorGruposAgendaOperadores) => Promise<IOperadorGruposAgendaOperadores>;  
  
  getAll: (filtro?: FilterOperadorGruposAgendaOperadores) => Promise<IOperadorGruposAgendaOperadores[]>;
  deleteOperadorGruposAgendaOperadores: (id: number) => Promise<void>;
  validateOperadorGruposAgendaOperadores: (operadorgruposagendaoperadores: IOperadorGruposAgendaOperadores) => { isValid: boolean; errors: string[] };
}

export class OperadorGruposAgendaOperadoresService implements IOperadorGruposAgendaOperadoresService {
  constructor(private api: OperadorGruposAgendaOperadoresApi) {}

  async fetchOperadorGruposAgendaOperadoresById(id: number): Promise<IOperadorGruposAgendaOperadores> {
    if (id <= 0) {
      throw new OperadorGruposAgendaOperadoresApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof OperadorGruposAgendaOperadoresApiError) {
        throw error;
      }
      throw new OperadorGruposAgendaOperadoresApiError('Erro ao buscar operadorgruposagendaoperadores', 500, 'FETCH_ERROR', error);
    }
  }

  async saveOperadorGruposAgendaOperadores(operadorgruposagendaoperadores: IOperadorGruposAgendaOperadores): Promise<IOperadorGruposAgendaOperadores> {    
    const validation = this.validateOperadorGruposAgendaOperadores(operadorgruposagendaoperadores);
    if (!validation.isValid) {
      throw new OperadorGruposAgendaOperadoresApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(operadorgruposagendaoperadores);
      return response.data;
    } catch (error) {
      if (error instanceof OperadorGruposAgendaOperadoresApiError) {
        throw error;
      }
      throw new OperadorGruposAgendaOperadoresApiError('Erro ao salvar operadorgruposagendaoperadores', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterOperadorGruposAgendaOperadores): Promise<IOperadorGruposAgendaOperadores[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all operadorgruposagendaoperadores:', error);
      return [];
    }
  }

  async deleteOperadorGruposAgendaOperadores(id: number): Promise<void> {
    if (id <= 0) {
      throw new OperadorGruposAgendaOperadoresApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof OperadorGruposAgendaOperadoresApiError) {
        throw error;
      }
      throw new OperadorGruposAgendaOperadoresApiError('Erro ao excluir operadorgruposagendaoperadores', 500, 'DELETE_ERROR', error);
    }
  }

  validateOperadorGruposAgendaOperadores(operadorgruposagendaoperadores: IOperadorGruposAgendaOperadores): { isValid: boolean; errors: string[] } {
    return OperadorGruposAgendaOperadoresValidator.validateOperadorGruposAgendaOperadores(operadorgruposagendaoperadores);
  }
}