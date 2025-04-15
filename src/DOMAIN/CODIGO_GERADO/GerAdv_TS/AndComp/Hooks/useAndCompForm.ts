"use client";
import { useState } from 'react';
import { IAndComp } from '../Interfaces/interface.AndComp';
import { IAndCompService } from '../Services/AndComp.service';

export const useAndCompForm = (
  initialAndComp: IAndComp,
  dataService: IAndCompService
) => {
  const [data, setData] = useState<IAndComp>(initialAndComp);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadAndComp = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchAndCompById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadAndComp,
  };
};
