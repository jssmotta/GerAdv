"use client";
import { useState } from 'react';
import { IEnquadramentoEmpresa } from '../Interfaces/interface.EnquadramentoEmpresa';
import { IEnquadramentoEmpresaService } from '../Services/EnquadramentoEmpresa.service';

export const useEnquadramentoEmpresaForm = (
  initialEnquadramentoEmpresa: IEnquadramentoEmpresa,
  dataService: IEnquadramentoEmpresaService
) => {
  const [data, setData] = useState<IEnquadramentoEmpresa>(initialEnquadramentoEmpresa);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadEnquadramentoEmpresa = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchEnquadramentoEmpresaById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadEnquadramentoEmpresa,
  };
};
