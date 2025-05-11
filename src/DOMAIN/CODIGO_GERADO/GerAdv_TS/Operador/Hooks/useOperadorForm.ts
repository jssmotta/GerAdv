"use client";
import { useState } from 'react';
import { IOperador } from '../Interfaces/interface.Operador';
import { IOperadorService } from '../Services/Operador.service';

export const useOperadorForm = (
  initialOperador: IOperador,
  dataService: IOperadorService
) => {
  const [data, setData] = useState<IOperador>(initialOperador);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadOperador = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchOperadorById(id);
			dados.senha256 = '';
			dados.suportesenha256 = '';
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadOperador,
  };
};
