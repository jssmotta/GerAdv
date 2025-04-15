"use client";
import { useState } from 'react';
import { IPrepostos } from '../Interfaces/interface.Prepostos';
import { IPrepostosService } from '../Services/Prepostos.service';

export const usePrepostosForm = (
  initialPrepostos: IPrepostos,
  dataService: IPrepostosService
) => {
  const [data, setData] = useState<IPrepostos>(initialPrepostos);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadPrepostos = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchPrepostosById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadPrepostos,
  };
};
