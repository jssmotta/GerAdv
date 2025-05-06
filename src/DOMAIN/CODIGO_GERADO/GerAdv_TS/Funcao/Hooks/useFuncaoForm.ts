"use client";
import { useState } from 'react';
import { IFuncao } from '../Interfaces/interface.Funcao';
import { IFuncaoService } from '../Services/Funcao.service';

export const useFuncaoForm = (
  initialFuncao: IFuncao,
  dataService: IFuncaoService
) => {
  const [data, setData] = useState<IFuncao>(initialFuncao);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadFuncao = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchFuncaoById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadFuncao,
  };
};
