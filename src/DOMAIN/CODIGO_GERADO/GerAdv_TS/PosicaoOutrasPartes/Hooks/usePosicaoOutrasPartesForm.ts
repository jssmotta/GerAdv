"use client";
import { useState } from 'react';
import { IPosicaoOutrasPartes } from '../Interfaces/interface.PosicaoOutrasPartes';
import { IPosicaoOutrasPartesService } from '../Services/PosicaoOutrasPartes.service';

export const usePosicaoOutrasPartesForm = (
  initialPosicaoOutrasPartes: IPosicaoOutrasPartes,
  dataService: IPosicaoOutrasPartesService
) => {
  const [data, setData] = useState<IPosicaoOutrasPartes>(initialPosicaoOutrasPartes);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadPosicaoOutrasPartes = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchPosicaoOutrasPartesById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadPosicaoOutrasPartes,
  };
};
