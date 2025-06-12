'use client';

export interface IProcessosObsReport {
// 202501251
    id: number;
 
	processo: number,
	historico: number,
	data: string,
	observacao: string,
}

export interface IProcessosObsReportFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IProcessosObsReportIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}