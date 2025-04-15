"use client";
import { useState } from 'react';
import { IModelosDocumentos } from '../Interfaces/interface.ModelosDocumentos';
import { IModelosDocumentosService } from '../Services/ModelosDocumentos.service';

export const useModelosDocumentosForm = (
  initialModelosDocumentos: IModelosDocumentos,
  dataService: IModelosDocumentosService
) => {
  const [data, setData] = useState<IModelosDocumentos>(initialModelosDocumentos);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadModelosDocumentos = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchModelosDocumentosById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadModelosDocumentos,
  };
};
