"use client";
import { useState } from 'react';
import { IProCDA } from '../Interfaces/interface.ProCDA';
import { IProCDAService } from '../Services/ProCDA.service';

export const useProCDAForm = (
  initialProCDA: IProCDA,
  dataService: IProCDAService
) => {
  const [data, setData] = useState<IProCDA>(initialProCDA);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadProCDA = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchProCDAById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadProCDA,
  };
};
