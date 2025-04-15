"use client";
import { useState } from 'react';
import { IAtividades } from '../Interfaces/interface.Atividades';
import { IAtividadesService } from '../Services/Atividades.service';

export const useAtividadesForm = (
  initialAtividades: IAtividades,
  dataService: IAtividadesService
) => {
  const [data, setData] = useState<IAtividades>(initialAtividades);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadAtividades = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchAtividadesById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadAtividades,
  };
};
