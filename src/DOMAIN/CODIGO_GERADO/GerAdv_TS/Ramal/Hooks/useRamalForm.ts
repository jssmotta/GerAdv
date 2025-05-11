"use client";
import { useState } from 'react';
import { IRamal } from '../Interfaces/interface.Ramal';
import { IRamalService } from '../Services/Ramal.service';

export const useRamalForm = (
  initialRamal: IRamal,
  dataService: IRamalService
) => {
  const [data, setData] = useState<IRamal>(initialRamal);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadRamal = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchRamalById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadRamal,
  };
};
