"use client";
import { useState } from 'react';
import { ITipoEnderecoSistema } from '../Interfaces/interface.TipoEnderecoSistema';
import { ITipoEnderecoSistemaService } from '../Services/TipoEnderecoSistema.service';

export const useTipoEnderecoSistemaForm = (
  initialTipoEnderecoSistema: ITipoEnderecoSistema,
  dataService: ITipoEnderecoSistemaService
) => {
  const [data, setData] = useState<ITipoEnderecoSistema>(initialTipoEnderecoSistema);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadTipoEnderecoSistema = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchTipoEnderecoSistemaById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadTipoEnderecoSistema,
  };
};
