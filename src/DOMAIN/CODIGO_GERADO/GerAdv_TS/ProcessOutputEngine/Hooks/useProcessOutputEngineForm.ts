"use client";
import { useState } from 'react';
import { IProcessOutputEngine } from '../Interfaces/interface.ProcessOutputEngine';
import { IProcessOutputEngineService } from '../Services/ProcessOutputEngine.service';

export const useProcessOutputEngineForm = (
  initialProcessOutputEngine: IProcessOutputEngine,
  dataService: IProcessOutputEngineService
) => {
  const [data, setData] = useState<IProcessOutputEngine>(initialProcessOutputEngine);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadProcessOutputEngine = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchProcessOutputEngineById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadProcessOutputEngine,
  };
};
