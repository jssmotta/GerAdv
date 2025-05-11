"use client";
import { useState } from 'react';
import { ICargosEscClass } from '../Interfaces/interface.CargosEscClass';
import { ICargosEscClassService } from '../Services/CargosEscClass.service';

export const useCargosEscClassForm = (
  initialCargosEscClass: ICargosEscClass,
  dataService: ICargosEscClassService
) => {
  const [data, setData] = useState<ICargosEscClass>(initialCargosEscClass);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadCargosEscClass = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchCargosEscClassById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadCargosEscClass,
  };
};
