"use client";
import { useState } from 'react';
import { IStatusTarefas } from '../Interfaces/interface.StatusTarefas';
import { IStatusTarefasService } from '../Services/StatusTarefas.service';

export const useStatusTarefasForm = (
  initialStatusTarefas: IStatusTarefas,
  dataService: IStatusTarefasService
) => {
  const [data, setData] = useState<IStatusTarefas>(initialStatusTarefas);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadStatusTarefas = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchStatusTarefasById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadStatusTarefas,
  };
};
