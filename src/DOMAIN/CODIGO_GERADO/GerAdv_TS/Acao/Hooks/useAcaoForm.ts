"use client";
import { useState } from 'react';
import { IAcao } from '../Interfaces/interface.Acao';
import { IAcaoService } from '../Services/Acao.service';

export const useAcaoForm = (
  initialAcao: IAcao,
  dataService: IAcaoService
) => {
  const [data, setData] = useState<IAcao>(initialAcao);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadAcao = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchAcaoById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadAcao,
  };
};
