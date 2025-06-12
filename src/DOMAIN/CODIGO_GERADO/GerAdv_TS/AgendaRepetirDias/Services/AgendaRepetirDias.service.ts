'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { AgendaRepetirDiasApi, AgendaRepetirDiasApiError } from '../Apis/ApiAgendaRepetirDias';
import { FilterAgendaRepetirDias } from '../Filters/AgendaRepetirDias';
import { IAgendaRepetirDias } from '../Interfaces/interface.AgendaRepetirDias';

export class AgendaRepetirDiasValidator {
  static validateAgendaRepetirDias(agendarepetirdias: IAgendaRepetirDias): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IAgendaRepetirDiasService {
  fetchAgendaRepetirDiasById: (id: number) => Promise<IAgendaRepetirDias>;
  saveAgendaRepetirDias: (agendarepetirdias: IAgendaRepetirDias) => Promise<IAgendaRepetirDias>;  
  
  getAll: (filtro?: FilterAgendaRepetirDias) => Promise<IAgendaRepetirDias[]>;
  deleteAgendaRepetirDias: (id: number) => Promise<void>;
  validateAgendaRepetirDias: (agendarepetirdias: IAgendaRepetirDias) => { isValid: boolean; errors: string[] };
}

export class AgendaRepetirDiasService implements IAgendaRepetirDiasService {
  constructor(private api: AgendaRepetirDiasApi) {}

  async fetchAgendaRepetirDiasById(id: number): Promise<IAgendaRepetirDias> {
    if (id <= 0) {
      throw new AgendaRepetirDiasApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof AgendaRepetirDiasApiError) {
        throw error;
      }
      throw new AgendaRepetirDiasApiError('Erro ao buscar agendarepetirdias', 500, 'FETCH_ERROR', error);
    }
  }

  async saveAgendaRepetirDias(agendarepetirdias: IAgendaRepetirDias): Promise<IAgendaRepetirDias> {    
    const validation = this.validateAgendaRepetirDias(agendarepetirdias);
    if (!validation.isValid) {
      throw new AgendaRepetirDiasApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(agendarepetirdias);
      return response.data;
    } catch (error) {
      if (error instanceof AgendaRepetirDiasApiError) {
        throw error;
      }
      throw new AgendaRepetirDiasApiError('Erro ao salvar agendarepetirdias', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterAgendaRepetirDias): Promise<IAgendaRepetirDias[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all agendarepetirdias:', error);
      return [];
    }
  }

  async deleteAgendaRepetirDias(id: number): Promise<void> {
    if (id <= 0) {
      throw new AgendaRepetirDiasApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof AgendaRepetirDiasApiError) {
        throw error;
      }
      throw new AgendaRepetirDiasApiError('Erro ao excluir agendarepetirdias', 500, 'DELETE_ERROR', error);
    }
  }

  validateAgendaRepetirDias(agendarepetirdias: IAgendaRepetirDias): { isValid: boolean; errors: string[] } {
    return AgendaRepetirDiasValidator.validateAgendaRepetirDias(agendarepetirdias);
  }
}