"use client";
import { useState } from 'react';
import { IColaboradores } from '../Interfaces/interface.Colaboradores';
import { IColaboradoresService } from '../Services/Colaboradores.service';

export const useColaboradoresForm = (
  initialColaboradores: IColaboradores,
  dataService: IColaboradoresService
) => {
  const [data, setData] = useState<IColaboradores>(initialColaboradores);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadColaboradores = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchColaboradoresById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadColaboradores,
  };
};
