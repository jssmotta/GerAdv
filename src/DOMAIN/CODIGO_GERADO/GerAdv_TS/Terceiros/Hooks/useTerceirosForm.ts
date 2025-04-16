"use client";
import { useState } from 'react';
import { ITerceiros } from '../Interfaces/interface.Terceiros';
import { ITerceirosService } from '../Services/Terceiros.service';

export const useTerceirosForm = (
  initialTerceiros: ITerceiros,
  dataService: ITerceirosService
) => {
  const [data, setData] = useState<ITerceiros>(initialTerceiros);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadTerceiros = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchTerceirosById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadTerceiros,
  };
};
