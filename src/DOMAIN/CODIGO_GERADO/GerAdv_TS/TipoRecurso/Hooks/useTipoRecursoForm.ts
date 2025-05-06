"use client";
import { useState } from 'react';
import { ITipoRecurso } from '../Interfaces/interface.TipoRecurso';
import { ITipoRecursoService } from '../Services/TipoRecurso.service';

export const useTipoRecursoForm = (
  initialTipoRecurso: ITipoRecurso,
  dataService: ITipoRecursoService
) => {
  const [data, setData] = useState<ITipoRecurso>(initialTipoRecurso);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadTipoRecurso = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchTipoRecursoById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadTipoRecurso,
  };
};
