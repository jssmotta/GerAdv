"use client";
import { useState } from 'react';
import { IDocsRecebidosItens } from '../Interfaces/interface.DocsRecebidosItens';
import { IDocsRecebidosItensService } from '../Services/DocsRecebidosItens.service';

export const useDocsRecebidosItensForm = (
  initialDocsRecebidosItens: IDocsRecebidosItens,
  dataService: IDocsRecebidosItensService
) => {
  const [data, setData] = useState<IDocsRecebidosItens>(initialDocsRecebidosItens);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadDocsRecebidosItens = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchDocsRecebidosItensById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadDocsRecebidosItens,
  };
};
