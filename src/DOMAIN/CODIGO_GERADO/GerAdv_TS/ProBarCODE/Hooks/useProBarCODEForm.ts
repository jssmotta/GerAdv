"use client";
import { useState } from 'react';
import { IProBarCODE } from '../Interfaces/interface.ProBarCODE';
import { IProBarCODEService } from '../Services/ProBarCODE.service';

export const useProBarCODEForm = (
  initialProBarCODE: IProBarCODE,
  dataService: IProBarCODEService
) => {
  const [data, setData] = useState<IProBarCODE>(initialProBarCODE);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadProBarCODE = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchProBarCODEById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadProBarCODE,
  };
};
