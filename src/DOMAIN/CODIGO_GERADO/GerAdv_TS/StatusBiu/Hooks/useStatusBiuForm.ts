"use client";
import { useState } from 'react';
import { IStatusBiu } from '../Interfaces/interface.StatusBiu';
import { IStatusBiuService } from '../Services/StatusBiu.service';

export const useStatusBiuForm = (
  initialStatusBiu: IStatusBiu,
  dataService: IStatusBiuService
) => {
  const [data, setData] = useState<IStatusBiu>(initialStatusBiu);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadStatusBiu = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchStatusBiuById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadStatusBiu,
  };
};
