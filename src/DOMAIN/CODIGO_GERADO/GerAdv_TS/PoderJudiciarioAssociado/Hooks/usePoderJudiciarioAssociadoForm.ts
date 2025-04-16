"use client";
import { useState } from 'react';
import { IPoderJudiciarioAssociado } from '../Interfaces/interface.PoderJudiciarioAssociado';
import { IPoderJudiciarioAssociadoService } from '../Services/PoderJudiciarioAssociado.service';

export const usePoderJudiciarioAssociadoForm = (
  initialPoderJudiciarioAssociado: IPoderJudiciarioAssociado,
  dataService: IPoderJudiciarioAssociadoService
) => {
  const [data, setData] = useState<IPoderJudiciarioAssociado>(initialPoderJudiciarioAssociado);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadPoderJudiciarioAssociado = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchPoderJudiciarioAssociadoById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadPoderJudiciarioAssociado,
  };
};
