"use client";
import { useState } from 'react';
import { IServicos } from '../Interfaces/interface.Servicos';
import { IServicosService } from '../Services/Servicos.service';

export const useServicosForm = (
  initialServicos: IServicos,
  dataService: IServicosService
) => {
  const [data, setData] = useState<IServicos>(initialServicos);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadServicos = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchServicosById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadServicos,
  };
};
