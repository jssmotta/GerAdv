"use client";
import { useState } from 'react';
import { ILigacoes } from '../Interfaces/interface.Ligacoes';
import { ILigacoesService } from '../Services/Ligacoes.service';

export const useLigacoesForm = (
  initialLigacoes: ILigacoes,
  dataService: ILigacoesService
) => {
  const [data, setData] = useState<ILigacoes>(initialLigacoes);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadLigacoes = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchLigacoesById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadLigacoes,
  };
};
