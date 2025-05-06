"use client";
import { ProcessOutPutIDsApi } from "../Apis/ApiProcessOutPutIDs";
import { IProcessOutPutIDs } from "../Interfaces/interface.ProcessOutPutIDs";
import { FilterProcessOutPutIDs } from "../Filters/ProcessOutPutIDs";

  export interface IProcessOutPutIDsService {
    fetchProcessOutPutIDsById: (id: number) => Promise<IProcessOutPutIDs>;
    saveProcessOutPutIDs: (processoutputids: IProcessOutPutIDs) => Promise<IProcessOutPutIDs>;
    getList: (filtro?: FilterProcessOutPutIDs) => Promise<IProcessOutPutIDs[]>;
  }
  
  export class ProcessOutPutIDsService implements IProcessOutPutIDsService {
    constructor(private api: ProcessOutPutIDsApi) {}
  
    async fetchProcessOutPutIDsById(id: number): Promise<IProcessOutPutIDs> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveProcessOutPutIDs(processoutputids: IProcessOutPutIDs): Promise<IProcessOutPutIDs> {
      const response = await this.api.addAndUpdate(processoutputids as IProcessOutPutIDs);
      return response.data;
    }
 
   async getList(filtro?: FilterProcessOutPutIDs): Promise<IProcessOutPutIDs[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching processoutputids:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterProcessOutPutIDs): Promise<IProcessOutPutIDs[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching processoutputids:', error);
      return [];
    }
  }

  }