"use client";
import { useState } from 'react';
import { IForo } from '../Interfaces/interface.Foro';
import { IForoService } from '../Services/Foro.service';

export const useForoForm = (
  initialForo: IForo,
  dataService: IForoService
) => {
  const [data, setData] = useState<IForo>(initialForo);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadForo = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchForoById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadForo,
  };
};
