"use client";
import { useState } from 'react';
import { ICargosEsc } from '../Interfaces/interface.CargosEsc';
import { ICargosEscService } from '../Services/CargosEsc.service';

export const useCargosEscForm = (
  initialCargosEsc: ICargosEsc,
  dataService: ICargosEscService
) => {
  const [data, setData] = useState<ICargosEsc>(initialCargosEsc);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadCargosEsc = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchCargosEscById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadCargosEsc,
  };
};
