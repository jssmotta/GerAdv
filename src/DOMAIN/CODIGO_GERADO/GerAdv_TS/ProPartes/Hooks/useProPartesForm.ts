"use client";
import { useState } from 'react';
import { IProPartes } from '../Interfaces/interface.ProPartes';
import { IProPartesService } from '../Services/ProPartes.service';

export const useProPartesForm = (
  initialProPartes: IProPartes,
  dataService: IProPartesService
) => {
  const [data, setData] = useState<IProPartes>(initialProPartes);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadProPartes = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchProPartesById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadProPartes,
  };
};
