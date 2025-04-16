"use client";
import { useState } from 'react';
import { IBensClassificacao } from '../Interfaces/interface.BensClassificacao';
import { IBensClassificacaoService } from '../Services/BensClassificacao.service';

export const useBensClassificacaoForm = (
  initialBensClassificacao: IBensClassificacao,
  dataService: IBensClassificacaoService
) => {
  const [data, setData] = useState<IBensClassificacao>(initialBensClassificacao);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadBensClassificacao = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchBensClassificacaoById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadBensClassificacao,
  };
};
