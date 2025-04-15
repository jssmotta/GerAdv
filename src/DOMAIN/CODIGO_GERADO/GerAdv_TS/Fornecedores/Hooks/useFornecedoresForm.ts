"use client";
import { useState } from 'react';
import { IFornecedores } from '../Interfaces/interface.Fornecedores';
import { IFornecedoresService } from '../Services/Fornecedores.service';

export const useFornecedoresForm = (
  initialFornecedores: IFornecedores,
  dataService: IFornecedoresService
) => {
  const [data, setData] = useState<IFornecedores>(initialFornecedores);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadFornecedores = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchFornecedoresById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadFornecedores,
  };
};
