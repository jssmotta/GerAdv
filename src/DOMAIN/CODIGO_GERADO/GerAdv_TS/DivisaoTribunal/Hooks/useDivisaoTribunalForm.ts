"use client";
import { useState } from 'react';
import { IDivisaoTribunal } from '../Interfaces/interface.DivisaoTribunal';
import { IDivisaoTribunalService } from '../Services/DivisaoTribunal.service';

export const useDivisaoTribunalForm = (
  initialDivisaoTribunal: IDivisaoTribunal,
  dataService: IDivisaoTribunalService
) => {
  const [data, setData] = useState<IDivisaoTribunal>(initialDivisaoTribunal);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadDivisaoTribunal = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchDivisaoTribunalById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadDivisaoTribunal,
  };
};
