"use client";
import { useState } from 'react';
import { ITipoValorProcesso } from '../Interfaces/interface.TipoValorProcesso';
import { ITipoValorProcessoService } from '../Services/TipoValorProcesso.service';

export const useTipoValorProcessoForm = (
  initialTipoValorProcesso: ITipoValorProcesso,
  dataService: ITipoValorProcessoService
) => {
  const [data, setData] = useState<ITipoValorProcesso>(initialTipoValorProcesso);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadTipoValorProcesso = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchTipoValorProcessoById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadTipoValorProcesso,
  };
};
