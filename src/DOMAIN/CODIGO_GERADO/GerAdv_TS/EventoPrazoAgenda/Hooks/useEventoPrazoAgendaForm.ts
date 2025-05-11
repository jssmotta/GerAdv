"use client";
import { useState } from 'react';
import { IEventoPrazoAgenda } from '../Interfaces/interface.EventoPrazoAgenda';
import { IEventoPrazoAgendaService } from '../Services/EventoPrazoAgenda.service';

export const useEventoPrazoAgendaForm = (
  initialEventoPrazoAgenda: IEventoPrazoAgenda,
  dataService: IEventoPrazoAgendaService
) => {
  const [data, setData] = useState<IEventoPrazoAgenda>(initialEventoPrazoAgenda);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadEventoPrazoAgenda = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchEventoPrazoAgendaById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadEventoPrazoAgenda,
  };
};
