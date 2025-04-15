"use client";
import { useState } from 'react';
import { ITiposAcao } from '../Interfaces/interface.TiposAcao';
import { ITiposAcaoService } from '../Services/TiposAcao.service';

export const useTiposAcaoForm = (
  initialTiposAcao: ITiposAcao,
  dataService: ITiposAcaoService
) => {
  const [data, setData] = useState<ITiposAcao>(initialTiposAcao);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadTiposAcao = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchTiposAcaoById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadTiposAcao,
  };
};
