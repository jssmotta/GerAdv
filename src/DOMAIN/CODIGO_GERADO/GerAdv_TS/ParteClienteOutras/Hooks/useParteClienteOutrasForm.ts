"use client";
import { useState } from 'react';
import { IParteClienteOutras } from '../Interfaces/interface.ParteClienteOutras';
import { IParteClienteOutrasService } from '../Services/ParteClienteOutras.service';

export const useParteClienteOutrasForm = (
  initialParteClienteOutras: IParteClienteOutras,
  dataService: IParteClienteOutrasService
) => {
  const [data, setData] = useState<IParteClienteOutras>(initialParteClienteOutras);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadParteClienteOutras = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchParteClienteOutrasById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadParteClienteOutras,
  };
};
