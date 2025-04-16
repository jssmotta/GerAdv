"use client";
import { useState } from 'react';
import { IStatusInstancia } from '../Interfaces/interface.StatusInstancia';
import { IStatusInstanciaService } from '../Services/StatusInstancia.service';

export const useStatusInstanciaForm = (
  initialStatusInstancia: IStatusInstancia,
  dataService: IStatusInstanciaService
) => {
  const [data, setData] = useState<IStatusInstancia>(initialStatusInstancia);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadStatusInstancia = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchStatusInstanciaById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadStatusInstancia,
  };
};
