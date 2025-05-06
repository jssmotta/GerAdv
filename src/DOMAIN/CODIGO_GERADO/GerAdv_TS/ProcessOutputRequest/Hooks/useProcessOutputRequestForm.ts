"use client";
import { useState } from 'react';
import { IProcessOutputRequest } from '../Interfaces/interface.ProcessOutputRequest';
import { IProcessOutputRequestService } from '../Services/ProcessOutputRequest.service';

export const useProcessOutputRequestForm = (
  initialProcessOutputRequest: IProcessOutputRequest,
  dataService: IProcessOutputRequestService
) => {
  const [data, setData] = useState<IProcessOutputRequest>(initialProcessOutputRequest);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadProcessOutputRequest = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchProcessOutputRequestById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadProcessOutputRequest,
  };
};
