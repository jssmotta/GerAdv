"use client";
import { useState } from 'react';
import { IEscritorios } from '../Interfaces/interface.Escritorios';
import { IEscritoriosService } from '../Services/Escritorios.service';

export const useEscritoriosForm = (
  initialEscritorios: IEscritorios,
  dataService: IEscritoriosService
) => {
  const [data, setData] = useState<IEscritorios>(initialEscritorios);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadEscritorios = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchEscritoriosById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadEscritorios,
  };
};
