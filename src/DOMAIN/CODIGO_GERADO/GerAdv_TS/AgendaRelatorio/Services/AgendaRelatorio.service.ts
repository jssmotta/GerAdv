'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { AgendaRelatorioApi, AgendaRelatorioApiError } from '../Apis/ApiAgendaRelatorio';
import { FilterAgendaRelatorio } from '../Filters/AgendaRelatorio';
import { IAgendaRelatorio } from '../Interfaces/interface.AgendaRelatorio';
import { AgendaRelatorioEmpty } from '../../Models/AgendaRelatorio';

export class AgendaRelatorioValidator {
  static validateAgendaRelatorio(agendarelatorio: IAgendaRelatorio): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IAgendaRelatorioService {
  fetchAgendaRelatorioById: (id: number) => Promise<IAgendaRelatorio>;
  saveAgendaRelatorio: (agendarelatorio: IAgendaRelatorio) => Promise<IAgendaRelatorio>;  
  
  getAll: (filtro?: FilterAgendaRelatorio) => Promise<IAgendaRelatorio[]>;
  deleteAgendaRelatorio: (id: number) => Promise<void>;
  validateAgendaRelatorio: (agendarelatorio: IAgendaRelatorio) => { isValid: boolean; errors: string[] };
}

export class AgendaRelatorioService implements IAgendaRelatorioService {
  constructor(private api: AgendaRelatorioApi) {}

  async fetchAgendaRelatorioById(id: number): Promise<IAgendaRelatorio> {
    if (id <= 0) {
      throw new AgendaRelatorioApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      return AgendaRelatorioEmpty();

    } catch (error) {
      if (error instanceof AgendaRelatorioApiError) {
        throw error;
      }
      throw new AgendaRelatorioApiError('Erro ao buscar agendarelatorio', 500, 'FETCH_ERROR', error);
    }
  }

  async saveAgendaRelatorio(agendarelatorio: IAgendaRelatorio): Promise<IAgendaRelatorio> {    
    const validation = this.validateAgendaRelatorio(agendarelatorio);
    if (!validation.isValid) {
      throw new AgendaRelatorioApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(agendarelatorio);
      return response.data;
    } catch (error) {
      if (error instanceof AgendaRelatorioApiError) {
        throw error;
      }
      throw new AgendaRelatorioApiError('Erro ao salvar agendarelatorio', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterAgendaRelatorio): Promise<IAgendaRelatorio[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all agendarelatorio:', error);
      return [];
    }
  }

  async deleteAgendaRelatorio(id: number): Promise<void> {
    if (id <= 0) {
      throw new AgendaRelatorioApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof AgendaRelatorioApiError) {
        throw error;
      }
      throw new AgendaRelatorioApiError('Erro ao excluir agendarelatorio', 500, 'DELETE_ERROR', error);
    }
  }

  validateAgendaRelatorio(agendarelatorio: IAgendaRelatorio): { isValid: boolean; errors: string[] } {
    return AgendaRelatorioValidator.validateAgendaRelatorio(agendarelatorio);
  }
}