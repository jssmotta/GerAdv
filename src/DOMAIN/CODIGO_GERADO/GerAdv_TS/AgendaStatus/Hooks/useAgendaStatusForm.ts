"use client";
import { useState } from 'react';
import { IAgendaStatus } from '../Interfaces/interface.AgendaStatus';
import { IAgendaStatusService } from '../Services/AgendaStatus.service';

export const useAgendaStatusForm = (
  initialAgendaStatus: IAgendaStatus,
  dataService: IAgendaStatusService
) => {
  const [data, setData] = useState<IAgendaStatus>(initialAgendaStatus);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadAgendaStatus = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchAgendaStatusById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadAgendaStatus,
  };
};
