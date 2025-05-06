"use client";
import { useState } from 'react';
import { IAndamentosMD } from '../Interfaces/interface.AndamentosMD';
import { IAndamentosMDService } from '../Services/AndamentosMD.service';

export const useAndamentosMDForm = (
  initialAndamentosMD: IAndamentosMD,
  dataService: IAndamentosMDService
) => {
  const [data, setData] = useState<IAndamentosMD>(initialAndamentosMD);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadAndamentosMD = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchAndamentosMDById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadAndamentosMD,
  };
};
