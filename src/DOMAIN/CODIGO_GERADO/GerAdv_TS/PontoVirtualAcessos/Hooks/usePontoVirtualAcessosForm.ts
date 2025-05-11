"use client";
import { useState } from 'react';
import { IPontoVirtualAcessos } from '../Interfaces/interface.PontoVirtualAcessos';
import { IPontoVirtualAcessosService } from '../Services/PontoVirtualAcessos.service';

export const usePontoVirtualAcessosForm = (
  initialPontoVirtualAcessos: IPontoVirtualAcessos,
  dataService: IPontoVirtualAcessosService
) => {
  const [data, setData] = useState<IPontoVirtualAcessos>(initialPontoVirtualAcessos);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadPontoVirtualAcessos = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchPontoVirtualAcessosById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadPontoVirtualAcessos,
  };
};
