"use client";
import { useState } from 'react';
import { IProcessosObsReport } from '../Interfaces/interface.ProcessosObsReport';
import { IProcessosObsReportService } from '../Services/ProcessosObsReport.service';

export const useProcessosObsReportForm = (
  initialProcessosObsReport: IProcessosObsReport,
  dataService: IProcessosObsReportService
) => {
  const [data, setData] = useState<IProcessosObsReport>(initialProcessosObsReport);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadProcessosObsReport = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchProcessosObsReportById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadProcessosObsReport,
  };
};
