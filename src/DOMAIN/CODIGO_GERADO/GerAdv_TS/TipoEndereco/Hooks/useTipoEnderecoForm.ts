"use client";
import { useState } from 'react';
import { ITipoEndereco } from '../Interfaces/interface.TipoEndereco';
import { ITipoEnderecoService } from '../Services/TipoEndereco.service';

export const useTipoEnderecoForm = (
  initialTipoEndereco: ITipoEndereco,
  dataService: ITipoEnderecoService
) => {
  const [data, setData] = useState<ITipoEndereco>(initialTipoEndereco);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadTipoEndereco = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchTipoEnderecoById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadTipoEndereco,
  };
};
