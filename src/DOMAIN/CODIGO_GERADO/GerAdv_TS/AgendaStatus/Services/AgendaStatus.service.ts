'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { AgendaStatusApi, AgendaStatusApiError } from '../Apis/ApiAgendaStatus';
import { FilterAgendaStatus } from '../Filters/AgendaStatus';
import { IAgendaStatus } from '../Interfaces/interface.AgendaStatus';
import { AgendaStatusEmpty } from '../../Models/AgendaStatus';

export class AgendaStatusValidator {
  static validateAgendaStatus(agendastatus: IAgendaStatus): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IAgendaStatusService {
  fetchAgendaStatusById: (id: number) => Promise<IAgendaStatus>;
  saveAgendaStatus: (agendastatus: IAgendaStatus) => Promise<IAgendaStatus>;  
  
  getAll: (filtro?: FilterAgendaStatus) => Promise<IAgendaStatus[]>;
  deleteAgendaStatus: (id: number) => Promise<void>;
  validateAgendaStatus: (agendastatus: IAgendaStatus) => { isValid: boolean; errors: string[] };
}

export class AgendaStatusService implements IAgendaStatusService {
  constructor(private api: AgendaStatusApi) {}

  async fetchAgendaStatusById(id: number): Promise<IAgendaStatus> {
    if (id <= 0) {
      throw new AgendaStatusApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof AgendaStatusApiError) {
        throw error;
      }
      throw new AgendaStatusApiError('Erro ao buscar agendastatus', 500, 'FETCH_ERROR', error);
    }
  }

  async saveAgendaStatus(agendastatus: IAgendaStatus): Promise<IAgendaStatus> {    
    const validation = this.validateAgendaStatus(agendastatus);
    if (!validation.isValid) {
      throw new AgendaStatusApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(agendastatus);
      return response.data;
    } catch (error) {
      if (error instanceof AgendaStatusApiError) {
        throw error;
      }
      throw new AgendaStatusApiError('Erro ao salvar agendastatus', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterAgendaStatus): Promise<IAgendaStatus[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all agendastatus:', error);
      return [];
    }
  }

  async deleteAgendaStatus(id: number): Promise<void> {
    if (id <= 0) {
      throw new AgendaStatusApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof AgendaStatusApiError) {
        throw error;
      }
      throw new AgendaStatusApiError('Erro ao excluir agendastatus', 500, 'DELETE_ERROR', error);
    }
  }

  validateAgendaStatus(agendastatus: IAgendaStatus): { isValid: boolean; errors: string[] } {
    return AgendaStatusValidator.validateAgendaStatus(agendastatus);
  }
}