'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { AgendaSemanaApi, AgendaSemanaApiError } from '../Apis/ApiAgendaSemana';
import { FilterAgendaSemana } from '../Filters/AgendaSemana';
import { IAgendaSemana } from '../Interfaces/interface.AgendaSemana';
import { AgendaSemanaEmpty } from '../../Models/AgendaSemana';

export class AgendaSemanaValidator {
  static validateAgendaSemana(agendasemana: IAgendaSemana): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IAgendaSemanaService {
  fetchAgendaSemanaById: (id: number) => Promise<IAgendaSemana>;
  saveAgendaSemana: (agendasemana: IAgendaSemana) => Promise<IAgendaSemana>;  
  
  getAll: (filtro?: FilterAgendaSemana) => Promise<IAgendaSemana[]>;
  deleteAgendaSemana: (id: number) => Promise<void>;
  validateAgendaSemana: (agendasemana: IAgendaSemana) => { isValid: boolean; errors: string[] };
}

export class AgendaSemanaService implements IAgendaSemanaService {
  constructor(private api: AgendaSemanaApi) {}

  async fetchAgendaSemanaById(id: number): Promise<IAgendaSemana> {
    if (id <= 0) {
      throw new AgendaSemanaApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      return AgendaSemanaEmpty();

    } catch (error) {
      if (error instanceof AgendaSemanaApiError) {
        throw error;
      }
      throw new AgendaSemanaApiError('Erro ao buscar agendasemana', 500, 'FETCH_ERROR', error);
    }
  }

  async saveAgendaSemana(agendasemana: IAgendaSemana): Promise<IAgendaSemana> {    
    const validation = this.validateAgendaSemana(agendasemana);
    if (!validation.isValid) {
      throw new AgendaSemanaApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(agendasemana);
      return response.data;
    } catch (error) {
      if (error instanceof AgendaSemanaApiError) {
        throw error;
      }
      throw new AgendaSemanaApiError('Erro ao salvar agendasemana', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterAgendaSemana): Promise<IAgendaSemana[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all agendasemana:', error);
      return [];
    }
  }

  async deleteAgendaSemana(id: number): Promise<void> {
    if (id <= 0) {
      throw new AgendaSemanaApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof AgendaSemanaApiError) {
        throw error;
      }
      throw new AgendaSemanaApiError('Erro ao excluir agendasemana', 500, 'DELETE_ERROR', error);
    }
  }

  validateAgendaSemana(agendasemana: IAgendaSemana): { isValid: boolean; errors: string[] } {
    return AgendaSemanaValidator.validateAgendaSemana(agendasemana);
  }
}