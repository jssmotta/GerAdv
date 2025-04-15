"use client";
import { useState } from 'react';
import { ITipoEMail } from '../Interfaces/interface.TipoEMail';
import { ITipoEMailService } from '../Services/TipoEMail.service';

export const useTipoEMailForm = (
  initialTipoEMail: ITipoEMail,
  dataService: ITipoEMailService
) => {
  const [data, setData] = useState<ITipoEMail>(initialTipoEMail);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadTipoEMail = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchTipoEMailById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadTipoEMail,
  };
};
