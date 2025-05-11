"use client";
import { useState } from 'react';
import { ITipoProDesposito } from '../Interfaces/interface.TipoProDesposito';
import { ITipoProDespositoService } from '../Services/TipoProDesposito.service';

export const useTipoProDespositoForm = (
  initialTipoProDesposito: ITipoProDesposito,
  dataService: ITipoProDespositoService
) => {
  const [data, setData] = useState<ITipoProDesposito>(initialTipoProDesposito);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadTipoProDesposito = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchTipoProDespositoById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadTipoProDesposito,
  };
};
