"use client";
import { useState } from 'react';
import { IUltimosProcessos } from '../Interfaces/interface.UltimosProcessos';
import { IUltimosProcessosService } from '../Services/UltimosProcessos.service';

export const useUltimosProcessosForm = (
  initialUltimosProcessos: IUltimosProcessos,
  dataService: IUltimosProcessosService
) => {
  const [data, setData] = useState<IUltimosProcessos>(initialUltimosProcessos);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadUltimosProcessos = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchUltimosProcessosById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadUltimosProcessos,
  };
};
