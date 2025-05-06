"use client";
import { useState } from 'react';
import { IGUTMatriz } from '../Interfaces/interface.GUTMatriz';
import { IGUTMatrizService } from '../Services/GUTMatriz.service';

export const useGUTMatrizForm = (
  initialGUTMatriz: IGUTMatriz,
  dataService: IGUTMatrizService
) => {
  const [data, setData] = useState<IGUTMatriz>(initialGUTMatriz);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadGUTMatriz = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchGUTMatrizById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadGUTMatriz,
  };
};
