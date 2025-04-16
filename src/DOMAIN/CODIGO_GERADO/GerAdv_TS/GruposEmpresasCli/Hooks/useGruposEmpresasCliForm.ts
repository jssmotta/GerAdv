"use client";
import { useState } from 'react';
import { IGruposEmpresasCli } from '../Interfaces/interface.GruposEmpresasCli';
import { IGruposEmpresasCliService } from '../Services/GruposEmpresasCli.service';

export const useGruposEmpresasCliForm = (
  initialGruposEmpresasCli: IGruposEmpresasCli,
  dataService: IGruposEmpresasCliService
) => {
  const [data, setData] = useState<IGruposEmpresasCli>(initialGruposEmpresasCli);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadGruposEmpresasCli = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchGruposEmpresasCliById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadGruposEmpresasCli,
  };
};
