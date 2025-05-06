"use client";
import { useState } from 'react';
import { IAuditor4K } from '../Interfaces/interface.Auditor4K';
import { IAuditor4KService } from '../Services/Auditor4K.service';

export const useAuditor4KForm = (
  initialAuditor4K: IAuditor4K,
  dataService: IAuditor4KService
) => {
  const [data, setData] = useState<IAuditor4K>(initialAuditor4K);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadAuditor4K = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchAuditor4KById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadAuditor4K,
  };
};
