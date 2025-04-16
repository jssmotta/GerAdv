"use client";
import { useState } from 'react';
import { IStatusHTrab } from '../Interfaces/interface.StatusHTrab';
import { IStatusHTrabService } from '../Services/StatusHTrab.service';

export const useStatusHTrabForm = (
  initialStatusHTrab: IStatusHTrab,
  dataService: IStatusHTrabService
) => {
  const [data, setData] = useState<IStatusHTrab>(initialStatusHTrab);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadStatusHTrab = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchStatusHTrabById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadStatusHTrab,
  };
};
