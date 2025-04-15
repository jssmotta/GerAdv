"use client";
import { useState } from 'react';
import { IProcessosParados } from '../Interfaces/interface.ProcessosParados';
import { IProcessosParadosService } from '../Services/ProcessosParados.service';

export const useProcessosParadosForm = (
  initialProcessosParados: IProcessosParados,
  dataService: IProcessosParadosService
) => {
  const [data, setData] = useState<IProcessosParados>(initialProcessosParados);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadProcessosParados = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchProcessosParadosById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadProcessosParados,
  };
};
