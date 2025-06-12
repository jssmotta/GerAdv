'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { EventoPrazoAgendaApi, EventoPrazoAgendaApiError } from '../Apis/ApiEventoPrazoAgenda';
import { FilterEventoPrazoAgenda } from '../Filters/EventoPrazoAgenda';
import { IEventoPrazoAgenda } from '../Interfaces/interface.EventoPrazoAgenda';

export class EventoPrazoAgendaValidator {
  static validateEventoPrazoAgenda(eventoprazoagenda: IEventoPrazoAgenda): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IEventoPrazoAgendaService {
  fetchEventoPrazoAgendaById: (id: number) => Promise<IEventoPrazoAgenda>;
  saveEventoPrazoAgenda: (eventoprazoagenda: IEventoPrazoAgenda) => Promise<IEventoPrazoAgenda>;  
  getList: (filtro?: FilterEventoPrazoAgenda) => Promise<IEventoPrazoAgenda[]>;
  getAll: (filtro?: FilterEventoPrazoAgenda) => Promise<IEventoPrazoAgenda[]>;
  deleteEventoPrazoAgenda: (id: number) => Promise<void>;
  validateEventoPrazoAgenda: (eventoprazoagenda: IEventoPrazoAgenda) => { isValid: boolean; errors: string[] };
}

export class EventoPrazoAgendaService implements IEventoPrazoAgendaService {
  constructor(private api: EventoPrazoAgendaApi) {}

  async fetchEventoPrazoAgendaById(id: number): Promise<IEventoPrazoAgenda> {
    if (id <= 0) {
      throw new EventoPrazoAgendaApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof EventoPrazoAgendaApiError) {
        throw error;
      }
      throw new EventoPrazoAgendaApiError('Erro ao buscar eventoprazoagenda', 500, 'FETCH_ERROR', error);
    }
  }

  async saveEventoPrazoAgenda(eventoprazoagenda: IEventoPrazoAgenda): Promise<IEventoPrazoAgenda> {    
    const validation = this.validateEventoPrazoAgenda(eventoprazoagenda);
    if (!validation.isValid) {
      throw new EventoPrazoAgendaApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(eventoprazoagenda);
      return response.data;
    } catch (error) {
      if (error instanceof EventoPrazoAgendaApiError) {
        throw error;
      }
      throw new EventoPrazoAgendaApiError('Erro ao salvar eventoprazoagenda', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterEventoPrazoAgenda): Promise<IEventoPrazoAgenda[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching eventoprazoagenda list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterEventoPrazoAgenda): Promise<IEventoPrazoAgenda[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all eventoprazoagenda:', error);
      return [];
    }
  }

  async deleteEventoPrazoAgenda(id: number): Promise<void> {
    if (id <= 0) {
      throw new EventoPrazoAgendaApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof EventoPrazoAgendaApiError) {
        throw error;
      }
      throw new EventoPrazoAgendaApiError('Erro ao excluir eventoprazoagenda', 500, 'DELETE_ERROR', error);
    }
  }

  validateEventoPrazoAgenda(eventoprazoagenda: IEventoPrazoAgenda): { isValid: boolean; errors: string[] } {
    return EventoPrazoAgendaValidator.validateEventoPrazoAgenda(eventoprazoagenda);
  }
}