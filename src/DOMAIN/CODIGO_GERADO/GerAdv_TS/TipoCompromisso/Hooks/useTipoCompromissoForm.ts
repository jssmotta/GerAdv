"use client";
import { useState } from 'react';
import { ITipoCompromisso } from '../Interfaces/interface.TipoCompromisso';
import { ITipoCompromissoService } from '../Services/TipoCompromisso.service';

export const useTipoCompromissoForm = (
  initialTipoCompromisso: ITipoCompromisso,
  dataService: ITipoCompromissoService
) => {
  const [data, setData] = useState<ITipoCompromisso>(initialTipoCompromisso);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadTipoCompromisso = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchTipoCompromissoById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadTipoCompromisso,
  };
};
