"use client";
import { useState } from 'react';
import { IAlarmSMS } from '../Interfaces/interface.AlarmSMS';
import { IAlarmSMSService } from '../Services/AlarmSMS.service';

export const useAlarmSMSForm = (
  initialAlarmSMS: IAlarmSMS,
  dataService: IAlarmSMSService
) => {
  const [data, setData] = useState<IAlarmSMS>(initialAlarmSMS);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadAlarmSMS = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchAlarmSMSById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadAlarmSMS,
  };
};
