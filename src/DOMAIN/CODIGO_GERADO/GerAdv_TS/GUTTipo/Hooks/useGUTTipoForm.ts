"use client";
import { useState } from 'react';
import { IGUTTipo } from '../Interfaces/interface.GUTTipo';
import { IGUTTipoService } from '../Services/GUTTipo.service';

export const useGUTTipoForm = (
  initialGUTTipo: IGUTTipo,
  dataService: IGUTTipoService
) => {
  const [data, setData] = useState<IGUTTipo>(initialGUTTipo);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadGUTTipo = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchGUTTipoById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadGUTTipo,
  };
};
