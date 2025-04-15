"use client";
import { useState } from 'react';
import { ITipoOrigemSucumbencia } from '../Interfaces/interface.TipoOrigemSucumbencia';
import { ITipoOrigemSucumbenciaService } from '../Services/TipoOrigemSucumbencia.service';

export const useTipoOrigemSucumbenciaForm = (
  initialTipoOrigemSucumbencia: ITipoOrigemSucumbencia,
  dataService: ITipoOrigemSucumbenciaService
) => {
  const [data, setData] = useState<ITipoOrigemSucumbencia>(initialTipoOrigemSucumbencia);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadTipoOrigemSucumbencia = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchTipoOrigemSucumbenciaById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadTipoOrigemSucumbencia,
  };
};
