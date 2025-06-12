'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { AlertasEnviadosApi, AlertasEnviadosApiError } from '../Apis/ApiAlertasEnviados';
import { FilterAlertasEnviados } from '../Filters/AlertasEnviados';
import { IAlertasEnviados } from '../Interfaces/interface.AlertasEnviados';

export class AlertasEnviadosValidator {
  static validateAlertasEnviados(alertasenviados: IAlertasEnviados): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IAlertasEnviadosService {
  fetchAlertasEnviadosById: (id: number) => Promise<IAlertasEnviados>;
  saveAlertasEnviados: (alertasenviados: IAlertasEnviados) => Promise<IAlertasEnviados>;  
  
  getAll: (filtro?: FilterAlertasEnviados) => Promise<IAlertasEnviados[]>;
  deleteAlertasEnviados: (id: number) => Promise<void>;
  validateAlertasEnviados: (alertasenviados: IAlertasEnviados) => { isValid: boolean; errors: string[] };
}

export class AlertasEnviadosService implements IAlertasEnviadosService {
  constructor(private api: AlertasEnviadosApi) {}

  async fetchAlertasEnviadosById(id: number): Promise<IAlertasEnviados> {
    if (id <= 0) {
      throw new AlertasEnviadosApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof AlertasEnviadosApiError) {
        throw error;
      }
      throw new AlertasEnviadosApiError('Erro ao buscar alertasenviados', 500, 'FETCH_ERROR', error);
    }
  }

  async saveAlertasEnviados(alertasenviados: IAlertasEnviados): Promise<IAlertasEnviados> {    
    const validation = this.validateAlertasEnviados(alertasenviados);
    if (!validation.isValid) {
      throw new AlertasEnviadosApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(alertasenviados);
      return response.data;
    } catch (error) {
      if (error instanceof AlertasEnviadosApiError) {
        throw error;
      }
      throw new AlertasEnviadosApiError('Erro ao salvar alertasenviados', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterAlertasEnviados): Promise<IAlertasEnviados[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all alertasenviados:', error);
      return [];
    }
  }

  async deleteAlertasEnviados(id: number): Promise<void> {
    if (id <= 0) {
      throw new AlertasEnviadosApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof AlertasEnviadosApiError) {
        throw error;
      }
      throw new AlertasEnviadosApiError('Erro ao excluir alertasenviados', 500, 'DELETE_ERROR', error);
    }
  }

  validateAlertasEnviados(alertasenviados: IAlertasEnviados): { isValid: boolean; errors: string[] } {
    return AlertasEnviadosValidator.validateAlertasEnviados(alertasenviados);
  }
}