"use client";
import { useState } from 'react';
import { IHistorico } from '../Interfaces/interface.Historico';
import { IHistoricoService } from '../Services/Historico.service';

export const useHistoricoForm = (
  initialHistorico: IHistorico,
  dataService: IHistoricoService
) => {
  const [data, setData] = useState<IHistorico>(initialHistorico);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadHistorico = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchHistoricoById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadHistorico,
  };
};
