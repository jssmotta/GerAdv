"use client";
import { useState } from 'react';
import { ICidade } from '../Interfaces/interface.Cidade';
import { ICidadeService } from '../Services/Cidade.service';

export const useCidadeForm = (
  initialCidade: ICidade,
  dataService: ICidadeService
) => {
  const [data, setData] = useState<ICidade>(initialCidade);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadCidade = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchCidadeById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadCidade,
  };
};
