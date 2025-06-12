'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { AgendaApi, AgendaApiError } from '../Apis/ApiAgenda';
import { FilterAgenda } from '../Filters/Agenda';
import { IAgenda } from '../Interfaces/interface.Agenda';

export class AgendaValidator {
  static validateAgenda(agenda: IAgenda): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IAgendaService {
  fetchAgendaById: (id: number) => Promise<IAgenda>;
  saveAgenda: (agenda: IAgenda) => Promise<IAgenda>;  
  
  getAll: (filtro?: FilterAgenda) => Promise<IAgenda[]>;
  deleteAgenda: (id: number) => Promise<void>;
  validateAgenda: (agenda: IAgenda) => { isValid: boolean; errors: string[] };
}

export class AgendaService implements IAgendaService {
  constructor(private api: AgendaApi) {}

  async fetchAgendaById(id: number): Promise<IAgenda> {
    if (id <= 0) {
      throw new AgendaApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof AgendaApiError) {
        throw error;
      }
      throw new AgendaApiError('Erro ao buscar agenda', 500, 'FETCH_ERROR', error);
    }
  }

  async saveAgenda(agenda: IAgenda): Promise<IAgenda> {    
    const validation = this.validateAgenda(agenda);
    if (!validation.isValid) {
      throw new AgendaApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(agenda);
      return response.data;
    } catch (error) {
      if (error instanceof AgendaApiError) {
        throw error;
      }
      throw new AgendaApiError('Erro ao salvar agenda', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterAgenda): Promise<IAgenda[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all agenda:', error);
      return [];
    }
  }

  async deleteAgenda(id: number): Promise<void> {
    if (id <= 0) {
      throw new AgendaApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof AgendaApiError) {
        throw error;
      }
      throw new AgendaApiError('Erro ao excluir agenda', 500, 'DELETE_ERROR', error);
    }
  }

  validateAgenda(agenda: IAgenda): { isValid: boolean; errors: string[] } {
    return AgendaValidator.validateAgenda(agenda);
  }
}