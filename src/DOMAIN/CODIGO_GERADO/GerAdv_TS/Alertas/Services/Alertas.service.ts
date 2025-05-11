"use client";
import { AlertasApi } from "../Apis/ApiAlertas";
import { IAlertas } from "../Interfaces/interface.Alertas";
import { FilterAlertas } from "../Filters/Alertas";

  export interface IAlertasService {
    fetchAlertasById: (id: number) => Promise<IAlertas>;
    saveAlertas: (alertas: IAlertas) => Promise<IAlertas>;
    getList: (filtro?: FilterAlertas) => Promise<IAlertas[]>;
  }
  
  export class AlertasService implements IAlertasService {
    constructor(private api: AlertasApi) {}
  
    async fetchAlertasById(id: number): Promise<IAlertas> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveAlertas(alertas: IAlertas): Promise<IAlertas> {
      const response = await this.api.addAndUpdate(alertas as IAlertas);
      return response.data;
    }
 
   async getList(filtro?: FilterAlertas): Promise<IAlertas[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching alertas:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterAlertas): Promise<IAlertas[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching alertas:', error);
      return [];
    }
  }

  }