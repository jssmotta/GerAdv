"use client";
import { useState } from 'react';
import { INENotas } from '../Interfaces/interface.NENotas';
import { INENotasService } from '../Services/NENotas.service';

export const useNENotasForm = (
  initialNENotas: INENotas,
  dataService: INENotasService
) => {
  const [data, setData] = useState<INENotas>(initialNENotas);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadNENotas = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchNENotasById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadNENotas,
  };
};
