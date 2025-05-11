"use client";
import { useState } from 'react';
import { IGUTAtividadesMatriz } from '../Interfaces/interface.GUTAtividadesMatriz';
import { IGUTAtividadesMatrizService } from '../Services/GUTAtividadesMatriz.service';

export const useGUTAtividadesMatrizForm = (
  initialGUTAtividadesMatriz: IGUTAtividadesMatriz,
  dataService: IGUTAtividadesMatrizService
) => {
  const [data, setData] = useState<IGUTAtividadesMatriz>(initialGUTAtividadesMatriz);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadGUTAtividadesMatriz = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchGUTAtividadesMatrizById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadGUTAtividadesMatriz,
  };
};
