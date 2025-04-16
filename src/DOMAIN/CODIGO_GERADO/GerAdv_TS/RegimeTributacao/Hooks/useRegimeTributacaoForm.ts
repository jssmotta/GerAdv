"use client";
import { useState } from 'react';
import { IRegimeTributacao } from '../Interfaces/interface.RegimeTributacao';
import { IRegimeTributacaoService } from '../Services/RegimeTributacao.service';

export const useRegimeTributacaoForm = (
  initialRegimeTributacao: IRegimeTributacao,
  dataService: IRegimeTributacaoService
) => {
  const [data, setData] = useState<IRegimeTributacao>(initialRegimeTributacao);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadRegimeTributacao = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchRegimeTributacaoById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadRegimeTributacao,
  };
};
