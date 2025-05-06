"use client";
import { useState } from 'react';
import { IPenhoraStatus } from '../Interfaces/interface.PenhoraStatus';
import { IPenhoraStatusService } from '../Services/PenhoraStatus.service';

export const usePenhoraStatusForm = (
  initialPenhoraStatus: IPenhoraStatus,
  dataService: IPenhoraStatusService
) => {
  const [data, setData] = useState<IPenhoraStatus>(initialPenhoraStatus);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadPenhoraStatus = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchPenhoraStatusById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadPenhoraStatus,
  };
};
