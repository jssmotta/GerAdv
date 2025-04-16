"use client";
import { useState } from 'react';
import { IProSucumbencia } from '../Interfaces/interface.ProSucumbencia';
import { IProSucumbenciaService } from '../Services/ProSucumbencia.service';

export const useProSucumbenciaForm = (
  initialProSucumbencia: IProSucumbencia,
  dataService: IProSucumbenciaService
) => {
  const [data, setData] = useState<IProSucumbencia>(initialProSucumbencia);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadProSucumbencia = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchProSucumbenciaById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadProSucumbencia,
  };
};
