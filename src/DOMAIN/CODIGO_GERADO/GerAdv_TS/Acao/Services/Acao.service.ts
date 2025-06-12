'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { AcaoApi, AcaoApiError } from '../Apis/ApiAcao';
import { FilterAcao } from '../Filters/Acao';
import { IAcao } from '../Interfaces/interface.Acao';

export class AcaoValidator {
  static validateAcao(acao: IAcao): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IAcaoService {
  fetchAcaoById: (id: number) => Promise<IAcao>;
  saveAcao: (acao: IAcao) => Promise<IAcao>;  
  getList: (filtro?: FilterAcao) => Promise<IAcao[]>;
  getAll: (filtro?: FilterAcao) => Promise<IAcao[]>;
  deleteAcao: (id: number) => Promise<void>;
  validateAcao: (acao: IAcao) => { isValid: boolean; errors: string[] };
}

export class AcaoService implements IAcaoService {
  constructor(private api: AcaoApi) {}

  async fetchAcaoById(id: number): Promise<IAcao> {
    if (id <= 0) {
      throw new AcaoApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof AcaoApiError) {
        throw error;
      }
      throw new AcaoApiError('Erro ao buscar acao', 500, 'FETCH_ERROR', error);
    }
  }

  async saveAcao(acao: IAcao): Promise<IAcao> {    
    const validation = this.validateAcao(acao);
    if (!validation.isValid) {
      throw new AcaoApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(acao);
      return response.data;
    } catch (error) {
      if (error instanceof AcaoApiError) {
        throw error;
      }
      throw new AcaoApiError('Erro ao salvar acao', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterAcao): Promise<IAcao[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching acao list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterAcao): Promise<IAcao[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all acao:', error);
      return [];
    }
  }

  async deleteAcao(id: number): Promise<void> {
    if (id <= 0) {
      throw new AcaoApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof AcaoApiError) {
        throw error;
      }
      throw new AcaoApiError('Erro ao excluir acao', 500, 'DELETE_ERROR', error);
    }
  }

  validateAcao(acao: IAcao): { isValid: boolean; errors: string[] } {
    return AcaoValidator.validateAcao(acao);
  }
}