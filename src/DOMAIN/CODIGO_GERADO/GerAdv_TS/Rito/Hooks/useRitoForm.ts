"use client";
import { useState } from 'react';
import { IRito } from '../Interfaces/interface.Rito';
import { IRitoService } from '../Services/Rito.service';

export const useRitoForm = (
  initialRito: IRito,
  dataService: IRitoService
) => {
  const [data, setData] = useState<IRito>(initialRito);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadRito = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchRitoById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadRito,
  };
};
