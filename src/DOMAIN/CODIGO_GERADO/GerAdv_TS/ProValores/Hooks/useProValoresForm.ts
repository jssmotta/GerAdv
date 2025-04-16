"use client";
import { useState } from 'react';
import { IProValores } from '../Interfaces/interface.ProValores';
import { IProValoresService } from '../Services/ProValores.service';

export const useProValoresForm = (
  initialProValores: IProValores,
  dataService: IProValoresService
) => {
  const [data, setData] = useState<IProValores>(initialProValores);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadProValores = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchProValoresById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadProValores,
  };
};
