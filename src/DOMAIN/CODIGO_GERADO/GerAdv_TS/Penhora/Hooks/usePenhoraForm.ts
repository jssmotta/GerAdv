"use client";
import { useState } from 'react';
import { IPenhora } from '../Interfaces/interface.Penhora';
import { IPenhoraService } from '../Services/Penhora.service';

export const usePenhoraForm = (
  initialPenhora: IPenhora,
  dataService: IPenhoraService
) => {
  const [data, setData] = useState<IPenhora>(initialPenhora);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadPenhora = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchPenhoraById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadPenhora,
  };
};
