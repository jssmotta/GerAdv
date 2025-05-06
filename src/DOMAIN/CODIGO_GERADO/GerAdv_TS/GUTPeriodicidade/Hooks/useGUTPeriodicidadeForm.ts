"use client";
import { useState } from 'react';
import { IGUTPeriodicidade } from '../Interfaces/interface.GUTPeriodicidade';
import { IGUTPeriodicidadeService } from '../Services/GUTPeriodicidade.service';

export const useGUTPeriodicidadeForm = (
  initialGUTPeriodicidade: IGUTPeriodicidade,
  dataService: IGUTPeriodicidadeService
) => {
  const [data, setData] = useState<IGUTPeriodicidade>(initialGUTPeriodicidade);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadGUTPeriodicidade = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchGUTPeriodicidadeById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadGUTPeriodicidade,
  };
};
