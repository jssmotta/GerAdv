﻿"use client";
export interface IAgendaStatus {
// 202501251
    id: number;
 
		agenda: number,
		completed: number,
		auditor: undefined | null
}

export interface IAgendaStatusFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IAgendaStatusIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}