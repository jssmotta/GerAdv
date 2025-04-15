"use client";
import { useState } from 'react';
import { IParteOponente } from '../Interfaces/interface.ParteOponente';
import { IParteOponenteService } from '../Services/ParteOponente.service';

export const useParteOponenteForm = (
  initialParteOponente: IParteOponente,
  dataService: IParteOponenteService
) => {
  const [data, setData] = useState<IParteOponente>(initialParteOponente);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadParteOponente = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchParteOponenteById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadParteOponente,
  };
};
