"use client";
import { useState } from 'react';
import { IOponentesRepLegal } from '../Interfaces/interface.OponentesRepLegal';
import { IOponentesRepLegalService } from '../Services/OponentesRepLegal.service';

export const useOponentesRepLegalForm = (
  initialOponentesRepLegal: IOponentesRepLegal,
  dataService: IOponentesRepLegalService
) => {
  const [data, setData] = useState<IOponentesRepLegal>(initialOponentesRepLegal);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadOponentesRepLegal = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchOponentesRepLegalById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadOponentesRepLegal,
  };
};
