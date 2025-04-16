"use client";
import { useState } from 'react';
import { ITipoModeloDocumento } from '../Interfaces/interface.TipoModeloDocumento';
import { ITipoModeloDocumentoService } from '../Services/TipoModeloDocumento.service';

export const useTipoModeloDocumentoForm = (
  initialTipoModeloDocumento: ITipoModeloDocumento,
  dataService: ITipoModeloDocumentoService
) => {
  const [data, setData] = useState<ITipoModeloDocumento>(initialTipoModeloDocumento);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadTipoModeloDocumento = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchTipoModeloDocumentoById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadTipoModeloDocumento,
  };
};
