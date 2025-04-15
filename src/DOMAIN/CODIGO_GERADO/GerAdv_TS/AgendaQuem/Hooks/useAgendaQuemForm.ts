"use client";
import { useState } from 'react';
import { IAgendaQuem } from '../Interfaces/interface.AgendaQuem';
import { IAgendaQuemService } from '../Services/AgendaQuem.service';

export const useAgendaQuemForm = (
  initialAgendaQuem: IAgendaQuem,
  dataService: IAgendaQuemService
) => {
  const [data, setData] = useState<IAgendaQuem>(initialAgendaQuem);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadAgendaQuem = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchAgendaQuemById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadAgendaQuem,
  };
};
