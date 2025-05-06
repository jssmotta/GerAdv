"use client";
import { useState } from 'react';
import { IProDepositos } from '../Interfaces/interface.ProDepositos';
import { IProDepositosService } from '../Services/ProDepositos.service';

export const useProDepositosForm = (
  initialProDepositos: IProDepositos,
  dataService: IProDepositosService
) => {
  const [data, setData] = useState<IProDepositos>(initialProDepositos);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadProDepositos = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchProDepositosById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadProDepositos,
  };
};
