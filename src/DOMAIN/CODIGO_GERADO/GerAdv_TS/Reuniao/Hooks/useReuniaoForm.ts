"use client";
import { useState } from 'react';
import { IReuniao } from '../Interfaces/interface.Reuniao';
import { IReuniaoService } from '../Services/Reuniao.service';

export const useReuniaoForm = (
  initialReuniao: IReuniao,
  dataService: IReuniaoService
) => {
  const [data, setData] = useState<IReuniao>(initialReuniao);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadReuniao = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchReuniaoById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadReuniao,
  };
};
