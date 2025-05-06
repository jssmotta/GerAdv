"use client";
import { useState } from 'react';
import { INECompromissos } from '../Interfaces/interface.NECompromissos';
import { INECompromissosService } from '../Services/NECompromissos.service';

export const useNECompromissosForm = (
  initialNECompromissos: INECompromissos,
  dataService: INECompromissosService
) => {
  const [data, setData] = useState<INECompromissos>(initialNECompromissos);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadNECompromissos = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchNECompromissosById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadNECompromissos,
  };
};
