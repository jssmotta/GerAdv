"use client";
import { useState } from 'react';
import { IBensMateriais } from '../Interfaces/interface.BensMateriais';
import { IBensMateriaisService } from '../Services/BensMateriais.service';

export const useBensMateriaisForm = (
  initialBensMateriais: IBensMateriais,
  dataService: IBensMateriaisService
) => {
  const [data, setData] = useState<IBensMateriais>(initialBensMateriais);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadBensMateriais = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchBensMateriaisById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadBensMateriais,
  };
};
