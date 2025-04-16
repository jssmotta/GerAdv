"use client";
import { useState } from 'react';
import { IParceriaProc } from '../Interfaces/interface.ParceriaProc';
import { IParceriaProcService } from '../Services/ParceriaProc.service';

export const useParceriaProcForm = (
  initialParceriaProc: IParceriaProc,
  dataService: IParceriaProcService
) => {
  const [data, setData] = useState<IParceriaProc>(initialParceriaProc);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadParceriaProc = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchParceriaProcById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadParceriaProc,
  };
};
