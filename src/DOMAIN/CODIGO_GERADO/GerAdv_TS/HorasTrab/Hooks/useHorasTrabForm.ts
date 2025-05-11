"use client";
import { useState } from 'react';
import { IHorasTrab } from '../Interfaces/interface.HorasTrab';
import { IHorasTrabService } from '../Services/HorasTrab.service';

export const useHorasTrabForm = (
  initialHorasTrab: IHorasTrab,
  dataService: IHorasTrabService
) => {
  const [data, setData] = useState<IHorasTrab>(initialHorasTrab);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadHorasTrab = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchHorasTrabById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadHorasTrab,
  };
};
