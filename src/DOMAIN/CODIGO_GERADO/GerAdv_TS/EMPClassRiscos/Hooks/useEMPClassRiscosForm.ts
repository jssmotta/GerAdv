"use client";
import { useState } from 'react';
import { IEMPClassRiscos } from '../Interfaces/interface.EMPClassRiscos';
import { IEMPClassRiscosService } from '../Services/EMPClassRiscos.service';

export const useEMPClassRiscosForm = (
  initialEMPClassRiscos: IEMPClassRiscos,
  dataService: IEMPClassRiscosService
) => {
  const [data, setData] = useState<IEMPClassRiscos>(initialEMPClassRiscos);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadEMPClassRiscos = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchEMPClassRiscosById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadEMPClassRiscos,
  };
};
