"use client";
import { useState } from 'react';
import { IAnexamentoRegistros } from '../Interfaces/interface.AnexamentoRegistros';
import { IAnexamentoRegistrosService } from '../Services/AnexamentoRegistros.service';

export const useAnexamentoRegistrosForm = (
  initialAnexamentoRegistros: IAnexamentoRegistros,
  dataService: IAnexamentoRegistrosService
) => {
  const [data, setData] = useState<IAnexamentoRegistros>(initialAnexamentoRegistros);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadAnexamentoRegistros = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchAnexamentoRegistrosById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadAnexamentoRegistros,
  };
};
