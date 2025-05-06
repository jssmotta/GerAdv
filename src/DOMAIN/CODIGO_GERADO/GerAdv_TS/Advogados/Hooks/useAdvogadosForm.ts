"use client";
import { useState } from 'react';
import { IAdvogados } from '../Interfaces/interface.Advogados';
import { IAdvogadosService } from '../Services/Advogados.service';

export const useAdvogadosForm = (
  initialAdvogados: IAdvogados,
  dataService: IAdvogadosService
) => {
  const [data, setData] = useState<IAdvogados>(initialAdvogados);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadAdvogados = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchAdvogadosById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadAdvogados,
  };
};
