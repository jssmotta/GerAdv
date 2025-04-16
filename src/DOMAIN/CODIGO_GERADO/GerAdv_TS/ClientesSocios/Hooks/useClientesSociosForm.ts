"use client";
import { useState } from 'react';
import { IClientesSocios } from '../Interfaces/interface.ClientesSocios';
import { IClientesSociosService } from '../Services/ClientesSocios.service';

export const useClientesSociosForm = (
  initialClientesSocios: IClientesSocios,
  dataService: IClientesSociosService
) => {
  const [data, setData] = useState<IClientesSocios>(initialClientesSocios);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadClientesSocios = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchClientesSociosById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadClientesSocios,
  };
};
