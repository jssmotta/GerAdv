"use client";
import { AlertasEnviadosApi } from "../Apis/ApiAlertasEnviados";
import { IAlertasEnviados } from "../Interfaces/interface.AlertasEnviados";
import { FilterAlertasEnviados } from "../Filters/AlertasEnviados";

  export interface IAlertasEnviadosService {
    fetchAlertasEnviadosById: (id: number) => Promise<IAlertasEnviados>;
    saveAlertasEnviados: (alertasenviados: IAlertasEnviados) => Promise<IAlertasEnviados>;
    
  }
  
  export class AlertasEnviadosService implements IAlertasEnviadosService {
    constructor(private api: AlertasEnviadosApi) {}
  
    async fetchAlertasEnviadosById(id: number): Promise<IAlertasEnviados> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveAlertasEnviados(alertasenviados: IAlertasEnviados): Promise<IAlertasEnviados> {
      const response = await this.api.addAndUpdate(alertasenviados as IAlertasEnviados);
      return response.data;
    }
 
   async getAll(filtro?: FilterAlertasEnviados): Promise<IAlertasEnviados[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching alertasenviados:', error);
      return [];
    }
  }

  }