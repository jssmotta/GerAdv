"use client";
import { useState } from 'react';
import { IAreasJustica } from '../Interfaces/interface.AreasJustica';
import { IAreasJusticaService } from '../Services/AreasJustica.service';

export const useAreasJusticaForm = (
  initialAreasJustica: IAreasJustica,
  dataService: IAreasJusticaService
) => {
  const [data, setData] = useState<IAreasJustica>(initialAreasJustica);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadAreasJustica = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchAreasJusticaById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadAreasJustica,
  };
};
