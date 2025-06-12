'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { GraphApi, GraphApiError } from '../Apis/ApiGraph';
import { FilterGraph } from '../Filters/Graph';
import { IGraph } from '../Interfaces/interface.Graph';

export class GraphValidator {
  static validateGraph(graph: IGraph): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IGraphService {
  fetchGraphById: (id: number) => Promise<IGraph>;
  saveGraph: (graph: IGraph) => Promise<IGraph>;  
  
  getAll: (filtro?: FilterGraph) => Promise<IGraph[]>;
  deleteGraph: (id: number) => Promise<void>;
  validateGraph: (graph: IGraph) => { isValid: boolean; errors: string[] };
}

export class GraphService implements IGraphService {
  constructor(private api: GraphApi) {}

  async fetchGraphById(id: number): Promise<IGraph> {
    if (id <= 0) {
      throw new GraphApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof GraphApiError) {
        throw error;
      }
      throw new GraphApiError('Erro ao buscar graph', 500, 'FETCH_ERROR', error);
    }
  }

  async saveGraph(graph: IGraph): Promise<IGraph> {    
    const validation = this.validateGraph(graph);
    if (!validation.isValid) {
      throw new GraphApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(graph);
      return response.data;
    } catch (error) {
      if (error instanceof GraphApiError) {
        throw error;
      }
      throw new GraphApiError('Erro ao salvar graph', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterGraph): Promise<IGraph[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all graph:', error);
      return [];
    }
  }

  async deleteGraph(id: number): Promise<void> {
    if (id <= 0) {
      throw new GraphApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof GraphApiError) {
        throw error;
      }
      throw new GraphApiError('Erro ao excluir graph', 500, 'DELETE_ERROR', error);
    }
  }

  validateGraph(graph: IGraph): { isValid: boolean; errors: string[] } {
    return GraphValidator.validateGraph(graph);
  }
}