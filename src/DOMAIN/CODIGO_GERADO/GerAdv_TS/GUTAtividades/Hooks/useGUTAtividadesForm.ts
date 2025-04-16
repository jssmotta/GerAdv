"use client";
import { useState } from 'react';
import { IGUTAtividades } from '../Interfaces/interface.GUTAtividades';
import { IGUTAtividadesService } from '../Services/GUTAtividades.service';

export const useGUTAtividadesForm = (
  initialGUTAtividades: IGUTAtividades,
  dataService: IGUTAtividadesService
) => {
  const [data, setData] = useState<IGUTAtividades>(initialGUTAtividades);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadGUTAtividades = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchGUTAtividadesById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadGUTAtividades,
  };
};
