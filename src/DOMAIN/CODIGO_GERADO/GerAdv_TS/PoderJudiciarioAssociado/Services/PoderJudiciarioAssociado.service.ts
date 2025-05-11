"use client";
import { PoderJudiciarioAssociadoApi } from "../Apis/ApiPoderJudiciarioAssociado";
import { IPoderJudiciarioAssociado } from "../Interfaces/interface.PoderJudiciarioAssociado";
import { FilterPoderJudiciarioAssociado } from "../Filters/PoderJudiciarioAssociado";

  export interface IPoderJudiciarioAssociadoService {
    fetchPoderJudiciarioAssociadoById: (id: number) => Promise<IPoderJudiciarioAssociado>;
    savePoderJudiciarioAssociado: (poderjudiciarioassociado: IPoderJudiciarioAssociado) => Promise<IPoderJudiciarioAssociado>;
    
  }
  
  export class PoderJudiciarioAssociadoService implements IPoderJudiciarioAssociadoService {
    constructor(private api: PoderJudiciarioAssociadoApi) {}
  
    async fetchPoderJudiciarioAssociadoById(id: number): Promise<IPoderJudiciarioAssociado> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async savePoderJudiciarioAssociado(poderjudiciarioassociado: IPoderJudiciarioAssociado): Promise<IPoderJudiciarioAssociado> {
      const response = await this.api.addAndUpdate(poderjudiciarioassociado as IPoderJudiciarioAssociado);
      return response.data;
    }
 
   async getAll(filtro?: FilterPoderJudiciarioAssociado): Promise<IPoderJudiciarioAssociado[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching poderjudiciarioassociado:', error);
      return [];
    }
  }

  }