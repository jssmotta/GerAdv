"use client";
import { useState } from 'react';
import { ITipoStatusBiu } from '../Interfaces/interface.TipoStatusBiu';
import { ITipoStatusBiuService } from '../Services/TipoStatusBiu.service';

export const useTipoStatusBiuForm = (
  initialTipoStatusBiu: ITipoStatusBiu,
  dataService: ITipoStatusBiuService
) => {
  const [data, setData] = useState<ITipoStatusBiu>(initialTipoStatusBiu);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadTipoStatusBiu = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchTipoStatusBiuById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadTipoStatusBiu,
  };
};
