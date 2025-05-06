"use client";
import { useState } from 'react';
import { IHonorariosDadosContrato } from '../Interfaces/interface.HonorariosDadosContrato';
import { IHonorariosDadosContratoService } from '../Services/HonorariosDadosContrato.service';

export const useHonorariosDadosContratoForm = (
  initialHonorariosDadosContrato: IHonorariosDadosContrato,
  dataService: IHonorariosDadosContratoService
) => {
  const [data, setData] = useState<IHonorariosDadosContrato>(initialHonorariosDadosContrato);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadHonorariosDadosContrato = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchHonorariosDadosContratoById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadHonorariosDadosContrato,
  };
};
