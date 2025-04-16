"use client";
import { useState } from 'react';
import { IUF } from '../Interfaces/interface.UF';
import { IUFService } from '../Services/UF.service';

export const useUFForm = (
  initialUF: IUF,
  dataService: IUFService
) => {
  const [data, setData] = useState<IUF>(initialUF);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadUF = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchUFById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadUF,
  };
};
