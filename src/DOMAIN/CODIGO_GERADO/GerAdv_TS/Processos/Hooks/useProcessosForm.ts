"use client";
import { useState } from 'react';
import { IProcessos } from '../Interfaces/interface.Processos';
import { IProcessosService } from '../Services/Processos.service';

export const useProcessosForm = (
  initialProcessos: IProcessos,
  dataService: IProcessosService
) => {
  const [data, setData] = useState<IProcessos>(initialProcessos);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadProcessos = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchProcessosById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadProcessos,
  };
};
