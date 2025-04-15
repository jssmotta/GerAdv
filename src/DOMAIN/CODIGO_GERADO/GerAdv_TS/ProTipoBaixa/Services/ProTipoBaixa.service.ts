"use client";
import { ProTipoBaixaApi } from "../Apis/ApiProTipoBaixa";
import { IProTipoBaixa } from "../Interfaces/interface.ProTipoBaixa";
import { FilterProTipoBaixa } from "../Filters/ProTipoBaixa";

  export interface IProTipoBaixaService {
    fetchProTipoBaixaById: (id: number) => Promise<IProTipoBaixa>;
    saveProTipoBaixa: (protipobaixa: IProTipoBaixa) => Promise<IProTipoBaixa>;
    getList: (filtro?: FilterProTipoBaixa) => Promise<IProTipoBaixa[]>;
  }
  
  export class ProTipoBaixaService implements IProTipoBaixaService {
    constructor(private api: ProTipoBaixaApi) {}
  
    async fetchProTipoBaixaById(id: number): Promise<IProTipoBaixa> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveProTipoBaixa(protipobaixa: IProTipoBaixa): Promise<IProTipoBaixa> {
      const response = await this.api.addAndUpdate(protipobaixa as IProTipoBaixa);
      return response.data;
    }
 
   async getList(filtro?: FilterProTipoBaixa): Promise<IProTipoBaixa[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching protipobaixa:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterProTipoBaixa): Promise<IProTipoBaixa[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching protipobaixa:', error);
      return [];
    }
  }

  }