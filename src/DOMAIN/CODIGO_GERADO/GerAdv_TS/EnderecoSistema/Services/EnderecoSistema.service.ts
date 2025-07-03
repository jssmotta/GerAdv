'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { EnderecoSistemaApi, EnderecoSistemaApiError } from '../Apis/ApiEnderecoSistema';
import { FilterEnderecoSistema } from '../Filters/EnderecoSistema';
import { IEnderecoSistema } from '../Interfaces/interface.EnderecoSistema';
import { EnderecoSistemaEmpty } from '../../Models/EnderecoSistema';

export class EnderecoSistemaValidator {
  static validateEnderecoSistema(enderecosistema: IEnderecoSistema): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IEnderecoSistemaService {
  fetchEnderecoSistemaById: (id: number) => Promise<IEnderecoSistema>;
  saveEnderecoSistema: (enderecosistema: IEnderecoSistema) => Promise<IEnderecoSistema>;  
  
  getAll: (filtro?: FilterEnderecoSistema) => Promise<IEnderecoSistema[]>;
  deleteEnderecoSistema: (id: number) => Promise<void>;
  validateEnderecoSistema: (enderecosistema: IEnderecoSistema) => { isValid: boolean; errors: string[] };
}

export class EnderecoSistemaService implements IEnderecoSistemaService {
  constructor(private api: EnderecoSistemaApi) {}

  async fetchEnderecoSistemaById(id: number): Promise<IEnderecoSistema> {
    if (id <= 0) {
      throw new EnderecoSistemaApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      
      const response = await this.api.getById(id);
      return response.data;

    } catch (error) {
      if (error instanceof EnderecoSistemaApiError) {
        throw error;
      }
      throw new EnderecoSistemaApiError('Erro ao buscar enderecosistema', 500, 'FETCH_ERROR', error);
    }
  }

  async saveEnderecoSistema(enderecosistema: IEnderecoSistema): Promise<IEnderecoSistema> {    
    const validation = this.validateEnderecoSistema(enderecosistema);
    if (!validation.isValid) {
      throw new EnderecoSistemaApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(enderecosistema);
      return response.data;
    } catch (error) {
      if (error instanceof EnderecoSistemaApiError) {
        throw error;
      }
      throw new EnderecoSistemaApiError('Erro ao salvar enderecosistema', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterEnderecoSistema): Promise<IEnderecoSistema[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all enderecosistema:', error);
      return [];
    }
  }

  async deleteEnderecoSistema(id: number): Promise<void> {
    if (id <= 0) {
      throw new EnderecoSistemaApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof EnderecoSistemaApiError) {
        throw error;
      }
      throw new EnderecoSistemaApiError('Erro ao excluir enderecosistema', 500, 'DELETE_ERROR', error);
    }
  }

  validateEnderecoSistema(enderecosistema: IEnderecoSistema): { isValid: boolean; errors: string[] } {
    return EnderecoSistemaValidator.validateEnderecoSistema(enderecosistema);
  }
}