"use client";
import { useState } from 'react';
import { IProObservacoes } from '../Interfaces/interface.ProObservacoes';
import { IProObservacoesService } from '../Services/ProObservacoes.service';

export const useProObservacoesForm = (
  initialProObservacoes: IProObservacoes,
  dataService: IProObservacoesService
) => {
  const [data, setData] = useState<IProObservacoes>(initialProObservacoes);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadProObservacoes = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchProObservacoesById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadProObservacoes,
  };
};
