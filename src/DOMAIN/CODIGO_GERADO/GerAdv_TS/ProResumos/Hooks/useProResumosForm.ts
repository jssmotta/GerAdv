"use client";
import { useState } from 'react';
import { IProResumos } from '../Interfaces/interface.ProResumos';
import { IProResumosService } from '../Services/ProResumos.service';

export const useProResumosForm = (
  initialProResumos: IProResumos,
  dataService: IProResumosService
) => {
  const [data, setData] = useState<IProResumos>(initialProResumos);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadProResumos = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchProResumosById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadProResumos,
  };
};
