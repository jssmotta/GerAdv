"use client";
import { useState } from 'react';
import { IPrecatoria } from '../Interfaces/interface.Precatoria';
import { IPrecatoriaService } from '../Services/Precatoria.service';

export const usePrecatoriaForm = (
  initialPrecatoria: IPrecatoria,
  dataService: IPrecatoriaService
) => {
  const [data, setData] = useState<IPrecatoria>(initialPrecatoria);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadPrecatoria = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchPrecatoriaById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadPrecatoria,
  };
};
