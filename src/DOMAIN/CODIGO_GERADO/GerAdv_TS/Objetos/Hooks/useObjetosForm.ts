"use client";
import { useState } from 'react';
import { IObjetos } from '../Interfaces/interface.Objetos';
import { IObjetosService } from '../Services/Objetos.service';

export const useObjetosForm = (
  initialObjetos: IObjetos,
  dataService: IObjetosService
) => {
  const [data, setData] = useState<IObjetos>(initialObjetos);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadObjetos = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchObjetosById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadObjetos,
  };
};
