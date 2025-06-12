'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { OperadorEMailPopupApi, OperadorEMailPopupApiError } from '../Apis/ApiOperadorEMailPopup';
import { FilterOperadorEMailPopup } from '../Filters/OperadorEMailPopup';
import { IOperadorEMailPopup } from '../Interfaces/interface.OperadorEMailPopup';

export class OperadorEMailPopupValidator {
  static validateOperadorEMailPopup(operadoremailpopup: IOperadorEMailPopup): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IOperadorEMailPopupService {
  fetchOperadorEMailPopupById: (id: number) => Promise<IOperadorEMailPopup>;
  saveOperadorEMailPopup: (operadoremailpopup: IOperadorEMailPopup) => Promise<IOperadorEMailPopup>;  
  getList: (filtro?: FilterOperadorEMailPopup) => Promise<IOperadorEMailPopup[]>;
  getAll: (filtro?: FilterOperadorEMailPopup) => Promise<IOperadorEMailPopup[]>;
  deleteOperadorEMailPopup: (id: number) => Promise<void>;
  validateOperadorEMailPopup: (operadoremailpopup: IOperadorEMailPopup) => { isValid: boolean; errors: string[] };
}

export class OperadorEMailPopupService implements IOperadorEMailPopupService {
  constructor(private api: OperadorEMailPopupApi) {}

  async fetchOperadorEMailPopupById(id: number): Promise<IOperadorEMailPopup> {
    if (id <= 0) {
      throw new OperadorEMailPopupApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof OperadorEMailPopupApiError) {
        throw error;
      }
      throw new OperadorEMailPopupApiError('Erro ao buscar operadoremailpopup', 500, 'FETCH_ERROR', error);
    }
  }

  async saveOperadorEMailPopup(operadoremailpopup: IOperadorEMailPopup): Promise<IOperadorEMailPopup> {    
    const validation = this.validateOperadorEMailPopup(operadoremailpopup);
    if (!validation.isValid) {
      throw new OperadorEMailPopupApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(operadoremailpopup);
      return response.data;
    } catch (error) {
      if (error instanceof OperadorEMailPopupApiError) {
        throw error;
      }
      throw new OperadorEMailPopupApiError('Erro ao salvar operadoremailpopup', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterOperadorEMailPopup): Promise<IOperadorEMailPopup[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching operadoremailpopup list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterOperadorEMailPopup): Promise<IOperadorEMailPopup[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all operadoremailpopup:', error);
      return [];
    }
  }

  async deleteOperadorEMailPopup(id: number): Promise<void> {
    if (id <= 0) {
      throw new OperadorEMailPopupApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof OperadorEMailPopupApiError) {
        throw error;
      }
      throw new OperadorEMailPopupApiError('Erro ao excluir operadoremailpopup', 500, 'DELETE_ERROR', error);
    }
  }

  validateOperadorEMailPopup(operadoremailpopup: IOperadorEMailPopup): { isValid: boolean; errors: string[] } {
    return OperadorEMailPopupValidator.validateOperadorEMailPopup(operadoremailpopup);
  }
}