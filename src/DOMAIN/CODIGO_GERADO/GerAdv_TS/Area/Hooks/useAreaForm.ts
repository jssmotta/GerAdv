"use client";
import { useState } from 'react';
import { IArea } from '../Interfaces/interface.Area';
import { IAreaService } from '../Services/Area.service';

export const useAreaForm = (
  initialArea: IArea,
  dataService: IAreaService
) => {
  const [data, setData] = useState<IArea>(initialArea);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadArea = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchAreaById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadArea,
  };
};
