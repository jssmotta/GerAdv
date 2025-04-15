"use client";
import { useState } from 'react';
import { IParteCliente } from '../Interfaces/interface.ParteCliente';
import { IParteClienteService } from '../Services/ParteCliente.service';

export const useParteClienteForm = (
  initialParteCliente: IParteCliente,
  dataService: IParteClienteService
) => {
  const [data, setData] = useState<IParteCliente>(initialParteCliente);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadParteCliente = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchParteClienteById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadParteCliente,
  };
};
