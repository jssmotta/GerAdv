"use client";
import { useState } from 'react';
import { IGUTPeriodicidadeStatus } from '../Interfaces/interface.GUTPeriodicidadeStatus';
import { IGUTPeriodicidadeStatusService } from '../Services/GUTPeriodicidadeStatus.service';

export const useGUTPeriodicidadeStatusForm = (
  initialGUTPeriodicidadeStatus: IGUTPeriodicidadeStatus,
  dataService: IGUTPeriodicidadeStatusService
) => {
  const [data, setData] = useState<IGUTPeriodicidadeStatus>(initialGUTPeriodicidadeStatus);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadGUTPeriodicidadeStatus = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchGUTPeriodicidadeStatusById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadGUTPeriodicidadeStatus,
  };
};
