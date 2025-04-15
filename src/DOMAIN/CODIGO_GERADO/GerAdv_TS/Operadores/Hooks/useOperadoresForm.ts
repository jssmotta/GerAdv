"use client";
import { useState } from 'react';
import { IOperadores } from '../Interfaces/interface.Operadores';
import { IOperadoresService } from '../Services/Operadores.service';

export const useOperadoresForm = (
  initialOperadores: IOperadores,
  dataService: IOperadoresService
) => {
  const [data, setData] = useState<IOperadores>(initialOperadores);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadOperadores = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchOperadoresById(id);
			dados.senha256 = '';
			dados.suportesenha256 = '';
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadOperadores,
  };
};
