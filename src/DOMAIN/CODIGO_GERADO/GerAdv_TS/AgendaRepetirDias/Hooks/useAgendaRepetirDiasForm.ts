"use client";
import { useState } from 'react';
import { IAgendaRepetirDias } from '../Interfaces/interface.AgendaRepetirDias';
import { IAgendaRepetirDiasService } from '../Services/AgendaRepetirDias.service';

export const useAgendaRepetirDiasForm = (
  initialAgendaRepetirDias: IAgendaRepetirDias,
  dataService: IAgendaRepetirDiasService
) => {
  const [data, setData] = useState<IAgendaRepetirDias>(initialAgendaRepetirDias);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadAgendaRepetirDias = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchAgendaRepetirDiasById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadAgendaRepetirDias,
  };
};
