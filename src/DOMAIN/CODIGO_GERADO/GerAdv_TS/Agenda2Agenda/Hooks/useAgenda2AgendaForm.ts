"use client";
import { useState } from 'react';
import { IAgenda2Agenda } from '../Interfaces/interface.Agenda2Agenda';
import { IAgenda2AgendaService } from '../Services/Agenda2Agenda.service';

export const useAgenda2AgendaForm = (
  initialAgenda2Agenda: IAgenda2Agenda,
  dataService: IAgenda2AgendaService
) => {
  const [data, setData] = useState<IAgenda2Agenda>(initialAgenda2Agenda);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadAgenda2Agenda = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchAgenda2AgendaById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadAgenda2Agenda,
  };
};
