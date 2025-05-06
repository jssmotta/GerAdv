"use client";
import { useState } from 'react';
import { IViaRecebimento } from '../Interfaces/interface.ViaRecebimento';
import { IViaRecebimentoService } from '../Services/ViaRecebimento.service';

export const useViaRecebimentoForm = (
  initialViaRecebimento: IViaRecebimento,
  dataService: IViaRecebimentoService
) => {
  const [data, setData] = useState<IViaRecebimento>(initialViaRecebimento);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadViaRecebimento = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchViaRecebimentoById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadViaRecebimento,
  };
};
