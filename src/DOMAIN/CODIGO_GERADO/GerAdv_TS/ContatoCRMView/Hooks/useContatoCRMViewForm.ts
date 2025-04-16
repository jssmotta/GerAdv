"use client";
import { useState } from 'react';
import { IContatoCRMView } from '../Interfaces/interface.ContatoCRMView';
import { IContatoCRMViewService } from '../Services/ContatoCRMView.service';

export const useContatoCRMViewForm = (
  initialContatoCRMView: IContatoCRMView,
  dataService: IContatoCRMViewService
) => {
  const [data, setData] = useState<IContatoCRMView>(initialContatoCRMView);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadContatoCRMView = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchContatoCRMViewById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadContatoCRMView,
  };
};
