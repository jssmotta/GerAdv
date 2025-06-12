'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { AgendaFinanceiroApi, AgendaFinanceiroApiError } from '../Apis/ApiAgendaFinanceiro';
import { FilterAgendaFinanceiro } from '../Filters/AgendaFinanceiro';
import { IAgendaFinanceiro } from '../Interfaces/interface.AgendaFinanceiro';

export class AgendaFinanceiroValidator {
  static validateAgendaFinanceiro(agendafinanceiro: IAgendaFinanceiro): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IAgendaFinanceiroService {
  fetchAgendaFinanceiroById: (id: number) => Promise<IAgendaFinanceiro>;
  saveAgendaFinanceiro: (agendafinanceiro: IAgendaFinanceiro) => Promise<IAgendaFinanceiro>;  
  
  getAll: (filtro?: FilterAgendaFinanceiro) => Promise<IAgendaFinanceiro[]>;
  deleteAgendaFinanceiro: (id: number) => Promise<void>;
  validateAgendaFinanceiro: (agendafinanceiro: IAgendaFinanceiro) => { isValid: boolean; errors: string[] };
}

export class AgendaFinanceiroService implements IAgendaFinanceiroService {
  constructor(private api: AgendaFinanceiroApi) {}

  async fetchAgendaFinanceiroById(id: number): Promise<IAgendaFinanceiro> {
    if (id <= 0) {
      throw new AgendaFinanceiroApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof AgendaFinanceiroApiError) {
        throw error;
      }
      throw new AgendaFinanceiroApiError('Erro ao buscar agendafinanceiro', 500, 'FETCH_ERROR', error);
    }
  }

  async saveAgendaFinanceiro(agendafinanceiro: IAgendaFinanceiro): Promise<IAgendaFinanceiro> {    
    const validation = this.validateAgendaFinanceiro(agendafinanceiro);
    if (!validation.isValid) {
      throw new AgendaFinanceiroApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(agendafinanceiro);
      return response.data;
    } catch (error) {
      if (error instanceof AgendaFinanceiroApiError) {
        throw error;
      }
      throw new AgendaFinanceiroApiError('Erro ao salvar agendafinanceiro', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterAgendaFinanceiro): Promise<IAgendaFinanceiro[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all agendafinanceiro:', error);
      return [];
    }
  }

  async deleteAgendaFinanceiro(id: number): Promise<void> {
    if (id <= 0) {
      throw new AgendaFinanceiroApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof AgendaFinanceiroApiError) {
        throw error;
      }
      throw new AgendaFinanceiroApiError('Erro ao excluir agendafinanceiro', 500, 'DELETE_ERROR', error);
    }
  }

  validateAgendaFinanceiro(agendafinanceiro: IAgendaFinanceiro): { isValid: boolean; errors: string[] } {
    return AgendaFinanceiroValidator.validateAgendaFinanceiro(agendafinanceiro);
  }
}