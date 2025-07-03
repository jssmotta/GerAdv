'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { GruposEmpresasApi, GruposEmpresasApiError } from '../Apis/ApiGruposEmpresas';
import { FilterGruposEmpresas } from '../Filters/GruposEmpresas';
import { IGruposEmpresas } from '../Interfaces/interface.GruposEmpresas';
import { GruposEmpresasEmpty } from '../../Models/GruposEmpresas';

export class GruposEmpresasValidator {
  static validateGruposEmpresas(gruposempresas: IGruposEmpresas): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IGruposEmpresasService {
  fetchGruposEmpresasById: (id: number) => Promise<IGruposEmpresas>;
  saveGruposEmpresas: (gruposempresas: IGruposEmpresas) => Promise<IGruposEmpresas>;  
  getList: (filtro?: FilterGruposEmpresas) => Promise<IGruposEmpresas[]>;
  getAll: (filtro?: FilterGruposEmpresas) => Promise<IGruposEmpresas[]>;
  deleteGruposEmpresas: (id: number) => Promise<void>;
  validateGruposEmpresas: (gruposempresas: IGruposEmpresas) => { isValid: boolean; errors: string[] };
}

export class GruposEmpresasService implements IGruposEmpresasService {
  constructor(private api: GruposEmpresasApi) {}

  async fetchGruposEmpresasById(id: number): Promise<IGruposEmpresas> {
    if (id <= 0) {
      throw new GruposEmpresasApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof GruposEmpresasApiError) {
        throw error;
      }
      throw new GruposEmpresasApiError('Erro ao buscar gruposempresas', 500, 'FETCH_ERROR', error);
    }
  }

  async saveGruposEmpresas(gruposempresas: IGruposEmpresas): Promise<IGruposEmpresas> {    
    const validation = this.validateGruposEmpresas(gruposempresas);
    if (!validation.isValid) {
      throw new GruposEmpresasApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(gruposempresas);
      return response.data;
    } catch (error) {
      if (error instanceof GruposEmpresasApiError) {
        throw error;
      }
      throw new GruposEmpresasApiError('Erro ao salvar gruposempresas', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterGruposEmpresas): Promise<IGruposEmpresas[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching gruposempresas list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterGruposEmpresas): Promise<IGruposEmpresas[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all gruposempresas:', error);
      return [];
    }
  }

  async deleteGruposEmpresas(id: number): Promise<void> {
    if (id <= 0) {
      throw new GruposEmpresasApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof GruposEmpresasApiError) {
        throw error;
      }
      throw new GruposEmpresasApiError('Erro ao excluir gruposempresas', 500, 'DELETE_ERROR', error);
    }
  }

  validateGruposEmpresas(gruposempresas: IGruposEmpresas): { isValid: boolean; errors: string[] } {
    return GruposEmpresasValidator.validateGruposEmpresas(gruposempresas);
  }
}