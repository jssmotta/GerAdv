"use client";
import { useState } from 'react';
import { IOperadorGruposAgendaOperadores } from '../Interfaces/interface.OperadorGruposAgendaOperadores';
import { IOperadorGruposAgendaOperadoresService } from '../Services/OperadorGruposAgendaOperadores.service';

export const useOperadorGruposAgendaOperadoresForm = (
  initialOperadorGruposAgendaOperadores: IOperadorGruposAgendaOperadores,
  dataService: IOperadorGruposAgendaOperadoresService
) => {
  const [data, setData] = useState<IOperadorGruposAgendaOperadores>(initialOperadorGruposAgendaOperadores);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadOperadorGruposAgendaOperadores = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchOperadorGruposAgendaOperadoresById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadOperadorGruposAgendaOperadores,
  };
};
