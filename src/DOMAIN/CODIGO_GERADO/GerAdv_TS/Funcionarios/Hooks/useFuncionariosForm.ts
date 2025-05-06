"use client";
import { useState } from 'react';
import { IFuncionarios } from '../Interfaces/interface.Funcionarios';
import { IFuncionariosService } from '../Services/Funcionarios.service';

export const useFuncionariosForm = (
  initialFuncionarios: IFuncionarios,
  dataService: IFuncionariosService
) => {
  const [data, setData] = useState<IFuncionarios>(initialFuncionarios);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadFuncionarios = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchFuncionariosById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadFuncionarios,
  };
};
