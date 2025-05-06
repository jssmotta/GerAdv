"use client";
import { SetorApi } from "../Apis/ApiSetor";
import { ISetor } from "../Interfaces/interface.Setor";
import { FilterSetor } from "../Filters/Setor";

  export interface ISetorService {
    fetchSetorById: (id: number) => Promise<ISetor>;
    saveSetor: (setor: ISetor) => Promise<ISetor>;
    getList: (filtro?: FilterSetor) => Promise<ISetor[]>;
  }
  
  export class SetorService implements ISetorService {
    constructor(private api: SetorApi) {}
  
    async fetchSetorById(id: number): Promise<ISetor> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveSetor(setor: ISetor): Promise<ISetor> {
      const response = await this.api.addAndUpdate(setor as ISetor);
      return response.data;
    }
 
   async getList(filtro?: FilterSetor): Promise<ISetor[]> {
    try {
      const response = await this.api.getListN(200, filtro);
      return response.data;
    } catch (error) {
      console.error('Error fetching setor:', error);
      return [];
    }
  }

   async getAll(filtro?: FilterSetor): Promise<ISetor[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching setor:', error);
      return [];
    }
  }

  }