"use client";
import { useState } from 'react';
import { IApenso } from '../Interfaces/interface.Apenso';
import { IApensoService } from '../Services/Apenso.service';

export const useApensoForm = (
  initialApenso: IApenso,
  dataService: IApensoService
) => {
  const [data, setData] = useState<IApenso>(initialApenso);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadApenso = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchApensoById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadApenso,
  };
};
