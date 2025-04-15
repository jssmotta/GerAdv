"use client";
import { AlarmSMSApi } from "../Apis/ApiAlarmSMS";
import { IAlarmSMS } from "../Interfaces/interface.AlarmSMS";
import { FilterAlarmSMS } from "../Filters/AlarmSMS";

  export interface IAlarmSMSService {
    fetchAlarmSMSById: (id: number) => Promise<IAlarmSMS>;
    saveAlarmSMS: (alarmsms: IAlarmSMS) => Promise<IAlarmSMS>;
    getList: (filtro?: FilterAlarmSMS) => Promise<IAlarmSMS[]>;
  }
  
  export class AlarmSMSService implements IAlarmSMSService {
    constructor(private api: AlarmSMSApi) {}
  
    async fetchAlarmSMSById(id: number): Promise<IAlarmSMS> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveAlarmSMS(alarmsms: IAlarmSMS): Promise<IAlarmSMS> {
      const response = await this.api.addAndUpdate(alarmsms as IAlarmSMS);
      return response.data;
    }
 
   async getList(filtro?: FilterAlarmSMS): Promise<IAlarmSMS[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching alarmsms:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterAlarmSMS): Promise<IAlarmSMS[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching alarmsms:', error);
      return [];
    }
  }

  }