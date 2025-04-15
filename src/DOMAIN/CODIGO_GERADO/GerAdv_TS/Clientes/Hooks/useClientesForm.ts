"use client";
import { useState } from 'react';
import { IClientes } from '../Interfaces/interface.Clientes';
import { IClientesService } from '../Services/Clientes.service';

export const useClientesForm = (
  initialClientes: IClientes,
  dataService: IClientesService
) => {
  const [data, setData] = useState<IClientes>(initialClientes);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadClientes = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchClientesById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadClientes,
  };
};
