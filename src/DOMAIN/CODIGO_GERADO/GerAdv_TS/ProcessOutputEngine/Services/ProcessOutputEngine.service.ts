"use client";
import { ProcessOutputEngineApi } from "../Apis/ApiProcessOutputEngine";
import { IProcessOutputEngine } from "../Interfaces/interface.ProcessOutputEngine";
import { FilterProcessOutputEngine } from "../Filters/ProcessOutputEngine";

  export interface IProcessOutputEngineService {
    fetchProcessOutputEngineById: (id: number) => Promise<IProcessOutputEngine>;
    saveProcessOutputEngine: (processoutputengine: IProcessOutputEngine) => Promise<IProcessOutputEngine>;
    getList: (filtro?: FilterProcessOutputEngine) => Promise<IProcessOutputEngine[]>;
  }
  
  export class ProcessOutputEngineService implements IProcessOutputEngineService {
    constructor(private api: ProcessOutputEngineApi) {}
  
    async fetchProcessOutputEngineById(id: number): Promise<IProcessOutputEngine> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveProcessOutputEngine(processoutputengine: IProcessOutputEngine): Promise<IProcessOutputEngine> {
      const response = await this.api.addAndUpdate(processoutputengine as IProcessOutputEngine);
      return response.data;
    }
 
   async getList(filtro?: FilterProcessOutputEngine): Promise<IProcessOutputEngine[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching processoutputengine:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterProcessOutputEngine): Promise<IProcessOutputEngine[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching processoutputengine:', error);
      return [];
    }
  }

  }