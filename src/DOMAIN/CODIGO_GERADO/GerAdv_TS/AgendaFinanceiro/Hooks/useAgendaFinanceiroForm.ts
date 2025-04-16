"use client";
import { useState } from 'react';
import { IAgendaFinanceiro } from '../Interfaces/interface.AgendaFinanceiro';
import { IAgendaFinanceiroService } from '../Services/AgendaFinanceiro.service';

export const useAgendaFinanceiroForm = (
  initialAgendaFinanceiro: IAgendaFinanceiro,
  dataService: IAgendaFinanceiroService
) => {
  const [data, setData] = useState<IAgendaFinanceiro>(initialAgendaFinanceiro);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadAgendaFinanceiro = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchAgendaFinanceiroById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadAgendaFinanceiro,
  };
};
