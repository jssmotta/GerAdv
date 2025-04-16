"use client";
import { useState } from 'react';
import { ITribEnderecos } from '../Interfaces/interface.TribEnderecos';
import { ITribEnderecosService } from '../Services/TribEnderecos.service';

export const useTribEnderecosForm = (
  initialTribEnderecos: ITribEnderecos,
  dataService: ITribEnderecosService
) => {
  const [data, setData] = useState<ITribEnderecos>(initialTribEnderecos);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadTribEnderecos = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchTribEnderecosById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadTribEnderecos,
  };
};
