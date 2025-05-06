"use client";
import { useState } from 'react';
import { IDiario2 } from '../Interfaces/interface.Diario2';
import { IDiario2Service } from '../Services/Diario2.service';

export const useDiario2Form = (
  initialDiario2: IDiario2,
  dataService: IDiario2Service
) => {
  const [data, setData] = useState<IDiario2>(initialDiario2);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadDiario2 = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchDiario2ById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadDiario2,
  };
};
