"use client";
import { useState } from 'react';
import { IEnderecoSistema } from '../Interfaces/interface.EnderecoSistema';
import { IEnderecoSistemaService } from '../Services/EnderecoSistema.service';

export const useEnderecoSistemaForm = (
  initialEnderecoSistema: IEnderecoSistema,
  dataService: IEnderecoSistemaService
) => {
  const [data, setData] = useState<IEnderecoSistema>(initialEnderecoSistema);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadEnderecoSistema = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchEnderecoSistemaById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadEnderecoSistema,
  };
};
