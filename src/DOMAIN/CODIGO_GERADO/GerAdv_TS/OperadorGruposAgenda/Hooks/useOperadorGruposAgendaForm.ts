"use client";
import { useState } from 'react';
import { IOperadorGruposAgenda } from '../Interfaces/interface.OperadorGruposAgenda';
import { IOperadorGruposAgendaService } from '../Services/OperadorGruposAgenda.service';

export const useOperadorGruposAgendaForm = (
  initialOperadorGruposAgenda: IOperadorGruposAgenda,
  dataService: IOperadorGruposAgendaService
) => {
  const [data, setData] = useState<IOperadorGruposAgenda>(initialOperadorGruposAgenda);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadOperadorGruposAgenda = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchOperadorGruposAgendaById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadOperadorGruposAgenda,
  };
};
