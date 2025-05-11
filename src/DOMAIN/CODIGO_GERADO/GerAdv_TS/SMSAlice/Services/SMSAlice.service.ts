"use client";
import { SMSAliceApi } from "../Apis/ApiSMSAlice";
import { ISMSAlice } from "../Interfaces/interface.SMSAlice";
import { FilterSMSAlice } from "../Filters/SMSAlice";

  export interface ISMSAliceService {
    fetchSMSAliceById: (id: number) => Promise<ISMSAlice>;
    saveSMSAlice: (smsalice: ISMSAlice) => Promise<ISMSAlice>;
    getList: (filtro?: FilterSMSAlice) => Promise<ISMSAlice[]>;
  }
  
  export class SMSAliceService implements ISMSAliceService {
    constructor(private api: SMSAliceApi) {}
  
    async fetchSMSAliceById(id: number): Promise<ISMSAlice> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveSMSAlice(smsalice: ISMSAlice): Promise<ISMSAlice> {
      const response = await this.api.addAndUpdate(smsalice as ISMSAlice);
      return response.data;
    }
 
   async getList(filtro?: FilterSMSAlice): Promise<ISMSAlice[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching smsalice:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterSMSAlice): Promise<ISMSAlice[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching smsalice:', error);
      return [];
    }
  }

  }