"use client";
import { useState } from 'react';
import { IEndTit } from '../Interfaces/interface.EndTit';
import { IEndTitService } from '../Services/EndTit.service';

export const useEndTitForm = (
  initialEndTit: IEndTit,
  dataService: IEndTitService
) => {
  const [data, setData] = useState<IEndTit>(initialEndTit);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadEndTit = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchEndTitById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadEndTit,
  };
};
