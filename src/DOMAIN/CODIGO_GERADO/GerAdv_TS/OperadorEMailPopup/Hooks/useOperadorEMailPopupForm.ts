"use client";
import { useState } from 'react';
import { IOperadorEMailPopup } from '../Interfaces/interface.OperadorEMailPopup';
import { IOperadorEMailPopupService } from '../Services/OperadorEMailPopup.service';

export const useOperadorEMailPopupForm = (
  initialOperadorEMailPopup: IOperadorEMailPopup,
  dataService: IOperadorEMailPopupService
) => {
  const [data, setData] = useState<IOperadorEMailPopup>(initialOperadorEMailPopup);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadOperadorEMailPopup = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchOperadorEMailPopupById(id);
			dados.senha256 = '';
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadOperadorEMailPopup,
  };
};
