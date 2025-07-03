'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { AgendaRepetirApi, AgendaRepetirApiError } from '../Apis/ApiAgendaRepetir';
import { FilterAgendaRepetir } from '../Filters/AgendaRepetir';
import { IAgendaRepetir } from '../Interfaces/interface.AgendaRepetir';
import { AgendaRepetirEmpty } from '../../Models/AgendaRepetir';

export class AgendaRepetirValidator {
  static validateAgendaRepetir(agendarepetir: IAgendaRepetir): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IAgendaRepetirService {
  fetchAgendaRepetirById: (id: number) => Promise<IAgendaRepetir>;
  saveAgendaRepetir: (agendarepetir: IAgendaRepetir) => Promise<IAgendaRepetir>;  
  
  getAll: (filtro?: FilterAgendaRepetir) => Promise<IAgendaRepetir[]>;
  deleteAgendaRepetir: (id: number) => Promise<void>;
  validateAgendaRepetir: (agendarepetir: IAgendaRepetir) => { isValid: boolean; errors: string[] };
}

export class AgendaRepetirService implements IAgendaRepetirService {
  constructor(private api: AgendaRepetirApi) {}

  async fetchAgendaRepetirById(id: number): Promise<IAgendaRepetir> {
    if (id <= 0) {
      throw new AgendaRepetirApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof AgendaRepetirApiError) {
        throw error;
      }
      throw new AgendaRepetirApiError('Erro ao buscar agendarepetir', 500, 'FETCH_ERROR', error);
    }
  }

  async saveAgendaRepetir(agendarepetir: IAgendaRepetir): Promise<IAgendaRepetir> {    
    const validation = this.validateAgendaRepetir(agendarepetir);
    if (!validation.isValid) {
      throw new AgendaRepetirApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(agendarepetir);
      return response.data;
    } catch (error) {
      if (error instanceof AgendaRepetirApiError) {
        throw error;
      }
      throw new AgendaRepetirApiError('Erro ao salvar agendarepetir', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterAgendaRepetir): Promise<IAgendaRepetir[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all agendarepetir:', error);
      return [];
    }
  }

  async deleteAgendaRepetir(id: number): Promise<void> {
    if (id <= 0) {
      throw new AgendaRepetirApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof AgendaRepetirApiError) {
        throw error;
      }
      throw new AgendaRepetirApiError('Erro ao excluir agendarepetir', 500, 'DELETE_ERROR', error);
    }
  }

  validateAgendaRepetir(agendarepetir: IAgendaRepetir): { isValid: boolean; errors: string[] } {
    return AgendaRepetirValidator.validateAgendaRepetir(agendarepetir);
  }
}