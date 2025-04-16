"use client";
import { useState } from 'react';
import { IOutrasPartesCliente } from '../Interfaces/interface.OutrasPartesCliente';
import { IOutrasPartesClienteService } from '../Services/OutrasPartesCliente.service';

export const useOutrasPartesClienteForm = (
  initialOutrasPartesCliente: IOutrasPartesCliente,
  dataService: IOutrasPartesClienteService
) => {
  const [data, setData] = useState<IOutrasPartesCliente>(initialOutrasPartesCliente);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadOutrasPartesCliente = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchOutrasPartesClienteById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadOutrasPartesCliente,
  };
};
