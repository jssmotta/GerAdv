'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { EMPClassRiscosApi, EMPClassRiscosApiError } from '../Apis/ApiEMPClassRiscos';
import { FilterEMPClassRiscos } from '../Filters/EMPClassRiscos';
import { IEMPClassRiscos } from '../Interfaces/interface.EMPClassRiscos';

export class EMPClassRiscosValidator {
  static validateEMPClassRiscos(empclassriscos: IEMPClassRiscos): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface IEMPClassRiscosService {
  fetchEMPClassRiscosById: (id: number) => Promise<IEMPClassRiscos>;
  saveEMPClassRiscos: (empclassriscos: IEMPClassRiscos) => Promise<IEMPClassRiscos>;  
  getList: (filtro?: FilterEMPClassRiscos) => Promise<IEMPClassRiscos[]>;
  getAll: (filtro?: FilterEMPClassRiscos) => Promise<IEMPClassRiscos[]>;
  deleteEMPClassRiscos: (id: number) => Promise<void>;
  validateEMPClassRiscos: (empclassriscos: IEMPClassRiscos) => { isValid: boolean; errors: string[] };
}

export class EMPClassRiscosService implements IEMPClassRiscosService {
  constructor(private api: EMPClassRiscosApi) {}

  async fetchEMPClassRiscosById(id: number): Promise<IEMPClassRiscos> {
    if (id <= 0) {
      throw new EMPClassRiscosApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof EMPClassRiscosApiError) {
        throw error;
      }
      throw new EMPClassRiscosApiError('Erro ao buscar empclassriscos', 500, 'FETCH_ERROR', error);
    }
  }

  async saveEMPClassRiscos(empclassriscos: IEMPClassRiscos): Promise<IEMPClassRiscos> {    
    const validation = this.validateEMPClassRiscos(empclassriscos);
    if (!validation.isValid) {
      throw new EMPClassRiscosApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(empclassriscos);
      return response.data;
    } catch (error) {
      if (error instanceof EMPClassRiscosApiError) {
        throw error;
      }
      throw new EMPClassRiscosApiError('Erro ao salvar empclassriscos', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterEMPClassRiscos): Promise<IEMPClassRiscos[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching empclassriscos list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterEMPClassRiscos): Promise<IEMPClassRiscos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all empclassriscos:', error);
      return [];
    }
  }

  async deleteEMPClassRiscos(id: number): Promise<void> {
    if (id <= 0) {
      throw new EMPClassRiscosApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof EMPClassRiscosApiError) {
        throw error;
      }
      throw new EMPClassRiscosApiError('Erro ao excluir empclassriscos', 500, 'DELETE_ERROR', error);
    }
  }

  validateEMPClassRiscos(empclassriscos: IEMPClassRiscos): { isValid: boolean; errors: string[] } {
    return EMPClassRiscosValidator.validateEMPClassRiscos(empclassriscos);
  }
}