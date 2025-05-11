"use client";
import { useState } from 'react';
import { IInstancia } from '../Interfaces/interface.Instancia';
import { IInstanciaService } from '../Services/Instancia.service';

export const useInstanciaForm = (
  initialInstancia: IInstancia,
  dataService: IInstanciaService
) => {
  const [data, setData] = useState<IInstancia>(initialInstancia);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadInstancia = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchInstanciaById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadInstancia,
  };
};
