'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { AlarmSMSApi, AlarmSMSApiError } from '../Apis/ApiAlarmSMS';
import { FilterAlarmSMS } from '../Filters/AlarmSMS';
import { IAlarmSMS } from '../Interfaces/interface.AlarmSMS';

export class AlarmSMSValidator {
  static validateAlarmSMS(alarmsms: IAlarmSMS): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IAlarmSMSService {
  fetchAlarmSMSById: (id: number) => Promise<IAlarmSMS>;
  saveAlarmSMS: (alarmsms: IAlarmSMS) => Promise<IAlarmSMS>;  
  getList: (filtro?: FilterAlarmSMS) => Promise<IAlarmSMS[]>;
  getAll: (filtro?: FilterAlarmSMS) => Promise<IAlarmSMS[]>;
  deleteAlarmSMS: (id: number) => Promise<void>;
  validateAlarmSMS: (alarmsms: IAlarmSMS) => { isValid: boolean; errors: string[] };
}

export class AlarmSMSService implements IAlarmSMSService {
  constructor(private api: AlarmSMSApi) {}

  async fetchAlarmSMSById(id: number): Promise<IAlarmSMS> {
    if (id <= 0) {
      throw new AlarmSMSApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof AlarmSMSApiError) {
        throw error;
      }
      throw new AlarmSMSApiError('Erro ao buscar alarmsms', 500, 'FETCH_ERROR', error);
    }
  }

  async saveAlarmSMS(alarmsms: IAlarmSMS): Promise<IAlarmSMS> {    
    const validation = this.validateAlarmSMS(alarmsms);
    if (!validation.isValid) {
      throw new AlarmSMSApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(alarmsms);
      return response.data;
    } catch (error) {
      if (error instanceof AlarmSMSApiError) {
        throw error;
      }
      throw new AlarmSMSApiError('Erro ao salvar alarmsms', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterAlarmSMS): Promise<IAlarmSMS[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching alarmsms list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterAlarmSMS): Promise<IAlarmSMS[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all alarmsms:', error);
      return [];
    }
  }

  async deleteAlarmSMS(id: number): Promise<void> {
    if (id <= 0) {
      throw new AlarmSMSApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof AlarmSMSApiError) {
        throw error;
      }
      throw new AlarmSMSApiError('Erro ao excluir alarmsms', 500, 'DELETE_ERROR', error);
    }
  }

  validateAlarmSMS(alarmsms: IAlarmSMS): { isValid: boolean; errors: string[] } {
    return AlarmSMSValidator.validateAlarmSMS(alarmsms);
  }
}