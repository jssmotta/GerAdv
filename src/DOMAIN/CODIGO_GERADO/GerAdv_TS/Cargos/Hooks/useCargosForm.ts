"use client";
import { useState } from 'react';
import { ICargos } from '../Interfaces/interface.Cargos';
import { ICargosService } from '../Services/Cargos.service';

export const useCargosForm = (
  initialCargos: ICargos,
  dataService: ICargosService
) => {
  const [data, setData] = useState<ICargos>(initialCargos);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadCargos = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchCargosById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadCargos,
  };
};
