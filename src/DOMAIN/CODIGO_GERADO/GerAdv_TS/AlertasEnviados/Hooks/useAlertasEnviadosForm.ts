"use client";
import { useState } from 'react';
import { IAlertasEnviados } from '../Interfaces/interface.AlertasEnviados';
import { IAlertasEnviadosService } from '../Services/AlertasEnviados.service';

export const useAlertasEnviadosForm = (
  initialAlertasEnviados: IAlertasEnviados,
  dataService: IAlertasEnviadosService
) => {
  const [data, setData] = useState<IAlertasEnviados>(initialAlertasEnviados);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadAlertasEnviados = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchAlertasEnviadosById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadAlertasEnviados,
  };
};
