'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { AlertasApi, AlertasApiError } from '../Apis/ApiAlertas';
import { FilterAlertas } from '../Filters/Alertas';
import { IAlertas } from '../Interfaces/interface.Alertas';
import { AlertasEmpty } from '../../Models/Alertas';

export class AlertasValidator {
  static validateAlertas(alertas: IAlertas): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IAlertasService {
  fetchAlertasById: (id: number) => Promise<IAlertas>;
  saveAlertas: (alertas: IAlertas) => Promise<IAlertas>;  
  getList: (filtro?: FilterAlertas) => Promise<IAlertas[]>;
  getAll: (filtro?: FilterAlertas) => Promise<IAlertas[]>;
  deleteAlertas: (id: number) => Promise<void>;
  validateAlertas: (alertas: IAlertas) => { isValid: boolean; errors: string[] };
}

export class AlertasService implements IAlertasService {
  constructor(private api: AlertasApi) {}

  async fetchAlertasById(id: number): Promise<IAlertas> {
    if (id <= 0) {
      throw new AlertasApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof AlertasApiError) {
        throw error;
      }
      throw new AlertasApiError('Erro ao buscar alertas', 500, 'FETCH_ERROR', error);
    }
  }

  async saveAlertas(alertas: IAlertas): Promise<IAlertas> {    
    const validation = this.validateAlertas(alertas);
    if (!validation.isValid) {
      throw new AlertasApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(alertas);
      return response.data;
    } catch (error) {
      if (error instanceof AlertasApiError) {
        throw error;
      }
      throw new AlertasApiError('Erro ao salvar alertas', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterAlertas): Promise<IAlertas[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching alertas list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterAlertas): Promise<IAlertas[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all alertas:', error);
      return [];
    }
  }

  async deleteAlertas(id: number): Promise<void> {
    if (id <= 0) {
      throw new AlertasApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof AlertasApiError) {
        throw error;
      }
      throw new AlertasApiError('Erro ao excluir alertas', 500, 'DELETE_ERROR', error);
    }
  }

  validateAlertas(alertas: IAlertas): { isValid: boolean; errors: string[] } {
    return AlertasValidator.validateAlertas(alertas);
  }
}