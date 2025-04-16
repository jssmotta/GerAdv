"use client";
import { useState } from 'react';
import { IContaCorrente } from '../Interfaces/interface.ContaCorrente';
import { IContaCorrenteService } from '../Services/ContaCorrente.service';

export const useContaCorrenteForm = (
  initialContaCorrente: IContaCorrente,
  dataService: IContaCorrenteService
) => {
  const [data, setData] = useState<IContaCorrente>(initialContaCorrente);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadContaCorrente = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchContaCorrenteById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadContaCorrente,
  };
};
