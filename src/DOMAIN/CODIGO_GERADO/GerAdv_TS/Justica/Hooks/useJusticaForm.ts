"use client";
import { useState } from 'react';
import { IJustica } from '../Interfaces/interface.Justica';
import { IJusticaService } from '../Services/Justica.service';

export const useJusticaForm = (
  initialJustica: IJustica,
  dataService: IJusticaService
) => {
  const [data, setData] = useState<IJustica>(initialJustica);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadJustica = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchJusticaById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadJustica,
  };
};
