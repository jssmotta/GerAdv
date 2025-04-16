"use client";
import { useState } from 'react';
import { IRecados } from '../Interfaces/interface.Recados';
import { IRecadosService } from '../Services/Recados.service';

export const useRecadosForm = (
  initialRecados: IRecados,
  dataService: IRecadosService
) => {
  const [data, setData] = useState<IRecados>(initialRecados);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadRecados = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchRecadosById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadRecados,
  };
};
