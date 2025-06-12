'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { HistoricoApi, HistoricoApiError } from '../Apis/ApiHistorico';
import { FilterHistorico } from '../Filters/Historico';
import { IHistorico } from '../Interfaces/interface.Historico';

export class HistoricoValidator {
  static validateHistorico(historico: IHistorico): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IHistoricoService {
  fetchHistoricoById: (id: number) => Promise<IHistorico>;
  saveHistorico: (historico: IHistorico) => Promise<IHistorico>;  
  
  getAll: (filtro?: FilterHistorico) => Promise<IHistorico[]>;
  deleteHistorico: (id: number) => Promise<void>;
  validateHistorico: (historico: IHistorico) => { isValid: boolean; errors: string[] };
}

export class HistoricoService implements IHistoricoService {
  constructor(private api: HistoricoApi) {}

  async fetchHistoricoById(id: number): Promise<IHistorico> {
    if (id <= 0) {
      throw new HistoricoApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof HistoricoApiError) {
        throw error;
      }
      throw new HistoricoApiError('Erro ao buscar historico', 500, 'FETCH_ERROR', error);
    }
  }

  async saveHistorico(historico: IHistorico): Promise<IHistorico> {    
    const validation = this.validateHistorico(historico);
    if (!validation.isValid) {
      throw new HistoricoApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(historico);
      return response.data;
    } catch (error) {
      if (error instanceof HistoricoApiError) {
        throw error;
      }
      throw new HistoricoApiError('Erro ao salvar historico', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterHistorico): Promise<IHistorico[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all historico:', error);
      return [];
    }
  }

  async deleteHistorico(id: number): Promise<void> {
    if (id <= 0) {
      throw new HistoricoApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof HistoricoApiError) {
        throw error;
      }
      throw new HistoricoApiError('Erro ao excluir historico', 500, 'DELETE_ERROR', error);
    }
  }

  validateHistorico(historico: IHistorico): { isValid: boolean; errors: string[] } {
    return HistoricoValidator.validateHistorico(historico);
  }
}