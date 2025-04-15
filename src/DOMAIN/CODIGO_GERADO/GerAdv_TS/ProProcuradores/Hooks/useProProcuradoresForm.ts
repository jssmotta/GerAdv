"use client";
import { useState } from 'react';
import { IProProcuradores } from '../Interfaces/interface.ProProcuradores';
import { IProProcuradoresService } from '../Services/ProProcuradores.service';

export const useProProcuradoresForm = (
  initialProProcuradores: IProProcuradores,
  dataService: IProProcuradoresService
) => {
  const [data, setData] = useState<IProProcuradores>(initialProProcuradores);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadProProcuradores = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchProProcuradoresById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadProProcuradores,
  };
};
