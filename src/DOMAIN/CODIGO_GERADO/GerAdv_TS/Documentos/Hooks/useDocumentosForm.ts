"use client";
import { useState } from 'react';
import { IDocumentos } from '../Interfaces/interface.Documentos';
import { IDocumentosService } from '../Services/Documentos.service';

export const useDocumentosForm = (
  initialDocumentos: IDocumentos,
  dataService: IDocumentosService
) => {
  const [data, setData] = useState<IDocumentos>(initialDocumentos);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadDocumentos = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchDocumentosById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadDocumentos,
  };
};
