"use client";
import { useState } from 'react';
import { IOperadorGrupo } from '../Interfaces/interface.OperadorGrupo';
import { IOperadorGrupoService } from '../Services/OperadorGrupo.service';

export const useOperadorGrupoForm = (
  initialOperadorGrupo: IOperadorGrupo,
  dataService: IOperadorGrupoService
) => {
  const [data, setData] = useState<IOperadorGrupo>(initialOperadorGrupo);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadOperadorGrupo = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchOperadorGrupoById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadOperadorGrupo,
  };
};
