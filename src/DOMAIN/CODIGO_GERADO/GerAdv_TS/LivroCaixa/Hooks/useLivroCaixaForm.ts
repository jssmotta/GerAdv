"use client";
import { useState } from 'react';
import { ILivroCaixa } from '../Interfaces/interface.LivroCaixa';
import { ILivroCaixaService } from '../Services/LivroCaixa.service';

export const useLivroCaixaForm = (
  initialLivroCaixa: ILivroCaixa,
  dataService: ILivroCaixaService
) => {
  const [data, setData] = useState<ILivroCaixa>(initialLivroCaixa);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadLivroCaixa = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchLivroCaixaById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadLivroCaixa,
  };
};
