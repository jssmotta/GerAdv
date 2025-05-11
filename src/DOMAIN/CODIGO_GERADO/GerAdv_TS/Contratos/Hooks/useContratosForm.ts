"use client";
import { useState } from 'react';
import { IContratos } from '../Interfaces/interface.Contratos';
import { IContratosService } from '../Services/Contratos.service';

export const useContratosForm = (
  initialContratos: IContratos,
  dataService: IContratosService
) => {
  const [data, setData] = useState<IContratos>(initialContratos);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadContratos = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchContratosById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadContratos,
  };
};
