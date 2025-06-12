'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { HonorariosDadosContratoApi, HonorariosDadosContratoApiError } from '../Apis/ApiHonorariosDadosContrato';
import { FilterHonorariosDadosContrato } from '../Filters/HonorariosDadosContrato';
import { IHonorariosDadosContrato } from '../Interfaces/interface.HonorariosDadosContrato';

export class HonorariosDadosContratoValidator {
  static validateHonorariosDadosContrato(honorariosdadoscontrato: IHonorariosDadosContrato): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IHonorariosDadosContratoService {
  fetchHonorariosDadosContratoById: (id: number) => Promise<IHonorariosDadosContrato>;
  saveHonorariosDadosContrato: (honorariosdadoscontrato: IHonorariosDadosContrato) => Promise<IHonorariosDadosContrato>;  
  
  getAll: (filtro?: FilterHonorariosDadosContrato) => Promise<IHonorariosDadosContrato[]>;
  deleteHonorariosDadosContrato: (id: number) => Promise<void>;
  validateHonorariosDadosContrato: (honorariosdadoscontrato: IHonorariosDadosContrato) => { isValid: boolean; errors: string[] };
}

export class HonorariosDadosContratoService implements IHonorariosDadosContratoService {
  constructor(private api: HonorariosDadosContratoApi) {}

  async fetchHonorariosDadosContratoById(id: number): Promise<IHonorariosDadosContrato> {
    if (id <= 0) {
      throw new HonorariosDadosContratoApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof HonorariosDadosContratoApiError) {
        throw error;
      }
      throw new HonorariosDadosContratoApiError('Erro ao buscar honorariosdadoscontrato', 500, 'FETCH_ERROR', error);
    }
  }

  async saveHonorariosDadosContrato(honorariosdadoscontrato: IHonorariosDadosContrato): Promise<IHonorariosDadosContrato> {    
    const validation = this.validateHonorariosDadosContrato(honorariosdadoscontrato);
    if (!validation.isValid) {
      throw new HonorariosDadosContratoApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(honorariosdadoscontrato);
      return response.data;
    } catch (error) {
      if (error instanceof HonorariosDadosContratoApiError) {
        throw error;
      }
      throw new HonorariosDadosContratoApiError('Erro ao salvar honorariosdadoscontrato', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterHonorariosDadosContrato): Promise<IHonorariosDadosContrato[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all honorariosdadoscontrato:', error);
      return [];
    }
  }

  async deleteHonorariosDadosContrato(id: number): Promise<void> {
    if (id <= 0) {
      throw new HonorariosDadosContratoApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof HonorariosDadosContratoApiError) {
        throw error;
      }
      throw new HonorariosDadosContratoApiError('Erro ao excluir honorariosdadoscontrato', 500, 'DELETE_ERROR', error);
    }
  }

  validateHonorariosDadosContrato(honorariosdadoscontrato: IHonorariosDadosContrato): { isValid: boolean; errors: string[] } {
    return HonorariosDadosContratoValidator.validateHonorariosDadosContrato(honorariosdadoscontrato);
  }
}