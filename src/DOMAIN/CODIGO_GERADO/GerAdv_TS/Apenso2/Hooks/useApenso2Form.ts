"use client";
import { useState } from 'react';
import { IApenso2 } from '../Interfaces/interface.Apenso2';
import { IApenso2Service } from '../Services/Apenso2.service';

export const useApenso2Form = (
  initialApenso2: IApenso2,
  dataService: IApenso2Service
) => {
  const [data, setData] = useState<IApenso2>(initialApenso2);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadApenso2 = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchApenso2ById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadApenso2,
  };
};
