"use client";
import { useState } from 'react';
import { IGruposEmpresas } from '../Interfaces/interface.GruposEmpresas';
import { IGruposEmpresasService } from '../Services/GruposEmpresas.service';

export const useGruposEmpresasForm = (
  initialGruposEmpresas: IGruposEmpresas,
  dataService: IGruposEmpresasService
) => {
  const [data, setData] = useState<IGruposEmpresas>(initialGruposEmpresas);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadGruposEmpresas = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchGruposEmpresasById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadGruposEmpresas,
  };
};
