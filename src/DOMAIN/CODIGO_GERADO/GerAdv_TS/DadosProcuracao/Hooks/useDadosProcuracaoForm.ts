"use client";
import { useState } from 'react';
import { IDadosProcuracao } from '../Interfaces/interface.DadosProcuracao';
import { IDadosProcuracaoService } from '../Services/DadosProcuracao.service';

export const useDadosProcuracaoForm = (
  initialDadosProcuracao: IDadosProcuracao,
  dataService: IDadosProcuracaoService
) => {
  const [data, setData] = useState<IDadosProcuracao>(initialDadosProcuracao);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadDadosProcuracao = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchDadosProcuracaoById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadDadosProcuracao,
  };
};
