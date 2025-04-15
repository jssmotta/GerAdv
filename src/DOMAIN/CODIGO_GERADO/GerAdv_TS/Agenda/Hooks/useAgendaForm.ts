"use client";
import { useState } from 'react';
import { IAgenda } from '../Interfaces/interface.Agenda';
import { IAgendaService } from '../Services/Agenda.service';

export const useAgendaForm = (
  initialAgenda: IAgenda,
  dataService: IAgendaService
) => {
  const [data, setData] = useState<IAgenda>(initialAgenda);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadAgenda = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchAgendaById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadAgenda,
  };
};
