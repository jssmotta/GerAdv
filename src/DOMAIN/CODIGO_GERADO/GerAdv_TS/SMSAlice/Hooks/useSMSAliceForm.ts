"use client";
import { useState } from 'react';
import { ISMSAlice } from '../Interfaces/interface.SMSAlice';
import { ISMSAliceService } from '../Services/SMSAlice.service';

export const useSMSAliceForm = (
  initialSMSAlice: ISMSAlice,
  dataService: ISMSAliceService
) => {
  const [data, setData] = useState<ISMSAlice>(initialSMSAlice);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadSMSAlice = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchSMSAliceById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadSMSAlice,
  };
};
