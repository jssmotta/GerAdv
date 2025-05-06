"use client";
import { useState } from 'react';
import { IEnderecos } from '../Interfaces/interface.Enderecos';
import { IEnderecosService } from '../Services/Enderecos.service';

export const useEnderecosForm = (
  initialEnderecos: IEnderecos,
  dataService: IEnderecosService
) => {
  const [data, setData] = useState<IEnderecos>(initialEnderecos);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadEnderecos = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchEnderecosById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadEnderecos,
  };
};
