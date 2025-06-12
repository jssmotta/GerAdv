'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { ProcessosObsReportApi, ProcessosObsReportApiError } from '../Apis/ApiProcessosObsReport';
import { FilterProcessosObsReport } from '../Filters/ProcessosObsReport';
import { IProcessosObsReport } from '../Interfaces/interface.ProcessosObsReport';

export class ProcessosObsReportValidator {
  static validateProcessosObsReport(processosobsreport: IProcessosObsReport): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IProcessosObsReportService {
  fetchProcessosObsReportById: (id: number) => Promise<IProcessosObsReport>;
  saveProcessosObsReport: (processosobsreport: IProcessosObsReport) => Promise<IProcessosObsReport>;  
  
  getAll: (filtro?: FilterProcessosObsReport) => Promise<IProcessosObsReport[]>;
  deleteProcessosObsReport: (id: number) => Promise<void>;
  validateProcessosObsReport: (processosobsreport: IProcessosObsReport) => { isValid: boolean; errors: string[] };
}

export class ProcessosObsReportService implements IProcessosObsReportService {
  constructor(private api: ProcessosObsReportApi) {}

  async fetchProcessosObsReportById(id: number): Promise<IProcessosObsReport> {
    if (id <= 0) {
      throw new ProcessosObsReportApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof ProcessosObsReportApiError) {
        throw error;
      }
      throw new ProcessosObsReportApiError('Erro ao buscar processosobsreport', 500, 'FETCH_ERROR', error);
    }
  }

  async saveProcessosObsReport(processosobsreport: IProcessosObsReport): Promise<IProcessosObsReport> {    
    const validation = this.validateProcessosObsReport(processosobsreport);
    if (!validation.isValid) {
      throw new ProcessosObsReportApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(processosobsreport);
      return response.data;
    } catch (error) {
      if (error instanceof ProcessosObsReportApiError) {
        throw error;
      }
      throw new ProcessosObsReportApiError('Erro ao salvar processosobsreport', 500, 'SAVE_ERROR', error);
    }
  }

  
 

  async getAll(filtro?: FilterProcessosObsReport): Promise<IProcessosObsReport[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all processosobsreport:', error);
      return [];
    }
  }

  async deleteProcessosObsReport(id: number): Promise<void> {
    if (id <= 0) {
      throw new ProcessosObsReportApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof ProcessosObsReportApiError) {
        throw error;
      }
      throw new ProcessosObsReportApiError('Erro ao excluir processosobsreport', 500, 'DELETE_ERROR', error);
    }
  }

  validateProcessosObsReport(processosobsreport: IProcessosObsReport): { isValid: boolean; errors: string[] } {
    return ProcessosObsReportValidator.validateProcessosObsReport(processosobsreport);
  }
}