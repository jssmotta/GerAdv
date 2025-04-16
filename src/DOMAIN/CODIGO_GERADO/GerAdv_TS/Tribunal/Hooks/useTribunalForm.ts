"use client";
import { useState } from 'react';
import { ITribunal } from '../Interfaces/interface.Tribunal';
import { ITribunalService } from '../Services/Tribunal.service';

export const useTribunalForm = (
  initialTribunal: ITribunal,
  dataService: ITribunalService
) => {
  const [data, setData] = useState<ITribunal>(initialTribunal);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadTribunal = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchTribunalById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadTribunal,
  };
};
