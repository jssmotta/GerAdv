'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { GruposEmpresasCliApi, GruposEmpresasCliApiError } from '../Apis/ApiGruposEmpresasCli';
import { FilterGruposEmpresasCli } from '../Filters/GruposEmpresasCli';
import { IGruposEmpresasCli } from '../Interfaces/interface.GruposEmpresasCli';

export class GruposEmpresasCliValidator {
  static validateGruposEmpresasCli(gruposempresascli: IGruposEmpresasCli): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IGruposEmpresasCliService {
  fetchGruposEmpresasCliById: (id: number) => Promise<IGruposEmpresasCli>;
  saveGruposEmpresasCli: (gruposempresascli: IGruposEmpresasCli) => Promise<IGruposEmpresasCli>;  
  
  getAll: (filtro?: FilterGruposEmpresasCli) => Promise<IGruposEmpresasCli[]>;
  deleteGruposEmpresasCli: (id: number) => Promise<void>;
  validateGruposEmpresasCli: (gruposempresascli: IGruposEmpresasCli) => { isValid: boolean; errors: string[] };
}

export class GruposEmpresasCliService implements IGruposEmpresasCliService {
  constructor(private api: GruposEmpresasCliApi) {}

  async fetchGruposEmpresasCliById(id: number): Promise<IGruposEmpresasCli> {
    if (id <= 0) {
      throw new GruposEmpresasCliApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof GruposEmpresasCliApiError) {
        throw error;
      }
      throw new GruposEmpresasCliApiError('Erro ao buscar gruposempresascli', 500, 'FETCH_ERROR', error);
    }
  }

  async saveGruposEmpresasCli(gruposempresascli: IGruposEmpresasCli): Promise<IGruposEmpresasCli> {    
    const validation = this.validateGruposEmpresasCli(gruposempresascli);
    if (!validation.isValid) {
      throw new GruposEmpresasCliApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(gruposempresascli);
      return response.data;
    } catch (error) {
      if (error instanceof GruposEmpresasCliApiError) {
        throw error;
      }
      throw new GruposEmpresasCliApiError('Erro ao salvar gruposempresascli', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterGruposEmpresasCli): Promise<IGruposEmpresasCli[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all gruposempresascli:', error);
      return [];
    }
  }

  async deleteGruposEmpresasCli(id: number): Promise<void> {
    if (id <= 0) {
      throw new GruposEmpresasCliApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof GruposEmpresasCliApiError) {
        throw error;
      }
      throw new GruposEmpresasCliApiError('Erro ao excluir gruposempresascli', 500, 'DELETE_ERROR', error);
    }
  }

  validateGruposEmpresasCli(gruposempresascli: IGruposEmpresasCli): { isValid: boolean; errors: string[] } {
    return GruposEmpresasCliValidator.validateGruposEmpresasCli(gruposempresascli);
  }
}