"use client";
import { useState } from 'react';
import { IOponentes } from '../Interfaces/interface.Oponentes';
import { IOponentesService } from '../Services/Oponentes.service';

export const useOponentesForm = (
  initialOponentes: IOponentes,
  dataService: IOponentesService
) => {
  const [data, setData] = useState<IOponentes>(initialOponentes);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadOponentes = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchOponentesById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadOponentes,
  };
};
