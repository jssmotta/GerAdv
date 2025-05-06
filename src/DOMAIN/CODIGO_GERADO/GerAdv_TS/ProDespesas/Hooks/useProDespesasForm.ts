"use client";
import { useState } from 'react';
import { IProDespesas } from '../Interfaces/interface.ProDespesas';
import { IProDespesasService } from '../Services/ProDespesas.service';

export const useProDespesasForm = (
  initialProDespesas: IProDespesas,
  dataService: IProDespesasService
) => {
  const [data, setData] = useState<IProDespesas>(initialProDespesas);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadProDespesas = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchProDespesasById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadProDespesas,
  };
};
