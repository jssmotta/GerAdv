"use client";
import { useState } from 'react';
import { IPreClientes } from '../Interfaces/interface.PreClientes';
import { IPreClientesService } from '../Services/PreClientes.service';

export const usePreClientesForm = (
  initialPreClientes: IPreClientes,
  dataService: IPreClientesService
) => {
  const [data, setData] = useState<IPreClientes>(initialPreClientes);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadPreClientes = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchPreClientesById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadPreClientes,
  };
};
