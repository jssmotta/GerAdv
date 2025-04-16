"use client";
import { useState } from 'react';
import { IContatoCRMOperador } from '../Interfaces/interface.ContatoCRMOperador';
import { IContatoCRMOperadorService } from '../Services/ContatoCRMOperador.service';

export const useContatoCRMOperadorForm = (
  initialContatoCRMOperador: IContatoCRMOperador,
  dataService: IContatoCRMOperadorService
) => {
  const [data, setData] = useState<IContatoCRMOperador>(initialContatoCRMOperador);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadContatoCRMOperador = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchContatoCRMOperadorById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadContatoCRMOperador,
  };
};
