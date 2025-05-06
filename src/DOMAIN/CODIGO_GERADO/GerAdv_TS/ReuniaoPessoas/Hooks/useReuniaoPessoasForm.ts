"use client";
import { useState } from 'react';
import { IReuniaoPessoas } from '../Interfaces/interface.ReuniaoPessoas';
import { IReuniaoPessoasService } from '../Services/ReuniaoPessoas.service';

export const useReuniaoPessoasForm = (
  initialReuniaoPessoas: IReuniaoPessoas,
  dataService: IReuniaoPessoasService
) => {
  const [data, setData] = useState<IReuniaoPessoas>(initialReuniaoPessoas);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadReuniaoPessoas = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchReuniaoPessoasById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadReuniaoPessoas,
  };
};
