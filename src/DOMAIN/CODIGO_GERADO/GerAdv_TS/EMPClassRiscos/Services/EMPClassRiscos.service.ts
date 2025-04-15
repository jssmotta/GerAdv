"use client";
import { EMPClassRiscosApi } from "../Apis/ApiEMPClassRiscos";
import { IEMPClassRiscos } from "../Interfaces/interface.EMPClassRiscos";
import { FilterEMPClassRiscos } from "../Filters/EMPClassRiscos";

  export interface IEMPClassRiscosService {
    fetchEMPClassRiscosById: (id: number) => Promise<IEMPClassRiscos>;
    saveEMPClassRiscos: (empclassriscos: IEMPClassRiscos) => Promise<IEMPClassRiscos>;
    getList: (filtro?: FilterEMPClassRiscos) => Promise<IEMPClassRiscos[]>;
  }
  
  export class EMPClassRiscosService implements IEMPClassRiscosService {
    constructor(private api: EMPClassRiscosApi) {}
  
    async fetchEMPClassRiscosById(id: number): Promise<IEMPClassRiscos> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveEMPClassRiscos(empclassriscos: IEMPClassRiscos): Promise<IEMPClassRiscos> {
      const response = await this.api.addAndUpdate(empclassriscos as IEMPClassRiscos);
      return response.data;
    }
 
   async getList(filtro?: FilterEMPClassRiscos): Promise<IEMPClassRiscos[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching empclassriscos:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterEMPClassRiscos): Promise<IEMPClassRiscos[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching empclassriscos:', error);
      return [];
    }
  }

  }