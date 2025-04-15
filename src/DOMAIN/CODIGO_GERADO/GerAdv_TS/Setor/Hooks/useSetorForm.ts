"use client";
import { useState } from 'react';
import { ISetor } from '../Interfaces/interface.Setor';
import { ISetorService } from '../Services/Setor.service';

export const useSetorForm = (
  initialSetor: ISetor,
  dataService: ISetorService
) => {
  const [data, setData] = useState<ISetor>(initialSetor);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadSetor = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchSetorById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadSetor,
  };
};
