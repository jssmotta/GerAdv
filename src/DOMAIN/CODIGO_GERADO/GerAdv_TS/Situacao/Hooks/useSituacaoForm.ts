"use client";
import { useState } from 'react';
import { ISituacao } from '../Interfaces/interface.Situacao';
import { ISituacaoService } from '../Services/Situacao.service';

export const useSituacaoForm = (
  initialSituacao: ISituacao,
  dataService: ISituacaoService
) => {
  const [data, setData] = useState<ISituacao>(initialSituacao);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadSituacao = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchSituacaoById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadSituacao,
  };
};
