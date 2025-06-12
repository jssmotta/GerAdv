'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { AgendaQuemApi, AgendaQuemApiError } from '../Apis/ApiAgendaQuem';
import { FilterAgendaQuem } from '../Filters/AgendaQuem';
import { IAgendaQuem } from '../Interfaces/interface.AgendaQuem';

export class AgendaQuemValidator {
  static validateAgendaQuem(agendaquem: IAgendaQuem): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IAgendaQuemService {
  fetchAgendaQuemById: (id: number) => Promise<IAgendaQuem>;
  saveAgendaQuem: (agendaquem: IAgendaQuem) => Promise<IAgendaQuem>;  
  
  getAll: (filtro?: FilterAgendaQuem) => Promise<IAgendaQuem[]>;
  deleteAgendaQuem: (id: number) => Promise<void>;
  validateAgendaQuem: (agendaquem: IAgendaQuem) => { isValid: boolean; errors: string[] };
}

export class AgendaQuemService implements IAgendaQuemService {
  constructor(private api: AgendaQuemApi) {}

  async fetchAgendaQuemById(id: number): Promise<IAgendaQuem> {
    if (id <= 0) {
      throw new AgendaQuemApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof AgendaQuemApiError) {
        throw error;
      }
      throw new AgendaQuemApiError('Erro ao buscar agendaquem', 500, 'FETCH_ERROR', error);
    }
  }

  async saveAgendaQuem(agendaquem: IAgendaQuem): Promise<IAgendaQuem> {    
    const validation = this.validateAgendaQuem(agendaquem);
    if (!validation.isValid) {
      throw new AgendaQuemApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(agendaquem);
      return response.data;
    } catch (error) {
      if (error instanceof AgendaQuemApiError) {
        throw error;
      }
      throw new AgendaQuemApiError('Erro ao salvar agendaquem', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterAgendaQuem): Promise<IAgendaQuem[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all agendaquem:', error);
      return [];
    }
  }

  async deleteAgendaQuem(id: number): Promise<void> {
    if (id <= 0) {
      throw new AgendaQuemApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof AgendaQuemApiError) {
        throw error;
      }
      throw new AgendaQuemApiError('Erro ao excluir agendaquem', 500, 'DELETE_ERROR', error);
    }
  }

  validateAgendaQuem(agendaquem: IAgendaQuem): { isValid: boolean; errors: string[] } {
    return AgendaQuemValidator.validateAgendaQuem(agendaquem);
  }
}