"use client";
import { useState } from 'react';
import { IStatusAndamento } from '../Interfaces/interface.StatusAndamento';
import { IStatusAndamentoService } from '../Services/StatusAndamento.service';

export const useStatusAndamentoForm = (
  initialStatusAndamento: IStatusAndamento,
  dataService: IStatusAndamentoService
) => {
  const [data, setData] = useState<IStatusAndamento>(initialStatusAndamento);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadStatusAndamento = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchStatusAndamentoById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadStatusAndamento,
  };
};
