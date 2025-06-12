'use client';
import { CRUD_CONSTANTS } from '@/app/tools/crud';
import { TipoEMailApi, TipoEMailApiError } from '../Apis/ApiTipoEMail';
import { FilterTipoEMail } from '../Filters/TipoEMail';
import { ITipoEMail } from '../Interfaces/interface.TipoEMail';

export class TipoEMailValidator {
  static validateTipoEMail(tipoemail: ITipoEMail): { isValid: boolean; errors: string[] } {
    const errors: string[] = [];

    // Atualmente não há validações de regras de negócio específicas
    // Todas as validações são feitas nos inputs correspondentes
    
    return {
      isValid: errors.length === 0,
      errors
    };
  }
}

export interface ITipoEMailService {
  fetchTipoEMailById: (id: number) => Promise<ITipoEMail>;
  saveTipoEMail: (tipoemail: ITipoEMail) => Promise<ITipoEMail>;  
  getList: (filtro?: FilterTipoEMail) => Promise<ITipoEMail[]>;
  getAll: (filtro?: FilterTipoEMail) => Promise<ITipoEMail[]>;
  deleteTipoEMail: (id: number) => Promise<void>;
  validateTipoEMail: (tipoemail: ITipoEMail) => { isValid: boolean; errors: string[] };
}

export class TipoEMailService implements ITipoEMailService {
  constructor(private api: TipoEMailApi) {}

  async fetchTipoEMailById(id: number): Promise<ITipoEMail> {
    if (id <= 0) {
      throw new TipoEMailApiError('ID inválido', 400, 'INVALID_ID');
    }

    try {
      const response = await this.api.getById(id);
      return response.data;
    } catch (error) {
      if (error instanceof TipoEMailApiError) {
        throw error;
      }
      throw new TipoEMailApiError('Erro ao buscar tipoemail', 500, 'FETCH_ERROR', error);
    }
  }

  async saveTipoEMail(tipoemail: ITipoEMail): Promise<ITipoEMail> {    
    const validation = this.validateTipoEMail(tipoemail);
    if (!validation.isValid) {
      throw new TipoEMailApiError(
        `Dados inválidos: ${validation.errors.join(', ')}`,
        400,
        'VALIDATION_ERROR'
      );
    }

    try {
      const response = await this.api.addAndUpdate(tipoemail);
      return response.data;
    } catch (error) {
      if (error instanceof TipoEMailApiError) {
        throw error;
      }
      throw new TipoEMailApiError('Erro ao salvar tipoemail', 500, 'SAVE_ERROR', error);
    }
  }

  
    async getList(filtro?: FilterTipoEMail): Promise<ITipoEMail[]> {
    try {
      const response = await this.api.getListN(CRUD_CONSTANTS.MAX_RECORDS_COMBO, filtro);
      return response.data || [];
    } catch (error) {
      console.error('Error fetching tipoemail list:', error);
      return [];
    }
  }

 
 

  async getAll(filtro?: FilterTipoEMail): Promise<ITipoEMail[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data || [];
    } catch (error) {
      console.error('Error fetching all tipoemail:', error);
      return [];
    }
  }

  async deleteTipoEMail(id: number): Promise<void> {
    if (id <= 0) {
      throw new TipoEMailApiError('ID inválido para exclusão', 400, 'INVALID_ID');
    }

    try {
      await this.api.delete(id);
    } catch (error) {
      if (error instanceof TipoEMailApiError) {
        throw error;
      }
      throw new TipoEMailApiError('Erro ao excluir tipoemail', 500, 'DELETE_ERROR', error);
    }
  }

  validateTipoEMail(tipoemail: ITipoEMail): { isValid: boolean; errors: string[] } {
    return TipoEMailValidator.validateTipoEMail(tipoemail);
  }
}