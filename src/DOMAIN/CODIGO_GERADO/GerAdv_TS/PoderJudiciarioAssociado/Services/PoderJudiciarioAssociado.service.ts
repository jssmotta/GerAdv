'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { PoderJudiciarioAssociadoApi, PoderJudiciarioAssociadoApiError } from '../Apis/ApiPoderJudiciarioAssociado';
import { FilterPoderJudiciarioAssociado } from '../Filters/PoderJudiciarioAssociado';
import { IPoderJudiciarioAssociado } from '../Interfaces/interface.PoderJudiciarioAssociado';

export class PoderJudiciarioAssociadoValidator {
  static validatePoderJudiciarioAssociado(poderjudiciarioassociado: IPoderJudiciarioAssociado): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IPoderJudiciarioAssociadoService {
  fetchPoderJudiciarioAssociadoById: (id: number) => Promise<IPoderJudiciarioAssociado>;
  savePoderJudiciarioAssociado: (poderjudiciarioassociado: IPoderJudiciarioAssociado) => Promise<IPoderJudiciarioAssociado>;  
  
  getAll: (filtro?: FilterPoderJudiciarioAssociado) => Promise<IPoderJudiciarioAssociado[]>;
  deletePoderJudiciarioAssociado: (id: number) => Promise<void>;
  validatePoderJudiciarioAssociado: (poderjudiciarioassociado: IPoderJudiciarioAssociado) => { isValid: boolean; errors: string[] };
}

export class PoderJudiciarioAssociadoService implements IPoderJudiciarioAssociadoService {
  constructor(private api: PoderJudiciarioAssociadoApi) {}

  async fetchPoderJudiciarioAssociadoById(id: number): Promise<IPoderJudiciarioAssociado> {
    if (id <= 0) {
      throw new PoderJudiciarioAssociadoApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof PoderJudiciarioAssociadoApiError) {
        throw error;
      }
      throw new PoderJudiciarioAssociadoApiError('Erro ao buscar poderjudiciarioassociado', 500, 'FETCH_ERROR', error);
    }
  }

  async savePoderJudiciarioAssociado(poderjudiciarioassociado: IPoderJudiciarioAssociado): Promise<IPoderJudiciarioAssociado> {    
    const validation = this.validatePoderJudiciarioAssociado(poderjudiciarioassociado);
    if (!validation.isValid) {
      throw new PoderJudiciarioAssociadoApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(poderjudiciarioassociado);
      return response.data;
    } catch (error) {
      if (error instanceof PoderJudiciarioAssociadoApiError) {
        throw error;
      }
      throw new PoderJudiciarioAssociadoApiError('Erro ao salvar poderjudiciarioassociado', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterPoderJudiciarioAssociado): Promise<IPoderJudiciarioAssociado[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all poderjudiciarioassociado:', error);
      return [];
    }
  }

  async deletePoderJudiciarioAssociado(id: number): Promise<void> {
    if (id <= 0) {
      throw new PoderJudiciarioAssociadoApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof PoderJudiciarioAssociadoApiError) {
        throw error;
      }
      throw new PoderJudiciarioAssociadoApiError('Erro ao excluir poderjudiciarioassociado', 500, 'DELETE_ERROR', error);
    }
  }

  validatePoderJudiciarioAssociado(poderjudiciarioassociado: IPoderJudiciarioAssociado): { isValid: boolean; errors: string[] } {
    return PoderJudiciarioAssociadoValidator.validatePoderJudiciarioAssociado(poderjudiciarioassociado);
  }
}