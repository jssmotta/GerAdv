"use client";
import { useState } from 'react';
import { IFase } from '../Interfaces/interface.Fase';
import { IFaseService } from '../Services/Fase.service';

export const useFaseForm = (
  initialFase: IFase,
  dataService: IFaseService
) => {
  const [data, setData] = useState<IFase>(initialFase);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadFase = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchFaseById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadFase,
  };
};
