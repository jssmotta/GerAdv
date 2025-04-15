"use client";
import { useState } from 'react';
import { IOperadorGrupos } from '../Interfaces/interface.OperadorGrupos';
import { IOperadorGruposService } from '../Services/OperadorGrupos.service';

export const useOperadorGruposForm = (
  initialOperadorGrupos: IOperadorGrupos,
  dataService: IOperadorGruposService
) => {
  const [data, setData] = useState<IOperadorGrupos>(initialOperadorGrupos);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadOperadorGrupos = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchOperadorGruposById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadOperadorGrupos,
  };
};
