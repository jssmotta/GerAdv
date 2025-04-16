"use client";
import { useState } from 'react';
import { IAgendaRepetir } from '../Interfaces/interface.AgendaRepetir';
import { IAgendaRepetirService } from '../Services/AgendaRepetir.service';

export const useAgendaRepetirForm = (
  initialAgendaRepetir: IAgendaRepetir,
  dataService: IAgendaRepetirService
) => {
  const [data, setData] = useState<IAgendaRepetir>(initialAgendaRepetir);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadAgendaRepetir = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchAgendaRepetirById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadAgendaRepetir,
  };
};
