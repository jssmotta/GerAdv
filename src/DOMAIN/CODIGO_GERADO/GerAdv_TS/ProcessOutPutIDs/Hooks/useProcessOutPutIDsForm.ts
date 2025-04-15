"use client";
import { useState } from 'react';
import { IProcessOutPutIDs } from '../Interfaces/interface.ProcessOutPutIDs';
import { IProcessOutPutIDsService } from '../Services/ProcessOutPutIDs.service';

export const useProcessOutPutIDsForm = (
  initialProcessOutPutIDs: IProcessOutPutIDs,
  dataService: IProcessOutPutIDsService
) => {
  const [data, setData] = useState<IProcessOutPutIDs>(initialProcessOutPutIDs);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadProcessOutPutIDs = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchProcessOutPutIDsById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadProcessOutPutIDs,
  };
};
