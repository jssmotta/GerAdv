"use client";
import { useState } from 'react';
import { ILivroCaixaClientes } from '../Interfaces/interface.LivroCaixaClientes';
import { ILivroCaixaClientesService } from '../Services/LivroCaixaClientes.service';

export const useLivroCaixaClientesForm = (
  initialLivroCaixaClientes: ILivroCaixaClientes,
  dataService: ILivroCaixaClientesService
) => {
  const [data, setData] = useState<ILivroCaixaClientes>(initialLivroCaixaClientes);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadLivroCaixaClientes = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchLivroCaixaClientesById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadLivroCaixaClientes,
  };
};
