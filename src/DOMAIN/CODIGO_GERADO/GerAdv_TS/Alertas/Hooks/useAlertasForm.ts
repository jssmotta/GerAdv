"use client";
import { useState } from 'react';
import { IAlertas } from '../Interfaces/interface.Alertas';
import { IAlertasService } from '../Services/Alertas.service';

export const useAlertasForm = (
  initialAlertas: IAlertas,
  dataService: IAlertasService
) => {
  const [data, setData] = useState<IAlertas>(initialAlertas);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadAlertas = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchAlertasById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadAlertas,
  };
};
