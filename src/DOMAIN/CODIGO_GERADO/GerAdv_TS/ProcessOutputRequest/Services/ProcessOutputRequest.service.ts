"use client";
import { ProcessOutputRequestApi } from "../Apis/ApiProcessOutputRequest";
import { IProcessOutputRequest } from "../Interfaces/interface.ProcessOutputRequest";
import { FilterProcessOutputRequest } from "../Filters/ProcessOutputRequest";

  export interface IProcessOutputRequestService {
    fetchProcessOutputRequestById: (id: number) => Promise<IProcessOutputRequest>;
    saveProcessOutputRequest: (processoutputrequest: IProcessOutputRequest) => Promise<IProcessOutputRequest>;
    
  }
  
  export class ProcessOutputRequestService implements IProcessOutputRequestService {
    constructor(private api: ProcessOutputRequestApi) {}
  
    async fetchProcessOutputRequestById(id: number): Promise<IProcessOutputRequest> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveProcessOutputRequest(processoutputrequest: IProcessOutputRequest): Promise<IProcessOutputRequest> {
      const response = await this.api.addAndUpdate(processoutputrequest as IProcessOutputRequest);
      return response.data;
    }
 
   async getAll(filtro?: FilterProcessOutputRequest): Promise<IProcessOutputRequest[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching processoutputrequest:', error);
      return [];
    }
  }

  }