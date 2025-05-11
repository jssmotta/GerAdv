"use client";
import { OperadorEMailPopupApi } from "../Apis/ApiOperadorEMailPopup";
import { IOperadorEMailPopup } from "../Interfaces/interface.OperadorEMailPopup";
import { FilterOperadorEMailPopup } from "../Filters/OperadorEMailPopup";

  export interface IOperadorEMailPopupService {
    fetchOperadorEMailPopupById: (id: number) => Promise<IOperadorEMailPopup>;
    saveOperadorEMailPopup: (operadoremailpopup: IOperadorEMailPopup) => Promise<IOperadorEMailPopup>;
    getList: (filtro?: FilterOperadorEMailPopup) => Promise<IOperadorEMailPopup[]>;
  }
  
  export class OperadorEMailPopupService implements IOperadorEMailPopupService {
    constructor(private api: OperadorEMailPopupApi) {}
  
    async fetchOperadorEMailPopupById(id: number): Promise<IOperadorEMailPopup> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveOperadorEMailPopup(operadoremailpopup: IOperadorEMailPopup): Promise<IOperadorEMailPopup> {
      const response = await this.api.addAndUpdate(operadoremailpopup as IOperadorEMailPopup);
      return response.data;
    }
 
   async getList(filtro?: FilterOperadorEMailPopup): Promise<IOperadorEMailPopup[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching operadoremailpopup:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterOperadorEMailPopup): Promise<IOperadorEMailPopup[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching operadoremailpopup:', error);
      return [];
    }
  }

  }