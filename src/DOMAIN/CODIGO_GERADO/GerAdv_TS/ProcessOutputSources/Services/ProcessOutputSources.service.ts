"use client";
import { ProcessOutputSourcesApi } from "../Apis/ApiProcessOutputSources";
import { IProcessOutputSources } from "../Interfaces/interface.ProcessOutputSources";
import { FilterProcessOutputSources } from "../Filters/ProcessOutputSources";

  export interface IProcessOutputSourcesService {
    fetchProcessOutputSourcesById: (id: number) => Promise<IProcessOutputSources>;
    saveProcessOutputSources: (processoutputsources: IProcessOutputSources) => Promise<IProcessOutputSources>;
    getList: (filtro?: FilterProcessOutputSources) => Promise<IProcessOutputSources[]>;
  }
  
  export class ProcessOutputSourcesService implements IProcessOutputSourcesService {
    constructor(private api: ProcessOutputSourcesApi) {}
  
    async fetchProcessOutputSourcesById(id: number): Promise<IProcessOutputSources> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveProcessOutputSources(processoutputsources: IProcessOutputSources): Promise<IProcessOutputSources> {
      const response = await this.api.addAndUpdate(processoutputsources as IProcessOutputSources);
      return response.data;
    }
 
   async getList(filtro?: FilterProcessOutputSources): Promise<IProcessOutputSources[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching processoutputsources:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterProcessOutputSources): Promise<IProcessOutputSources[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching processoutputsources:', error);
      return [];
    }
  }

  }