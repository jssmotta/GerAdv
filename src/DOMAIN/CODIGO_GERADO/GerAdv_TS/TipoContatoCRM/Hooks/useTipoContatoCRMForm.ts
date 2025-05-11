"use client";
import { useState } from 'react';
import { ITipoContatoCRM } from '../Interfaces/interface.TipoContatoCRM';
import { ITipoContatoCRMService } from '../Services/TipoContatoCRM.service';

export const useTipoContatoCRMForm = (
  initialTipoContatoCRM: ITipoContatoCRM,
  dataService: ITipoContatoCRMService
) => {
  const [data, setData] = useState<ITipoContatoCRM>(initialTipoContatoCRM);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadTipoContatoCRM = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchTipoContatoCRMById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadTipoContatoCRM,
  };
};
