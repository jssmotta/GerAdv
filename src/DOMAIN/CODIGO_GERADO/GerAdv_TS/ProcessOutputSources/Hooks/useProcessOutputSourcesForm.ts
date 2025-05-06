"use client";
import { useState } from 'react';
import { IProcessOutputSources } from '../Interfaces/interface.ProcessOutputSources';
import { IProcessOutputSourcesService } from '../Services/ProcessOutputSources.service';

export const useProcessOutputSourcesForm = (
  initialProcessOutputSources: IProcessOutputSources,
  dataService: IProcessOutputSourcesService
) => {
  const [data, setData] = useState<IProcessOutputSources>(initialProcessOutputSources);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadProcessOutputSources = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchProcessOutputSourcesById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadProcessOutputSources,
  };
};
