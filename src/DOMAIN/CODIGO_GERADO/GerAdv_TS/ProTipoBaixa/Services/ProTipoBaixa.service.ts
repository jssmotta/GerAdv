'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ProTipoBaixaApi, ProTipoBaixaApiError } from '../Apis/ApiProTipoBaixa';
import { FilterProTipoBaixa } from '../Filters/ProTipoBaixa';
import { IProTipoBaixa } from '../Interfaces/interface.ProTipoBaixa';

export class ProTipoBaixaValidator {
  static validateProTipoBaixa(protipobaixa: IProTipoBaixa): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IProTipoBaixaService {
  fetchProTipoBaixaById: (id: number) => Promise<IProTipoBaixa>;
  saveProTipoBaixa: (protipobaixa: IProTipoBaixa) => Promise<IProTipoBaixa>;  
  getList: (filtro?: FilterProTipoBaixa) => Promise<IProTipoBaixa[]>;
  getAll: (filtro?: FilterProTipoBaixa) => Promise<IProTipoBaixa[]>;
  deleteProTipoBaixa: (id: number) => Promise<void>;
  validateProTipoBaixa: (protipobaixa: IProTipoBaixa) => { isValid: boolean; errors: string[] };
}

export class ProTipoBaixaService implements IProTipoBaixaService {
  constructor(private api: ProTipoBaixaApi) {}

  async fetchProTipoBaixaById(id: number): Promise<IProTipoBaixa> {
    if (id <= 0) {
      throw new ProTipoBaixaApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof ProTipoBaixaApiError) {
        throw error;
      }
      throw new ProTipoBaixaApiError('Erro ao buscar protipobaixa', 500, 'FETCH_ERROR', error);
    }
  }

  async saveProTipoBaixa(protipobaixa: IProTipoBaixa): Promise<IProTipoBaixa> {    
    const validation = this.validateProTipoBaixa(protipobaixa);
    if (!validation.isValid) {
      throw new ProTipoBaixaApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(protipobaixa);
      return response.data;
    } catch (error) {
      if (error instanceof ProTipoBaixaApiError) {
        throw error;
      }
      throw new ProTipoBaixaApiError('Erro ao salvar protipobaixa', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterProTipoBaixa): Promise<IProTipoBaixa[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching protipobaixa list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterProTipoBaixa): Promise<IProTipoBaixa[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all protipobaixa:', error);
      return [];
    }
  }

  async deleteProTipoBaixa(id: number): Promise<void> {
    if (id <= 0) {
      throw new ProTipoBaixaApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ProTipoBaixaApiError) {
        throw error;
      }
      throw new ProTipoBaixaApiError('Erro ao excluir protipobaixa', 500, 'DELETE_ERROR', error);
    }
  }

  validateProTipoBaixa(protipobaixa: IProTipoBaixa): { isValid: boolean; errors: string[] } {
    return ProTipoBaixaValidator.validateProTipoBaixa(protipobaixa);
  }
}