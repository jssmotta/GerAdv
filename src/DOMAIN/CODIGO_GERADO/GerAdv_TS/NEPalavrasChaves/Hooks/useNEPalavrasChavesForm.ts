"use client";
import { useState } from 'react';
import { INEPalavrasChaves } from '../Interfaces/interface.NEPalavrasChaves';
import { INEPalavrasChavesService } from '../Services/NEPalavrasChaves.service';

export const useNEPalavrasChavesForm = (
  initialNEPalavrasChaves: INEPalavrasChaves,
  dataService: INEPalavrasChavesService
) => {
  const [data, setData] = useState<INEPalavrasChaves>(initialNEPalavrasChaves);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadNEPalavrasChaves = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchNEPalavrasChavesById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadNEPalavrasChaves,
  };
};
