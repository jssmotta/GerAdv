'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { AgendaRecordsApi, AgendaRecordsApiError } from '../Apis/ApiAgendaRecords';
import { FilterAgendaRecords } from '../Filters/AgendaRecords';
import { IAgendaRecords } from '../Interfaces/interface.AgendaRecords';
import { AgendaRecordsEmpty } from '../../Models/AgendaRecords';

export class AgendaRecordsValidator {
  static validateAgendaRecords(agendarecords: IAgendaRecords): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IAgendaRecordsService {
  fetchAgendaRecordsById: (id: number) => Promise<IAgendaRecords>;
  saveAgendaRecords: (agendarecords: IAgendaRecords) => Promise<IAgendaRecords>;  
  
  getAll: (filtro?: FilterAgendaRecords) => Promise<IAgendaRecords[]>;
  deleteAgendaRecords: (id: number) => Promise<void>;
  validateAgendaRecords: (agendarecords: IAgendaRecords) => { isValid: boolean; errors: string[] };
}

export class AgendaRecordsService implements IAgendaRecordsService {
  constructor(private api: AgendaRecordsApi) {}

  async fetchAgendaRecordsById(id: number): Promise<IAgendaRecords> {
    if (id <= 0) {
      throw new AgendaRecordsApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof AgendaRecordsApiError) {
        throw error;
      }
      throw new AgendaRecordsApiError('Erro ao buscar agendarecords', 500, 'FETCH_ERROR', error);
    }
  }

  async saveAgendaRecords(agendarecords: IAgendaRecords): Promise<IAgendaRecords> {    
    const validation = this.validateAgendaRecords(agendarecords);
    if (!validation.isValid) {
      throw new AgendaRecordsApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(agendarecords);
      return response.data;
    } catch (error) {
      if (error instanceof AgendaRecordsApiError) {
        throw error;
      }
      throw new AgendaRecordsApiError('Erro ao salvar agendarecords', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterAgendaRecords): Promise<IAgendaRecords[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all agendarecords:', error);
      return [];
    }
  }

  async deleteAgendaRecords(id: number): Promise<void> {
    if (id <= 0) {
      throw new AgendaRecordsApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof AgendaRecordsApiError) {
        throw error;
      }
      throw new AgendaRecordsApiError('Erro ao excluir agendarecords', 500, 'DELETE_ERROR', error);
    }
  }

  validateAgendaRecords(agendarecords: IAgendaRecords): { isValid: boolean; errors: string[] } {
    return AgendaRecordsValidator.validateAgendaRecords(agendarecords);
  }
}