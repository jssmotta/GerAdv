"use client";
import { TipoEMailApi } from "../Apis/ApiTipoEMail";
import { ITipoEMail } from "../Interfaces/interface.TipoEMail";
import { FilterTipoEMail } from "../Filters/TipoEMail";

  export interface ITipoEMailService {
    fetchTipoEMailById: (id: number) => Promise<ITipoEMail>;
    saveTipoEMail: (tipoemail: ITipoEMail) => Promise<ITipoEMail>;
    getList: (filtro?: FilterTipoEMail) => Promise<ITipoEMail[]>;
  }
  
  export class TipoEMailService implements ITipoEMailService {
    constructor(private api: TipoEMailApi) {}
  
    async fetchTipoEMailById(id: number): Promise<ITipoEMail> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveTipoEMail(tipoemail: ITipoEMail): Promise<ITipoEMail> {
      const response = await this.api.addAndUpdate(tipoemail as ITipoEMail);
      return response.data;
    }
 
   async getList(filtro?: FilterTipoEMail): Promise<ITipoEMail[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching tipoemail:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterTipoEMail): Promise<ITipoEMail[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching tipoemail:', error);
      return [];
    }
  }

  }