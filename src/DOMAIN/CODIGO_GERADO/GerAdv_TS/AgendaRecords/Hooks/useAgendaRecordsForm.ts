"use client";
import { useState } from 'react';
import { IAgendaRecords } from '../Interfaces/interface.AgendaRecords';
import { IAgendaRecordsService } from '../Services/AgendaRecords.service';

export const useAgendaRecordsForm = (
  initialAgendaRecords: IAgendaRecords,
  dataService: IAgendaRecordsService
) => {
  const [data, setData] = useState<IAgendaRecords>(initialAgendaRecords);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadAgendaRecords = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchAgendaRecordsById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadAgendaRecords,
  };
};
