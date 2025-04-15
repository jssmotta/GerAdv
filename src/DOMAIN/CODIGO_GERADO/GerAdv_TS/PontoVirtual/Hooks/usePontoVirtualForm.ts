"use client";
import { useState } from 'react';
import { IPontoVirtual } from '../Interfaces/interface.PontoVirtual';
import { IPontoVirtualService } from '../Services/PontoVirtual.service';

export const usePontoVirtualForm = (
  initialPontoVirtual: IPontoVirtual,
  dataService: IPontoVirtualService
) => {
  const [data, setData] = useState<IPontoVirtual>(initialPontoVirtual);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadPontoVirtual = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchPontoVirtualById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadPontoVirtual,
  };
};
