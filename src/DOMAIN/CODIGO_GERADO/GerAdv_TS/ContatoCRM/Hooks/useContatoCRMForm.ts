"use client";
import { useState } from 'react';
import { IContatoCRM } from '../Interfaces/interface.ContatoCRM';
import { IContatoCRMService } from '../Services/ContatoCRM.service';

export const useContatoCRMForm = (
  initialContatoCRM: IContatoCRM,
  dataService: IContatoCRMService
) => {
  const [data, setData] = useState<IContatoCRM>(initialContatoCRM);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadContatoCRM = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchContatoCRMById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadContatoCRM,
  };
};
