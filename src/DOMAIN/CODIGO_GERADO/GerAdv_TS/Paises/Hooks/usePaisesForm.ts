"use client";
import { useState } from 'react';
import { IPaises } from '../Interfaces/interface.Paises';
import { IPaisesService } from '../Services/Paises.service';

export const usePaisesForm = (
  initialPaises: IPaises,
  dataService: IPaisesService
) => {
  const [data, setData] = useState<IPaises>(initialPaises);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadPaises = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchPaisesById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadPaises,
  };
};
