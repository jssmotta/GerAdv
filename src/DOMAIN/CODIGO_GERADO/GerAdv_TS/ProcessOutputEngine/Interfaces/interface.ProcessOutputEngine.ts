﻿"use client";
export interface IProcessOutputEngine {
// 202501251
    id: number;
 
		nome: string,
		database: string,
		tabela: string,
		campo: string,
		valor: string,
		output: string,
		administrador: boolean,
		outputsource: number,
		disableditem: boolean,
		idmodulo: number,
		isonlyprocesso: boolean,
		myid: number,
}

export interface IProcessOutputEngineFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IProcessOutputEngineIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}