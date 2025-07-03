'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { EnquadramentoEmpresaApi, EnquadramentoEmpresaApiError } from '../Apis/ApiEnquadramentoEmpresa';
import { FilterEnquadramentoEmpresa } from '../Filters/EnquadramentoEmpresa';
import { IEnquadramentoEmpresa } from '../Interfaces/interface.EnquadramentoEmpresa';
import { EnquadramentoEmpresaEmpty } from '../../Models/EnquadramentoEmpresa';

export class EnquadramentoEmpresaValidator {
  static validateEnquadramentoEmpresa(enquadramentoempresa: IEnquadramentoEmpresa): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IEnquadramentoEmpresaService {
  fetchEnquadramentoEmpresaById: (id: number) => Promise<IEnquadramentoEmpresa>;
  saveEnquadramentoEmpresa: (enquadramentoempresa: IEnquadramentoEmpresa) => Promise<IEnquadramentoEmpresa>;  
  getList: (filtro?: FilterEnquadramentoEmpresa) => Promise<IEnquadramentoEmpresa[]>;
  getAll: (filtro?: FilterEnquadramentoEmpresa) => Promise<IEnquadramentoEmpresa[]>;
  deleteEnquadramentoEmpresa: (id: number) => Promise<void>;
  validateEnquadramentoEmpresa: (enquadramentoempresa: IEnquadramentoEmpresa) => { isValid: boolean; errors: string[] };
}

export class EnquadramentoEmpresaService implements IEnquadramentoEmpresaService {
  constructor(private api: EnquadramentoEmpresaApi) {}

  async fetchEnquadramentoEmpresaById(id: number): Promise<IEnquadramentoEmpresa> {
    if (id <= 0) {
      throw new EnquadramentoEmpresaApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof EnquadramentoEmpresaApiError) {
        throw error;
      }
      throw new EnquadramentoEmpresaApiError('Erro ao buscar enquadramentoempresa', 500, 'FETCH_ERROR', error);
    }
  }

  async saveEnquadramentoEmpresa(enquadramentoempresa: IEnquadramentoEmpresa): Promise<IEnquadramentoEmpresa> {    
    const validation = this.validateEnquadramentoEmpresa(enquadramentoempresa);
    if (!validation.isValid) {
      throw new EnquadramentoEmpresaApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(enquadramentoempresa);
      return response.data;
    } catch (error) {
      if (error instanceof EnquadramentoEmpresaApiError) {
        throw error;
      }
      throw new EnquadramentoEmpresaApiError('Erro ao salvar enquadramentoempresa', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterEnquadramentoEmpresa): Promise<IEnquadramentoEmpresa[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching enquadramentoempresa list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterEnquadramentoEmpresa): Promise<IEnquadramentoEmpresa[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all enquadramentoempresa:', error);
      return [];
    }
  }

  async deleteEnquadramentoEmpresa(id: number): Promise<void> {
    if (id <= 0) {
      throw new EnquadramentoEmpresaApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof EnquadramentoEmpresaApiError) {
        throw error;
      }
      throw new EnquadramentoEmpresaApiError('Erro ao excluir enquadramentoempresa', 500, 'DELETE_ERROR', error);
    }
  }

  validateEnquadramentoEmpresa(enquadramentoempresa: IEnquadramentoEmpresa): { isValid: boolean; errors: string[] } {
    return EnquadramentoEmpresaValidator.validateEnquadramentoEmpresa(enquadramentoempresa);
  }
}