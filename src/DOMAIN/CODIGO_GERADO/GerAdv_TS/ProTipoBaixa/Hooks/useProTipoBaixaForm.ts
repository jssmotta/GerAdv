"use client";
import { useState } from 'react';
import { IProTipoBaixa } from '../Interfaces/interface.ProTipoBaixa';
import { IProTipoBaixaService } from '../Services/ProTipoBaixa.service';

export const useProTipoBaixaForm = (
  initialProTipoBaixa: IProTipoBaixa,
  dataService: IProTipoBaixaService
) => {
  const [data, setData] = useState<IProTipoBaixa>(initialProTipoBaixa);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadProTipoBaixa = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchProTipoBaixaById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadProTipoBaixa,
  };
};
